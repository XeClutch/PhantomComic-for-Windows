using HtmlAgilityPack;
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
            search_text.KeyPress += search_text_KeyPress;
            string buffer = new WebClient().DownloadString("http://pastebin.com/raw/351Mc2yQ");
            string[] comics = buffer.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            foreach (string comic in comics)
                comic_list.Add(comic, ComicUtils.GetRCCode(comic));
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
            // Check if comic is already saved
            if (!Directory.Exists("data\\" + comic_list[comic_name.Text]))
            {
                // Create directory
                Directory.CreateDirectory("data\\" + comic_list[comic_name.Text]);

                // Save metadata
                File.WriteAllText("data\\" + comic_list[comic_name.Text] + "\\detail.txt", comic_name.Text);
                File.WriteAllText("data\\" + comic_list[comic_name.Text] + "\\desc.txt", comic_description.Text);

                // Save banner
                Bitmap bmp = new Bitmap(comic_picture.Image);
                bmp.Save("data\\" + comic_list[comic_name.Text] + "\\banner.jpg");
            }
        }
        private void search_Click(object sender, EventArgs e)
        {
            // Setup
            string query = search_text.Text.ToLower();
            string[] keys = comic_list.Keys.ToArray();
            search_results.Items.Clear();

            // Search
            foreach (string key in keys)
                if (key.ToLower().Contains(query))
                    search_results.Items.Add(key);
        }

        // ListBox Events
        private void search_results_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Setup
            if (search_results.SelectedIndex < 0) return;
            string key = search_results.GetItemText(search_results.SelectedItem);
            string value = comic_list[key];
            string url = "http://www.readcomics.tv/comic/" + value;
            comic_name.Text = key;

            // Grab page source
            string html = new WebClient().DownloadString(url);

            // Get banner
            comic_picture.Load(ComicUtils.RetrieveBanner(value, html));
            comic_picture.SizeMode = PictureBoxSizeMode.Zoom;

            // Get description
            comic_description.Text = ComicUtils.RetrieveDescription(value, html);
        }
    }
}