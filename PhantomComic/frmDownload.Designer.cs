namespace PhantomComic
{
    partial class frmDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownload));
            this.comic_picture = new System.Windows.Forms.PictureBox();
            this.comic_name = new System.Windows.Forms.Label();
            this.comic_description = new System.Windows.Forms.Label();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.comic_chapternum = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.comic_startpagenum = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.comic_endpagenum = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.comic_getlast = new System.Windows.Forms.Label();
            this.comic_download = new MaterialSkin.Controls.MaterialRaisedButton();
            this.comic_resize = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialDivider2 = new MaterialSkin.Controls.MaterialDivider();
            this.bulk_chapternums = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.bulk_download = new MaterialSkin.Controls.MaterialRaisedButton();
            this.autofindpages = new MaterialSkin.Controls.MaterialCheckBox();
            this.bulk_progress = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.comic_picture)).BeginInit();
            this.SuspendLayout();
            // 
            // comic_picture
            // 
            this.comic_picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.comic_picture.Location = new System.Drawing.Point(12, 75);
            this.comic_picture.Name = "comic_picture";
            this.comic_picture.Size = new System.Drawing.Size(154, 205);
            this.comic_picture.TabIndex = 0;
            this.comic_picture.TabStop = false;
            // 
            // comic_name
            // 
            this.comic_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.comic_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.comic_name.Location = new System.Drawing.Point(172, 75);
            this.comic_name.Name = "comic_name";
            this.comic_name.Size = new System.Drawing.Size(291, 46);
            this.comic_name.TabIndex = 21;
            this.comic_name.Text = "Fetching comic name..";
            // 
            // comic_description
            // 
            this.comic_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.comic_description.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.comic_description.Location = new System.Drawing.Point(172, 121);
            this.comic_description.Name = "comic_description";
            this.comic_description.Size = new System.Drawing.Size(291, 192);
            this.comic_description.TabIndex = 22;
            this.comic_description.Text = "Fetching comic description..";
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(469, 64);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(2, 260);
            this.materialDivider1.TabIndex = 23;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // comic_chapternum
            // 
            this.comic_chapternum.Depth = 0;
            this.comic_chapternum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.comic_chapternum.Hint = "Chapter #";
            this.comic_chapternum.Location = new System.Drawing.Point(480, 75);
            this.comic_chapternum.MaxLength = 32767;
            this.comic_chapternum.MouseState = MaterialSkin.MouseState.HOVER;
            this.comic_chapternum.Name = "comic_chapternum";
            this.comic_chapternum.PasswordChar = '\0';
            this.comic_chapternum.SelectedText = "";
            this.comic_chapternum.SelectionLength = 0;
            this.comic_chapternum.SelectionStart = 0;
            this.comic_chapternum.Size = new System.Drawing.Size(156, 23);
            this.comic_chapternum.TabIndex = 24;
            this.comic_chapternum.TabStop = false;
            this.comic_chapternum.UseSystemPasswordChar = false;
            // 
            // comic_startpagenum
            // 
            this.comic_startpagenum.Depth = 0;
            this.comic_startpagenum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.comic_startpagenum.Hint = "Page #";
            this.comic_startpagenum.Location = new System.Drawing.Point(480, 104);
            this.comic_startpagenum.MaxLength = 32767;
            this.comic_startpagenum.MouseState = MaterialSkin.MouseState.HOVER;
            this.comic_startpagenum.Name = "comic_startpagenum";
            this.comic_startpagenum.PasswordChar = '\0';
            this.comic_startpagenum.SelectedText = "";
            this.comic_startpagenum.SelectionLength = 0;
            this.comic_startpagenum.SelectionStart = 0;
            this.comic_startpagenum.Size = new System.Drawing.Size(60, 23);
            this.comic_startpagenum.TabIndex = 25;
            this.comic_startpagenum.TabStop = false;
            this.comic_startpagenum.UseSystemPasswordChar = false;
            // 
            // comic_endpagenum
            // 
            this.comic_endpagenum.Depth = 0;
            this.comic_endpagenum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.comic_endpagenum.Hint = "Page #";
            this.comic_endpagenum.Location = new System.Drawing.Point(576, 104);
            this.comic_endpagenum.MaxLength = 32767;
            this.comic_endpagenum.MouseState = MaterialSkin.MouseState.HOVER;
            this.comic_endpagenum.Name = "comic_endpagenum";
            this.comic_endpagenum.PasswordChar = '\0';
            this.comic_endpagenum.SelectedText = "";
            this.comic_endpagenum.SelectionLength = 0;
            this.comic_endpagenum.SelectionStart = 0;
            this.comic_endpagenum.Size = new System.Drawing.Size(60, 23);
            this.comic_endpagenum.TabIndex = 26;
            this.comic_endpagenum.TabStop = false;
            this.comic_endpagenum.UseSystemPasswordChar = false;
            // 
            // comic_getlast
            // 
            this.comic_getlast.AutoSize = true;
            this.comic_getlast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comic_getlast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.comic_getlast.Location = new System.Drawing.Point(553, 108);
            this.comic_getlast.Name = "comic_getlast";
            this.comic_getlast.Size = new System.Drawing.Size(10, 13);
            this.comic_getlast.TabIndex = 27;
            this.comic_getlast.Text = "-";
            this.comic_getlast.Click += new System.EventHandler(this.comic_getlast_Click);
            // 
            // comic_download
            // 
            this.comic_download.AutoSize = true;
            this.comic_download.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.comic_download.Depth = 0;
            this.comic_download.Icon = null;
            this.comic_download.Location = new System.Drawing.Point(477, 133);
            this.comic_download.MouseState = MaterialSkin.MouseState.HOVER;
            this.comic_download.Name = "comic_download";
            this.comic_download.Primary = true;
            this.comic_download.Size = new System.Drawing.Size(161, 36);
            this.comic_download.TabIndex = 28;
            this.comic_download.Text = "download chapter";
            this.comic_download.UseVisualStyleBackColor = true;
            this.comic_download.Click += new System.EventHandler(this.comic_download_Click);
            // 
            // comic_resize
            // 
            this.comic_resize.AutoSize = true;
            this.comic_resize.Checked = true;
            this.comic_resize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.comic_resize.Depth = 0;
            this.comic_resize.Font = new System.Drawing.Font("Roboto", 10F);
            this.comic_resize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.comic_resize.Location = new System.Drawing.Point(12, 283);
            this.comic_resize.Margin = new System.Windows.Forms.Padding(0);
            this.comic_resize.MouseLocation = new System.Drawing.Point(-1, -1);
            this.comic_resize.MouseState = MaterialSkin.MouseState.HOVER;
            this.comic_resize.Name = "comic_resize";
            this.comic_resize.Ripple = true;
            this.comic_resize.Size = new System.Drawing.Size(149, 30);
            this.comic_resize.TabIndex = 31;
            this.comic_resize.Text = "Optimize Page Size";
            this.comic_resize.UseVisualStyleBackColor = true;
            // 
            // materialDivider2
            // 
            this.materialDivider2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider2.Depth = 0;
            this.materialDivider2.Location = new System.Drawing.Point(469, 175);
            this.materialDivider2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider2.Name = "materialDivider2";
            this.materialDivider2.Size = new System.Drawing.Size(176, 2);
            this.materialDivider2.TabIndex = 32;
            this.materialDivider2.Text = "materialDivider2";
            // 
            // bulk_chapternums
            // 
            this.bulk_chapternums.Depth = 0;
            this.bulk_chapternums.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.bulk_chapternums.Hint = "Chapter #\'s (1-2, 1-5, ..)";
            this.bulk_chapternums.Location = new System.Drawing.Point(480, 183);
            this.bulk_chapternums.MaxLength = 32767;
            this.bulk_chapternums.MouseState = MaterialSkin.MouseState.HOVER;
            this.bulk_chapternums.Name = "bulk_chapternums";
            this.bulk_chapternums.PasswordChar = '\0';
            this.bulk_chapternums.SelectedText = "";
            this.bulk_chapternums.SelectionLength = 0;
            this.bulk_chapternums.SelectionStart = 0;
            this.bulk_chapternums.Size = new System.Drawing.Size(156, 23);
            this.bulk_chapternums.TabIndex = 33;
            this.bulk_chapternums.TabStop = false;
            this.bulk_chapternums.UseSystemPasswordChar = false;
            // 
            // bulk_download
            // 
            this.bulk_download.AutoSize = true;
            this.bulk_download.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bulk_download.Depth = 0;
            this.bulk_download.Icon = null;
            this.bulk_download.Location = new System.Drawing.Point(473, 212);
            this.bulk_download.MouseState = MaterialSkin.MouseState.HOVER;
            this.bulk_download.Name = "bulk_download";
            this.bulk_download.Primary = true;
            this.bulk_download.Size = new System.Drawing.Size(169, 36);
            this.bulk_download.TabIndex = 34;
            this.bulk_download.Text = "download chapters";
            this.bulk_download.UseVisualStyleBackColor = true;
            this.bulk_download.Click += new System.EventHandler(this.bulk_download_Click);
            // 
            // autofindpages
            // 
            this.autofindpages.AutoSize = true;
            this.autofindpages.Depth = 0;
            this.autofindpages.Font = new System.Drawing.Font("Roboto", 10F);
            this.autofindpages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.autofindpages.Location = new System.Drawing.Point(493, 286);
            this.autofindpages.Margin = new System.Windows.Forms.Padding(0);
            this.autofindpages.MouseLocation = new System.Drawing.Point(-1, -1);
            this.autofindpages.MouseState = MaterialSkin.MouseState.HOVER;
            this.autofindpages.Name = "autofindpages";
            this.autofindpages.Ripple = true;
            this.autofindpages.Size = new System.Drawing.Size(131, 30);
            this.autofindpages.TabIndex = 35;
            this.autofindpages.Text = "Auto Find Pages";
            this.autofindpages.UseVisualStyleBackColor = true;
            this.autofindpages.CheckedChanged += new System.EventHandler(this.autofindpages_CheckedChanged);
            // 
            // bulk_progress
            // 
            this.bulk_progress.Location = new System.Drawing.Point(473, 254);
            this.bulk_progress.Name = "bulk_progress";
            this.bulk_progress.Size = new System.Drawing.Size(169, 10);
            this.bulk_progress.TabIndex = 36;
            this.bulk_progress.Visible = false;
            // 
            // frmDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 325);
            this.Controls.Add(this.bulk_progress);
            this.Controls.Add(this.autofindpages);
            this.Controls.Add(this.bulk_download);
            this.Controls.Add(this.bulk_chapternums);
            this.Controls.Add(this.materialDivider2);
            this.Controls.Add(this.comic_resize);
            this.Controls.Add(this.comic_download);
            this.Controls.Add(this.comic_getlast);
            this.Controls.Add(this.comic_endpagenum);
            this.Controls.Add(this.comic_startpagenum);
            this.Controls.Add(this.comic_chapternum);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.comic_description);
            this.Controls.Add(this.comic_name);
            this.Controls.Add(this.comic_picture);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDownload";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Download";
            ((System.ComponentModel.ISupportInitialize)(this.comic_picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox comic_picture;
        private System.Windows.Forms.Label comic_name;
        private System.Windows.Forms.Label comic_description;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialSingleLineTextField comic_chapternum;
        private MaterialSkin.Controls.MaterialSingleLineTextField comic_startpagenum;
        private MaterialSkin.Controls.MaterialSingleLineTextField comic_endpagenum;
        private System.Windows.Forms.Label comic_getlast;
        private MaterialSkin.Controls.MaterialRaisedButton comic_download;
        private MaterialSkin.Controls.MaterialCheckBox comic_resize;
        private MaterialSkin.Controls.MaterialDivider materialDivider2;
        private MaterialSkin.Controls.MaterialSingleLineTextField bulk_chapternums;
        private MaterialSkin.Controls.MaterialRaisedButton bulk_download;
        private MaterialSkin.Controls.MaterialCheckBox autofindpages;
        private System.Windows.Forms.ProgressBar bulk_progress;
    }
}