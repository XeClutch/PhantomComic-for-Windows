using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace PhantomComic
{
    public partial class frmImport : MaterialForm
    {
        // Variables
        Dictionary<string, string> comic_list = new Dictionary<string, string>();
        int comic_loadstep = 0;
        WebBrowser search_descbrowser = new WebBrowser();
        WebBrowser search_picbrowser = new WebBrowser();

        // Methods
        private string FormatSeriesName(string seriesname)
        {
            return seriesname.Replace('/', '-').Replace(": ", " - ");
        }
        private string GetRCCode(string text)
        {
            return text.Replace("{", "").Replace("}", "").Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", "").Replace(":", "").Replace("&", "").Replace("/", "-").Replace("\\", "").Replace("@", "").Replace("'", "").Replace("*", "").Replace("!", "").Replace("+", "").Replace("?", "").Replace(",", "").Replace(" - ", "-").Replace("  ", "-").Replace(" ", "-").ToLower().TrimEnd(new char[] { '-' });
        }

        // Constructor
        public frmImport()
        {
            // Draw frmImport
            InitializeComponent();
            MaterialSkinManager manager = MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            manager.Theme = MaterialSkinManager.Themes.DARK;
            manager.ColorScheme = new ColorScheme(Primary.DeepPurple400, Primary.Grey900, 0, Accent.DeepPurple200, TextShade.BLACK);

            // Setup
            search_descbrowser.ScriptErrorsSuppressed = true;
            search_picbrowser.ScriptErrorsSuppressed = true;
            search_text.KeyPress += search_text_KeyPress;
            string buffer = new WebClient().DownloadString("http://pastebin.com/raw/351Mc2yQ");
            string[] lines = buffer.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            foreach (string line in lines)
                comic_list.Add(line, GetRCCode(line));
        }

        // WebBrowser Events
        private void search_descbrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElementCollection elements = search_descbrowser.Document.GetElementsByTagName("div");

            foreach (HtmlElement element in elements)
            {
                if (element != null && element.GetAttribute("className") == "manga-desc")
                {
                    comic_description.Text = element.InnerText.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None)[1];
                    comic_loadstep++;
                    search_descbrowser.Stop();
                    search_descbrowser.DocumentCompleted -= search_descbrowser_DocumentCompleted;
                }
            }
        }
        private void search_picbrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElement element = search_picbrowser.Document.GetElementById("series_image");

            if (element != null)
            {
                string source = element.OuterHtml.Split(new string[] { "src=\"" }, StringSplitOptions.None)[1].Split(new string[] { "\"" }, StringSplitOptions.None)[0];
                if (source != "")
                {
                    byte[] buffer = new WebClient().DownloadData(source);
                    MemoryStream stream = new MemoryStream(buffer);
                    comic_picture.BackgroundImage = Image.FromStream(stream);
                    stream.Dispose();
                    comic_loadstep++;
                    search_picbrowser.Stop();
                    search_picbrowser.DocumentCompleted -= search_picbrowser_DocumentCompleted;
                }
            }
        }

        // MaterialSingleLineTextField Events
        private void search_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                search_Click(0, new EventArgs());
        }

        // MaterialRaisedButton Events
        private void comic_save_Click(object sender, EventArgs e)
        {
            if (comic_loadstep == 2)
            {
                if (!Directory.Exists("data\\" + comic_list[comic_name.Text]))
                {
                    Directory.CreateDirectory("data\\" + comic_list[comic_name.Text]);
                    File.WriteAllText("data\\" + comic_list[comic_name.Text] + "\\detail.txt", comic_name.Text);
                    File.WriteAllText("data\\" + comic_list[comic_name.Text] + "\\desc.txt", comic_description.Text);

                    Bitmap bmp = new Bitmap(comic_picture.BackgroundImage);
                    bmp.Save("data\\" + comic_list[comic_name.Text] + "\\banner.jpg");
                }
            }
            else
                new MaterialMessageBox("Error", "You need to wait for the comic to load before saving it.").ShowDialog();
        }
        private void search_Click(object sender, EventArgs e)
        {
            string query = search_text.Text.ToLower();
            string[] keys = comic_list.Keys.ToArray();
            search_results.Items.Clear();
            foreach (string key in keys)
                if (key.ToLower().Contains(query))
                    search_results.Items.Add(key);
        }

        // ListBox Events
        private void search_results_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = search_results.GetItemText(search_results.SelectedItem);
            string value = comic_list[key];
            string url = "http://www.readcomics.tv/comic/" + value;
            comic_name.Text = key;
            comic_description.Text = "Fetching comic description..";
            comic_loadstep = 0;
            search_descbrowser.DocumentCompleted += search_descbrowser_DocumentCompleted;
            search_descbrowser.Navigate(url);
            search_picbrowser.DocumentCompleted += search_picbrowser_DocumentCompleted;
            search_picbrowser.Navigate(url);
        }
    }
}