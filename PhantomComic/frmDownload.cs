using HtmlAgilityPack;
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
        int download_chapter = 0;
        int download_chapterad = 0;
        bool download_hasdec = false;
        bool download_hashyp = false;
        string download_name = "";
        int download_pageend = 0;
        int download_pagestart = 0;
        string download_rccode = "";

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
                comic_description.Text = ComicUtils.RetrieveDescription(rccode);

                File.WriteAllText("data\\" + rccode + "\\desc.txt", comic_description.Text);
            }
            else
                comic_description.Text = File.ReadAllText("data\\" + rccode + "\\desc.txt");
            FileStream stream = new FileStream("data\\" + rccode + "\\banner.jpg", FileMode.Open, FileAccess.Read);
            comic_picture.BackgroundImage = Image.FromStream(stream);
            stream.Dispose();
            autofindpages.Checked = true;
            comic_chapternum.KeyPress += comic_chapternum_KeyPress;
            comic_startpagenum.KeyPress += comic_startpagenum_KeyPress;
            comic_endpagenum.KeyPress += comic_endpagenum_KeyPress;
            bulk_chapternums.KeyPress += bulk_chapternums_KeyPress;
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
                bulk_progress.Location = new Point(bulk_progress.Location.X, bulk_progress.Location.Y - 23);
            }
            else
            {
                comic_download.Location = new Point(comic_download.Location.X, comic_download.Location.Y + 23);
                materialDivider2.Location = new Point(materialDivider2.Location.X, materialDivider2.Location.Y + 23);
                bulk_chapternums.Location = new Point(bulk_chapternums.Location.X, bulk_chapternums.Location.Y + 23);
                bulk_download.Location = new Point(bulk_download.Location.X, bulk_download.Location.Y + 23);
                bulk_progress.Location = new Point(bulk_progress.Location.X, bulk_progress.Location.Y + 23);
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
                int cnt = ComicUtils.RetrievePageCount(download_rccode, comic_chapternum.Text);
                if (cnt > 0)
                    new MaterialMessageBox("Fetch", "There are " + (comic_endpagenum.Text = cnt.ToString()) + " in this chapter.");
                else if (cnt == (int)ChapterFailReason.DoesntExist)
                    new MaterialMessageBox("Fetch", "This chapter is not hosted on ReadComicsTV.").ShowDialog();
                else if (cnt == (int)ChapterFailReason.UnableToReadPageCount)
                    new MaterialMessageBox("Fetch", "Unable to read this chapter's page count. There may be something wrong with the page, feel free to try again.");
                else
                    new MaterialMessageBox("Fetch", "Unable to get this chapter's page count due to an unknown error.");
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
                download_pageend = int.Parse(ComicUtils.RetrievePageCount(download_rccode, chapterstr).ToString());

            string str = "Unable to download chapter #" + download_chapter + (download_hasdec ? ("." + download_chapterad) : (download_hashyp ? ("-" + download_chapterad) : " "));
            if (download_pageend > 0)
            {
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
            else if (download_pageend == (int)ChapterFailReason.DoesntExist)
                str += "because it's not hosted on ReadComicsTV.";
            else if (download_pageend == (int)ChapterFailReason.UnableToReadPageCount)
                str += "because there was an issue retrieving the page count. You can try again if you'd like.";
            else
                str += "because of an unknown error.";
            if (str.Contains("because"))
                new MaterialMessageBox("Error", str).ShowDialog();
        }
        private void bulk_download_Click(object sender, EventArgs e)
        {
            string[] split = bulk_chapternums.Text.Split(new char[] { '-' });
            int chapter_start = int.Parse(split[0]);
            int chapter_finish = int.Parse(split[1]);
            List<ChapterFail> failed = new List<ChapterFail>();

            bulk_progress.Visible = true;
            bulk_progress.Maximum = (chapter_finish - chapter_start) + 1;

            for (int i = chapter_start; i <= chapter_finish; i++)
            {
                int pages = ComicUtils.RetrievePageCount(download_rccode, i.ToString());
                if (pages > 0)
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
                {
                    ChapterFail fail;
                    fail.chapter = i;
                    fail.reason = (ChapterFailReason)pages;
                    //if (pages == -2)
                    //    fail.reason = ChapterFailReason.DoesntExist;
                    //else if (pages == -3)
                    //    fail.reason = ChapterFailReason.UnableToReadPageCount;
                    //else
                    //    fail.reason = ChapterFailReason.Unknown;
                    failed.Add(fail);
                }

                bulk_progress.Value++;
            }

            bulk_progress.Value = 0;
            bulk_progress.Visible = false;

            if (failed.Count > 0)
            {
                string str = "The following chapters failed to download:\n\n";
                foreach (ChapterFail fail in failed)
                {
                    str += "#" + fail.chapter + " - ";
                    if (fail.reason == ChapterFailReason.DoesntExist)
                        str += "Chapter not hosted.";
                    else if (fail.reason == ChapterFailReason.UnableToReadPageCount)
                        str += "Unable to get page count.";
                    else if (fail.reason == ChapterFailReason.Unknown)
                        str += "Unknown error.";
                    str += "\n";
                }
                new MaterialMessageBox("Error", str).ShowDialog();
            }
        }
    }
}