using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PhantomComic
{
    public partial class frmFullscreen : Form
    {
        // Constructor
        public frmFullscreen(Image page)
        {
            // Draw frmFullScreen
            InitializeComponent();

            // Setup
            this.KeyDown += frmFullscreen_KeyDown;
            frmFullscreen_KeyDown(0, new KeyEventArgs(Keys.None));// picture.BackgroundImage = page;
        }

        // Form Events
        private void frmFullscreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && frmViewer.curpage > 0)
                frmViewer.curpage--;
            else if (e.KeyCode == Keys.Right && frmViewer.curpage < (frmViewer.pages.Length - 1))
                frmViewer.curpage++;
            else if (e.KeyCode == Keys.Down && frmViewer.curchapter > 0)
                frmViewer.chapterselect.SelectedIndex--;
            else if (e.KeyCode == Keys.Up && frmViewer.curchapter < (frmViewer.chapters.Length - 1))
                frmViewer.chapterselect.SelectedIndex++;
            else if (e.KeyCode == Keys.Escape)
                this.Close();

            FileStream stream = new FileStream(frmViewer.pages[frmViewer.curpage], FileMode.Open, FileAccess.Read);
            picture.BackgroundImage = Image.FromStream(stream);
            stream.Dispose();

            info.Text = "Chapter #" + (frmViewer.curchapter + 1) + "\nPage: " + (frmViewer.curpage + 1) + " / " + frmViewer.pages.Length;
        }

        // PictureBox Events
        private void page_picture_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}