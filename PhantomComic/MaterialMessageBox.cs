using MaterialSkin;
using MaterialSkin.Controls;
using System;

namespace PhantomComic
{
    public partial class MaterialMessageBox : MaterialForm
    {
        // Constructor
        public MaterialMessageBox(string title, string body)
        {
            // Draw MaterialMessageBox
            InitializeComponent();
            MaterialSkinManager manager = MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            manager.Theme = MaterialSkinManager.Themes.DARK;
            manager.ColorScheme = new ColorScheme(Primary.DeepPurple400, Primary.Grey900, 0, Accent.DeepPurple200, TextShade.BLACK);

            // Setup
            this.Text = title;
            message.Text = body;
        }

        // MaterialRaisedButton Events
        private void ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}