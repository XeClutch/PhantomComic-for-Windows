namespace PhantomComic
{
    partial class frmImport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImport));
            this.search = new MaterialSkin.Controls.MaterialRaisedButton();
            this.search_text = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.comic_description = new System.Windows.Forms.Label();
            this.comic_name = new System.Windows.Forms.Label();
            this.comic_picture = new System.Windows.Forms.PictureBox();
            this.search_results = new System.Windows.Forms.ListBox();
            this.comic_save = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.comic_picture)).BeginInit();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.AutoSize = true;
            this.search.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.search.Depth = 0;
            this.search.Icon = null;
            this.search.Location = new System.Drawing.Point(518, 107);
            this.search.MouseState = MaterialSkin.MouseState.HOVER;
            this.search.Name = "search";
            this.search.Primary = true;
            this.search.Size = new System.Drawing.Size(73, 36);
            this.search.TabIndex = 38;
            this.search.Text = "search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // search_text
            // 
            this.search_text.Depth = 0;
            this.search_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.search_text.Hint = "Enter the comic name";
            this.search_text.Location = new System.Drawing.Point(477, 75);
            this.search_text.MaxLength = 32767;
            this.search_text.MouseState = MaterialSkin.MouseState.HOVER;
            this.search_text.Name = "search_text";
            this.search_text.PasswordChar = '\0';
            this.search_text.SelectedText = "";
            this.search_text.SelectionLength = 0;
            this.search_text.SelectionStart = 0;
            this.search_text.Size = new System.Drawing.Size(156, 23);
            this.search_text.TabIndex = 35;
            this.search_text.TabStop = false;
            this.search_text.UseSystemPasswordChar = false;
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(469, 75);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(2, 238);
            this.materialDivider1.TabIndex = 34;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // comic_description
            // 
            this.comic_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.comic_description.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.comic_description.Location = new System.Drawing.Point(172, 121);
            this.comic_description.Name = "comic_description";
            this.comic_description.Size = new System.Drawing.Size(291, 192);
            this.comic_description.TabIndex = 33;
            this.comic_description.Text = "Comic Description";
            // 
            // comic_name
            // 
            this.comic_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.comic_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.comic_name.Location = new System.Drawing.Point(172, 75);
            this.comic_name.Name = "comic_name";
            this.comic_name.Size = new System.Drawing.Size(291, 46);
            this.comic_name.TabIndex = 32;
            this.comic_name.Text = "Comic Name";
            // 
            // comic_picture
            // 
            this.comic_picture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("comic_picture.BackgroundImage")));
            this.comic_picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.comic_picture.Location = new System.Drawing.Point(12, 75);
            this.comic_picture.Name = "comic_picture";
            this.comic_picture.Size = new System.Drawing.Size(154, 184);
            this.comic_picture.TabIndex = 31;
            this.comic_picture.TabStop = false;
            // 
            // search_results
            // 
            this.search_results.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.search_results.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.search_results.FormattingEnabled = true;
            this.search_results.IntegralHeight = false;
            this.search_results.ItemHeight = 12;
            this.search_results.Location = new System.Drawing.Point(477, 153);
            this.search_results.MultiColumn = true;
            this.search_results.Name = "search_results";
            this.search_results.Size = new System.Drawing.Size(156, 165);
            this.search_results.TabIndex = 39;
            this.search_results.SelectedIndexChanged += new System.EventHandler(this.search_results_SelectedIndexChanged);
            // 
            // comic_save
            // 
            this.comic_save.AutoSize = true;
            this.comic_save.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.comic_save.Depth = 0;
            this.comic_save.Icon = null;
            this.comic_save.Location = new System.Drawing.Point(21, 277);
            this.comic_save.MouseState = MaterialSkin.MouseState.HOVER;
            this.comic_save.Name = "comic_save";
            this.comic_save.Primary = true;
            this.comic_save.Size = new System.Drawing.Size(135, 36);
            this.comic_save.TabIndex = 40;
            this.comic_save.Text = "save this comic";
            this.comic_save.UseVisualStyleBackColor = true;
            this.comic_save.Click += new System.EventHandler(this.comic_save_Click);
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 325);
            this.Controls.Add(this.comic_save);
            this.Controls.Add(this.search_results);
            this.Controls.Add(this.search);
            this.Controls.Add(this.search_text);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.comic_description);
            this.Controls.Add(this.comic_name);
            this.Controls.Add(this.comic_picture);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pull a comic from our repository";
            ((System.ComponentModel.ISupportInitialize)(this.comic_picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialRaisedButton search;
        private MaterialSkin.Controls.MaterialSingleLineTextField search_text;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.Label comic_description;
        private System.Windows.Forms.Label comic_name;
        private System.Windows.Forms.PictureBox comic_picture;
        private System.Windows.Forms.ListBox search_results;
        private MaterialSkin.Controls.MaterialRaisedButton comic_save;
    }
}