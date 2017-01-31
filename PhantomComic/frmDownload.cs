using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PhantomComic
{
    public partial class frmDownload : MaterialForm
    {
        // Variables
        int cipher_pagecount = -1;
        WebBrowser comic_browser = new WebBrowser();
        bool comic_browser_wait = false;
        int download_chapter = 0;
        int download_chapterad = 0;
        bool download_hasdec = false;
        bool download_hashyp = false;
        string download_name = "";
        int download_pageend = 0;
        int download_pagestart = 0;
        string download_rccode = "";

        // Methods
        private int GetPageCount(string chapter)
        {
            cipher_pagecount = -1;
            for (int i = 0; i < 3; i++)
            {
                comic_browser_wait = true;
                comic_browser.DocumentCompleted += comic_browser_page_DocumentCompleted;
                comic_browser.Navigate("http://www.readcomics.tv/" + download_rccode + "/chapter-" + chapter);
                
                while (comic_browser_wait)
                    Application.DoEvents();
                if (cipher_pagecount != -1)
                    return cipher_pagecount;
            }
            return (cipher_pagecount = -1);
        }

        // Constructor
        public frmDownload(string rccode)
        {
            // Draw frmDownload
            InitializeComponent();
            MaterialSkinManager manager = MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            manager.Theme = MaterialSkinManager.Themes.DARK;
            manager.ColorScheme = new ColorScheme(Primary.DeepPurple400, Primary.Grey900, 0, Accent.DeepPurple200, TextShade.BLACK);

            // Setup
            CheckForIllegalCrossThreadCalls = false;
            download_name = File.ReadAllText("data\\" + rccode + "\\detail.txt");
            download_rccode = rccode;
            comic_name.Font = new Font("Roboto", 13f, FontStyle.Regular);
            comic_name.Text = download_name;
            if (!File.Exists("data\\" + rccode + "\\desc.txt"))
            {
                comic_browser.ScriptErrorsSuppressed = true;
                comic_browser.DocumentCompleted += comic_browser_desc_DocumentCompleted;
                comic_browser.Navigate("http://www.readcomics.tv/comic/" + rccode);
            }
            else
                comic_description.Text = File.ReadAllText("data\\" + rccode + "\\desc.txt");
            FileStream stream = new FileStream("data\\" + rccode + "\\banner.jpg", FileMode.Open, FileAccess.Read);
            comic_picture.BackgroundImage = Image.FromStream(stream);
            stream.Dispose();
            comic_chapternum.KeyPress += comic_chapternum_KeyPress;
            comic_startpagenum.KeyPress += comic_startpagenum_KeyPress;
            comic_endpagenum.KeyPress += comic_endpagenum_KeyPress;
            bulk_chapternums.KeyPress += bulk_chapternums_KeyPress;
        }

        // WebBrowser Events
        private void comic_browser_desc_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                HtmlElementCollection elements = comic_browser.Document.GetElementsByTagName("div");

                foreach (HtmlElement element in elements)
                {
                    if (element != null && element.GetAttribute("className") == "manga-desc")
                    {
                        comic_description.Text = element.InnerText.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None)[1];
                        File.WriteAllText("data\\" + download_rccode + "\\desc.txt", comic_description.Text);
                        comic_browser.Stop();
                        comic_browser.DocumentCompleted -= comic_browser_desc_DocumentCompleted;
                    }
                }
            }
            catch
            {
                new MaterialMessageBox("Error", "Unable to fetch comic description. This comic may not be hosted.").ShowDialog();
                comic_browser.Stop();
                comic_browser.DocumentCompleted -= comic_browser_desc_DocumentCompleted;
            }
        }
        private void comic_browser_page_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                HtmlElement element = comic_browser.Document.GetElementById("page_select");

                if (element != null)
                {
                    string[] buffer = element.InnerText.Split(new char[] { ' ' });
                    int res = 0;
                    bool parsed = int.TryParse(buffer[buffer.Length - 2], out res);
                    if (parsed)
                        cipher_pagecount = res;
                    else
                        cipher_pagecount = -1;
                    comic_browser_wait = false;
                    comic_browser.Stop();
                    comic_browser.DocumentCompleted -= comic_browser_page_DocumentCompleted;
                }
            }
            catch
            {
                new MaterialMessageBox("Error", "Unable to fetch comic page count. This chapter may not be hosted.").ShowDialog();
                comic_browser.Stop();
                comic_browser.DocumentCompleted -= comic_browser_page_DocumentCompleted;
            }
        }

        // MaterialCheckBox Events
        private void autofindpages_CheckedChanged(object sender, EventArgs e)
        {
            bool toggle = autofindpages.Checked;

            comic_startpagenum.Visible = !toggle;
            comic_startpagenum.Text = "";
            comic_getlast.Visible = !toggle;
            comic_endpagenum.Text = "";
            comic_endpagenum.Visible = !toggle;
            if (toggle)
            {
                comic_download.Location = new Point(comic_download.Location.X, comic_download.Location.Y - 23);
                materialDivider2.Location = new Point(materialDivider2.Location.X, materialDivider2.Location.Y - 23);
                bulk_chapternums.Location = new Point(bulk_chapternums.Location.X, bulk_chapternums.Location.Y - 23);
                bulk_download.Location = new Point(bulk_download.Location.X, bulk_download.Location.Y - 23);
            }
            else
            {
                comic_download.Location = new Point(comic_download.Location.X, comic_download.Location.Y + 23);
                materialDivider2.Location = new Point(materialDivider2.Location.X, materialDivider2.Location.Y + 23);
                bulk_chapternums.Location = new Point(bulk_chapternums.Location.X, bulk_chapternums.Location.Y + 23);
                bulk_download.Location = new Point(bulk_download.Location.X, bulk_download.Location.Y + 23);
            }
        }

        // MaterialSingleLineTextField Events
        private void comic_chapternum_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            if (!char.IsControl(key) && !char.IsDigit(key) && key != '.' && key != '-')
                e.Handled = true;
        }
        private void comic_startpagenum_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            if (!char.IsControl(key) && !char.IsDigit(key))
                e.Handled = true;
        }
        private void comic_endpagenum_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            if (!char.IsControl(key) && !char.IsDigit(key))
                e.Handled = true;
        }
        private void bulk_chapternums_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            if ((!char.IsControl(key) && !char.IsDigit(key)) && (key != '-' && !bulk_chapternums.Text.Contains("-")))
                    e.Handled = true;
        }

        // Label Events
        private void comic_getlast_Click(object sender, EventArgs e)
        {
            if (comic_chapternum.Text != "")
            {
                int cnt = GetPageCount(comic_chapternum.Text);
                if (cnt != -1)
                    new MaterialMessageBox("Fetch", "There are " + (comic_endpagenum.Text = cnt.ToString()) + " in this chapter.");
                else
                    new MaterialMessageBox("Error", "Unable to determine how many pages are in this chapter. This chapter may not be hosted.").ShowDialog();
            }
        }

        // MaterialRaisedButton Events
        private void comic_download_Click(object sender, EventArgs e)
        {
            string chapterstr = comic_chapternum.Text;
            download_hasdec = chapterstr.Contains(".");
            download_hashyp = chapterstr.Contains("-");

            if (chapterstr == "") return;

            if (download_hasdec)
            {
                string[] split = chapterstr.Split(new char[] { '.' });
                download_chapter = int.Parse(split[0]);
                download_chapterad = int.Parse(split[1]);
            }
            else if (download_hashyp)
            {
                string[] split = chapterstr.Split(new char[] { '-' });
                download_chapter = int.Parse(split[0]);
                download_chapterad = int.Parse(split[1]);
            }
            else
                download_chapter = int.Parse(chapterstr);

            if (comic_startpagenum.Text != "")
                download_pagestart = int.Parse(comic_startpagenum.Text);
            else
                download_pagestart = 1;
            if (comic_endpagenum.Text != "" && comic_endpagenum.Text != "-1")
                download_pageend = int.Parse(comic_endpagenum.Text);
            else
                download_pageend = int.Parse((comic_endpagenum.Text = GetPageCount(chapterstr).ToString()));

            ComicDownloadEntry entry;
            entry.comic_name = download_name;
            entry.comic_rccode = download_rccode;
            entry.chapter_ad = download_chapterad;
            entry.chapter_num = download_chapter;
            entry.chapter_hasdec = download_hasdec;
            entry.chapter_hashyp = download_hashyp;
            entry.page_start = download_pagestart;
            entry.page_end = download_pageend;
            entry.resize = comic_resize.Checked;
            DownloadAssistant.Add(entry);
        }
        private void bulk_download_Click(object sender, EventArgs e)
        {
            string[] split = bulk_chapternums.Text.Split(new char[] { '-' });
            int chapter_start = int.Parse(split[0]);
            int chapter_finish = int.Parse(split[1]);
            List<int> failed = new List<int>();

            for (int i = chapter_start; i <= chapter_finish; i++)
            {
                int pages = GetPageCount(i.ToString());
                if (pages != -1)
                {
                    ComicDownloadEntry entry;
                    entry.comic_name = download_name;
                    entry.comic_rccode = download_rccode;
                    entry.chapter_ad = 0;
                    entry.chapter_num = i;
                    entry.chapter_hasdec = false;
                    entry.chapter_hashyp = false;
                    entry.page_start = 1;
                    entry.page_end = pages;
                    entry.resize = comic_resize.Checked;
                    DownloadAssistant.Add(entry);
                }
                else
                    failed.Add(i);
            }

            if (failed.Count > 0)
            {
                if (failed.Count > 1)
                {
                    string str = "Unable to download chapters [";
                    for (int i = 0; i < failed.Count; i++)
                    {
                        if (i == (failed.Count - 1))
                            str += failed[i].ToString();
                        else
                            str += failed[i].ToString() + ", ";
                    }
                    str += "]. All other chapters have been queued for download.";
                    new MaterialMessageBox("Error", str).ShowDialog();
                }
                else
                    new MaterialMessageBox("Error", "Unable to download chapter " + failed[0] + ". All other chapters have been queued for download.").ShowDialog();
            }
        }
    }
}