using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.IO;

namespace PhantomComic
{
    public partial class frmViewer : MaterialForm
    {
        // Variables
        public static string[] chapters;
        public static string[] pages;
        public static int curchapter = 0;
        public static int curpage = 0;

        // Constructor
        public frmViewer(string rccode)
        {
            // Draw frmViewer
            InitializeComponent();
            MaterialSkinManager manager = MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            manager.Theme = MaterialSkinManager.Themes.DARK;
            manager.ColorScheme = new ColorScheme(Primary.DeepPurple400, Primary.Grey900, 0, Accent.DeepPurple200, TextShade.BLACK);

            // Setup
            this.Text = File.ReadAllText("data\\" + rccode + "\\detail.txt");
            chapters = Directory.GetDirectories("data\\" + rccode + "\\comic");
            foreach (string chapter in chapters)
                chapterselect.Items.Add("Chapter #" + chapter.Replace("data\\" + rccode + "\\comic\\", ""));
            chapterselect.SelectedIndex = 0;
            page_picture.DoubleClick += page_picture_DoubleClick;
        }

        // ComboBox Events
        private void chapterselect_SelectedIndexChanged(object sender, EventArgs e)
        {
            curchapter = chapterselect.SelectedIndex;
            curpage = 0;
            pages = Directory.GetFiles(chapters[curchapter]);
            string[] buffer = new string[pages.Length];
            Array.Copy(pages, buffer, pages.Length);
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = "Page #" + int.Parse(buffer[i].Split(new char[] { '\\' })[4].Replace(".jpg", "")).ToString();
            pageselect.Items.Clear();
            pageselect.Items.AddRange(buffer);
            pageselect.SelectedIndex = 0;
            pageend.Text = "/ " + int.Parse(buffer[buffer.Length - 1].Replace("Page #", "")).ToString();
        }
        private void pageselect_SelectedIndexChanged(object sender, EventArgs e)
        {
            curpage = pageselect.SelectedIndex;

            FileStream stream = new FileStream(pages[curpage], FileMode.Open, FileAccess.Read);
            page_picture.BackgroundImage = Image.FromStream(stream);
            stream.Dispose();
        }
        
        // PictureBox Events
        private void page_previous_Click(object sender, EventArgs e)
        {
            if (curpage > 0)
                curpage--;

            FileStream stream = new FileStream(pages[curpage], FileMode.Open, FileAccess.Read);
            page_picture.BackgroundImage = Image.FromStream(stream);
            stream.Dispose();
            pageselect.SelectedIndex = curpage;
        }
        private void page_picture_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            new frmFullscreen(page_picture.BackgroundImage).ShowDialog();
            pageselect.SelectedIndex = curpage;
            this.Show();
        }
        private void page_next_Click(object sender, EventArgs e)
        {
            if (curpage < (pages.Length - 1))
                curpage++;

            FileStream stream = new FileStream(pages[curpage], FileMode.Open, FileAccess.Read);
            page_picture.BackgroundImage = Image.FromStream(stream);
            stream.Dispose();
            pageselect.SelectedIndex = curpage;
        }
    }
}