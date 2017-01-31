using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace PhantomComic
{
    public partial class frmMain : MaterialForm
    {
        // Variables
        List<string> comics_list = new List<string>();
        string credits_link;
        string[] credits_messages;
        Thread credits_thread;
        int curpage = 0;
        Thread download_thread;

        // Threads
        private void CreditsUpdate()
        {
            int i = 0;
            int cnt = 0;
            while (credits_thread.ThreadState == ThreadState.Running)
            {
                if (i == 0)
                {
                    credits_messages = new WebClient().DownloadString("http://www.pastebin.com/raw/5PhkGfZ8").Split(new string[] { "\r\n" }, StringSplitOptions.None);
                    cnt = credits_messages.Length;
                }

                string[] split = credits_messages[i].Split(new string[] { "<|>" }, StringSplitOptions.None);
                if (split.Length > 1)
                {
                    credits.Cursor = Cursors.Hand;
                    credits.Text = split[0];
                    credits_link = split[1];
                }
                else
                {
                    credits.Cursor = Cursors.Arrow;
                    credits.Text = split[0];
                    credits_link = "";
                }

                Thread.Sleep(6000);
                i++;
                if (i == cnt)
                    i = 0;
            }
        }

        // Methods
        private void DeleteComic(string comic)
        {
            Directory.Delete("data\\" + comic, true);
        }
        private string GetRCCode(string text)
        {
            return text.Replace("{", "").Replace("}", "").Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", "").Replace(":", "").Replace("&", "").Replace("/", "-").Replace("\\", "").Replace("@", "").Replace("'", "").Replace("*", "").Replace("!", "").Replace("+", "").Replace("?", "").Replace(",", "").Replace(" - ", "-").Replace("  ", "-").Replace(" ", "-").ToLower().TrimEnd(new char[] { '-' });
        }
        private void RefreshList(int page = 0)
        {
            comics_list.Clear();
            string[] comics_series = Directory.GetDirectories("data\\");
            for (int i = 0; i < comics_series.Length; i++)
                comics_list.Add(File.ReadAllText(comics_series[i] + "\\detail.txt"));
            if ((comics_series.Length - (page * 6)) > 0)
            {
                FileStream comic1_stream = new FileStream(comics_series[page * 6] + "\\banner.jpg", FileMode.Open, FileAccess.Read);
                comic1_picture.BackgroundImage = Image.FromStream(comic1_stream);
                comic1_stream.Dispose();
                comic1_name.Text = comics_list[page * 6];
                if ((comics_series.Length - (page * 6)) > 1)
                {
                    FileStream comic2_stream = new FileStream(comics_series[(page * 6) + 1] + "\\banner.jpg", FileMode.Open, FileAccess.Read);
                    comic2_picture.BackgroundImage = Image.FromStream(comic2_stream);
                    comic2_stream.Dispose();
                    comic2_name.Text = comics_list[(page * 6) + 1];
                    if ((comics_series.Length - (page * 6)) > 2)
                    {
                        FileStream comic3_stream = new FileStream(comics_series[(page * 6) + 2] + "\\banner.jpg", FileMode.Open, FileAccess.Read);
                        comic3_picture.BackgroundImage = Image.FromStream(comic3_stream);
                        comic3_stream.Dispose();
                        comic3_name.Text = comics_list[(page * 6) + 2];
                        if ((comics_series.Length - (page * 6)) > 3)
                        {
                            FileStream comic4_stream = new FileStream(comics_series[(page * 6) + 3] + "\\banner.jpg", FileMode.Open, FileAccess.Read);
                            comic4_picture.BackgroundImage = Image.FromStream(comic4_stream);
                            comic4_stream.Dispose();
                            comic4_name.Text = comics_list[(page * 6) + 3];
                            if ((comics_series.Length - (page * 6)) > 4)
                            {
                                FileStream comic5_stream = new FileStream(comics_series[(page * 6) + 4] + "\\banner.jpg", FileMode.Open, FileAccess.Read);
                                comic5_picture.BackgroundImage = Image.FromStream(comic5_stream);
                                comic5_stream.Dispose();
                                comic5_name.Text = comics_list[(page * 6) + 4];
                                if ((comics_series.Length - (page * 6)) > 5)
                                {
                                    FileStream comic6_stream = new FileStream(comics_series[(page * 6) + 5] + "\\banner.jpg", FileMode.Open, FileAccess.Read);
                                    comic6_picture.BackgroundImage = Image.FromStream(comic6_stream);
                                    comic6_stream.Dispose();
                                    comic6_name.Text = comics_list[(page * 6) + 5];
                                }
                                else
                                {
                                    comic6_name.Text = "No Comic";
                                    comic6_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("comic6_picture.BackgroundImage")));
                                }
                            }
                            else
                            {
                                comic5_name.Text = "No Comic";
                                comic5_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("comic5_picture.BackgroundImage")));
                                comic6_name.Text = "No Comic";
                                comic6_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("comic6_picture.BackgroundImage")));
                            }
                        }
                        else
                        {
                            comic4_name.Text = "No Comic";
                            comic4_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("comic4_picture.BackgroundImage")));
                            comic5_name.Text = "No Comic";
                            comic5_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("comic5_picture.BackgroundImage")));
                            comic6_name.Text = "No Comic";
                            comic6_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("comic6_picture.BackgroundImage")));
                        }
                    }
                    else
                    {
                        comic3_name.Text = "No Comic";
                        comic3_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("comic3_picture.BackgroundImage")));
                        comic4_name.Text = "No Comic";
                        comic4_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("comic4_picture.BackgroundImage")));
                        comic5_name.Text = "No Comic";
                        comic5_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("comic5_picture.BackgroundImage")));
                        comic6_name.Text = "No Comic";
                        comic6_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("comic6_picture.BackgroundImage")));
                    }
                }
                else
                {
                    comic2_name.Text = "No Comic";
                    comic2_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("comic2_picture.BackgroundImage")));
                    comic3_name.Text = "No Comic";
                    comic3_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("comic3_picture.BackgroundImage")));
                    comic4_name.Text = "No Comic";
                    comic4_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("comic4_picture.BackgroundImage")));
                    comic5_name.Text = "No Comic";
                    comic5_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("comic5_picture.BackgroundImage")));
                    comic6_name.Text = "No Comic";
                    comic6_picture.BackgroundImage = ((Image)(new ComponentResourceManager(typeof(frmMain)).GetObject("comic6_picture.BackgroundImage")));
                }
            }
        }

        // Constructor
        public frmMain()
        {
            // Version Check
            string[] updatebuffer = new WebClient().DownloadString("http://pastebin.com/raw/sFRnjKR0").Split(new string[] { "\r\n" }, StringSplitOptions.None);
            Version currentversion = Assembly.GetEntryAssembly().GetName().Version;
            Version latestversion = Version.Parse(updatebuffer[0]);
            string changes = "";
            for (int i = 2; i < updatebuffer.Length; i++)
            {
                changes += updatebuffer[i];
                if (i != updatebuffer.Length)
                    changes += "\n";
            }
            if (currentversion < latestversion)
            {
                new MaterialMessageBox("Update Available", "There is an update available!\n\nCurrent Version: " + currentversion.ToString() + "\nUpdated Version: " + latestversion.ToString() + "\n\nYou will now be taken to the update download.").ShowDialog();
                System.Diagnostics.Process.Start(updatebuffer[1]);
                this.Close();
            }

            // Draw frmMain
            InitializeComponent();
            MaterialSkinManager manager = MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            manager.Theme = MaterialSkinManager.Themes.DARK;
            manager.ColorScheme = new ColorScheme(Primary.DeepPurple400, Primary.Grey900, 0, Accent.DeepPurple200, TextShade.BLACK);

            // Setup
            CheckForIllegalCrossThreadCalls = false;
            FormClosing += frmMain_FormClosing;
            downloadcontrol.Font = new Font("Roboto", 8f, FontStyle.Regular);
            credits.Font = new Font("Roboto", 8f, FontStyle.Regular);
            credits_thread = new Thread(CreditsUpdate);
            credits_thread.Start();
            download_thread = new Thread(DownloadAssistant.Downloader);
            download_thread.Start();
            if (!Directory.Exists("data"))
                Directory.CreateDirectory("data");
            RefreshList();
            DownloadAssistant.Print("\n\nChanges made to this version (" + currentversion.ToString() + "):\n" + changes);
        }

        // Form Events
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            credits_thread.Abort();
            Application.Exit();
        }

        // MaterialContextMenuStrip Events
        private void comic1_context_delete_Click(object sender, EventArgs e)
        {
            DeleteComic(GetRCCode(comics_list[curpage * 6]));
            RefreshList(curpage);
        }
        private void comic1_context_download_Click(object sender, EventArgs e)
        {
            new frmDownload(GetRCCode(comics_list[curpage * 6])).ShowDialog();
        }
        private void comic1_context_open_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("data\\" + GetRCCode(comics_list[curpage * 6]) + "\\comic"))
                new frmViewer(GetRCCode(comics_list[curpage * 6])).ShowDialog();
            else
                new MaterialMessageBox("Error", "In order to read this comic you must first download parts of it.").ShowDialog();
        }
        private void comic2_context_delete_Click(object sender, EventArgs e)
        {
            DeleteComic(GetRCCode(comics_list[(curpage * 6) + 1]));
            RefreshList(curpage);
        }
        private void comic2_context_download_Click(object sender, EventArgs e)
        {
            new frmDownload(GetRCCode(comics_list[(curpage * 6) + 1])).ShowDialog();
        }
        private void comic2_context_open_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("data\\" + GetRCCode(comics_list[(curpage * 6) + 1]) + "\\comic"))
                new frmViewer(GetRCCode(comics_list[(curpage * 6) + 1])).ShowDialog();
            else
                new MaterialMessageBox("Error", "In order to read this comic you must first download parts of it.").ShowDialog();
        }
        private void comic3_context_delete_Click(object sender, EventArgs e)
        {
            DeleteComic(GetRCCode(comics_list[(curpage * 6) + 2]));
            RefreshList(curpage);
        }
        private void comic3_context_download_Click(object sender, EventArgs e)
        {
            new frmDownload(GetRCCode(comics_list[(curpage * 6) + 2])).ShowDialog();
        }
        private void comic3_context_open_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("data\\" + GetRCCode(comics_list[(curpage * 6) + 2]) + "\\comic"))
                new frmViewer(GetRCCode(comics_list[(curpage * 6) + 2])).ShowDialog();
            else
                new MaterialMessageBox("Error", "In order to read this comic you must first download parts of it.").ShowDialog();
        }
        private void comic4_context_delete_Click(object sender, EventArgs e)
        {
            DeleteComic(GetRCCode(comics_list[(curpage * 6) + 3]));
            RefreshList(curpage);
        }
        private void comic4_context_download_Click(object sender, EventArgs e)
        {
            new frmDownload(GetRCCode(comics_list[(curpage * 6) + 3])).ShowDialog();
        }
        private void comic4_context_open_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("data\\" + GetRCCode(comics_list[(curpage * 6) + 3]) + "\\comic"))
                new frmViewer(GetRCCode(comics_list[(curpage * 6) + 3])).ShowDialog();
            else
                new MaterialMessageBox("Error", "In order to read this comic you must first download parts of it.").ShowDialog();
        }
        private void comic5_context_delete_Click(object sender, EventArgs e)
        {
            DeleteComic(GetRCCode(comics_list[(curpage * 6) + 4]));
            RefreshList(curpage);
        }
        private void comic5_context_download_Click(object sender, EventArgs e)
        {
            new frmDownload(GetRCCode(comics_list[(curpage * 6) + 4])).ShowDialog();
        }
        private void comic5_context_open_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("data\\" + GetRCCode(comics_list[(curpage * 6) + 4]) + "\\comic"))
                new frmViewer(GetRCCode(comics_list[(curpage * 6) + 4])).ShowDialog();
            else
                new MaterialMessageBox("Error", "In order to read this comic you must first download parts of it.").ShowDialog();
        }
        private void comic6_context_delete_Click(object sender, EventArgs e)
        {
            DeleteComic(GetRCCode(comics_list[(curpage * 6) + 5]));
            RefreshList(curpage);
        }
        private void comic6_context_download_Click(object sender, EventArgs e)
        {
            new frmDownload(GetRCCode(comics_list[(curpage * 6) + 5])).ShowDialog();
        }
        private void comic6_context_open_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("data\\" + GetRCCode(comics_list[(curpage * 6) + 5]) + "\\comic"))
                new frmViewer(GetRCCode(comics_list[(curpage * 6) + 5])).ShowDialog();
            else
                new MaterialMessageBox("Error", "In order to read this comic you must first download parts of it.").ShowDialog();
        }

        // PictureBox Events
        private void getplex_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.github.com/xeclutch/phantomcomic.bundle");
        }
        private void comics_previous_Click(object sender, EventArgs e)
        {
            if (curpage > 0)
            {
                curpage--;
                RefreshList(curpage);
            }
        }
        private void comics_next_Click(object sender, EventArgs e)
        {
            if (curpage < (comics_list.Count - 1) / 6)
            {
                curpage++;
                RefreshList(curpage);
            }
        }
        private void downloadcontrol_play_Click(object sender, EventArgs e)
        {
            DownloadAssistant.state = DownloadState.Free;
            new MaterialMessageBox("Download Control", "All downloads will continue as scheduled.").ShowDialog();
        }
        private void downloadcontrol_pause_Click(object sender, EventArgs e)
        {
            DownloadAssistant.state = DownloadState.Restricted;
            new MaterialMessageBox("Download Control", "All downloads will pause until you force them to resume.").ShowDialog();
        }
        private void downloadcontrol_stop_Click(object sender, EventArgs e)
        {
            DownloadAssistant.state = DownloadState.Killed;
            new MaterialMessageBox("Download Control", "All downloads will cease once the current download has finished.").ShowDialog();
        }

        // MaterialRaisedButton Events
        private void comics_import_Click(object sender, EventArgs e)
        {
            new frmImport().ShowDialog();
            RefreshList(curpage);
        }

        // Label Events
        private void credits_Click(object sender, EventArgs e)
        {
            if (credits_link != "")
                System.Diagnostics.Process.Start(credits_link);
        }
    }
}