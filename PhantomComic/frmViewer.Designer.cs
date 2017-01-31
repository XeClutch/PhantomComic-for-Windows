namespace PhantomComic
{
    partial class frmViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewer));
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            chapterselect = new System.Windows.Forms.ComboBox();
            this.seperatorlbl = new System.Windows.Forms.Label();
            this.pageselect = new System.Windows.Forms.ComboBox();
            this.pageend = new System.Windows.Forms.Label();
            this.page_next = new System.Windows.Forms.PictureBox();
            this.page_previous = new System.Windows.Forms.PictureBox();
            this.page_picture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.page_next)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.page_previous)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.page_picture)).BeginInit();
            this.SuspendLayout();
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(0, 106);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(665, 2);
            this.materialDivider1.TabIndex = 0;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // chapterselect
            // 
            chapterselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            chapterselect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            chapterselect.FormattingEnabled = true;
            chapterselect.Location = new System.Drawing.Point(12, 75);
            chapterselect.Name = "chapterselect";
            chapterselect.Size = new System.Drawing.Size(121, 21);
            chapterselect.TabIndex = 1;
            chapterselect.SelectedIndexChanged += new System.EventHandler(this.chapterselect_SelectedIndexChanged);
            // 
            // seperatorlbl
            // 
            this.seperatorlbl.AutoSize = true;
            this.seperatorlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.seperatorlbl.Location = new System.Drawing.Point(139, 78);
            this.seperatorlbl.Name = "seperatorlbl";
            this.seperatorlbl.Size = new System.Drawing.Size(10, 13);
            this.seperatorlbl.TabIndex = 4;
            this.seperatorlbl.Text = "-";
            // 
            // pageselect
            // 
            this.pageselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pageselect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.pageselect.FormattingEnabled = true;
            this.pageselect.Location = new System.Drawing.Point(155, 75);
            this.pageselect.Name = "pageselect";
            this.pageselect.Size = new System.Drawing.Size(121, 21);
            this.pageselect.TabIndex = 3;
            this.pageselect.SelectedIndexChanged += new System.EventHandler(this.pageselect_SelectedIndexChanged);
            // 
            // pageend
            // 
            this.pageend.AutoSize = true;
            this.pageend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.pageend.Location = new System.Drawing.Point(282, 78);
            this.pageend.Name = "pageend";
            this.pageend.Size = new System.Drawing.Size(39, 13);
            this.pageend.TabIndex = 5;
            this.pageend.Text = "/ 9001";
            // 
            // page_next
            // 
            this.page_next.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("page_next.BackgroundImage")));
            this.page_next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.page_next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.page_next.Location = new System.Drawing.Point(608, 542);
            this.page_next.Name = "page_next";
            this.page_next.Size = new System.Drawing.Size(53, 69);
            this.page_next.TabIndex = 19;
            this.page_next.TabStop = false;
            this.page_next.Click += new System.EventHandler(this.page_next_Click);
            // 
            // page_previous
            // 
            this.page_previous.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("page_previous.BackgroundImage")));
            this.page_previous.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.page_previous.Cursor = System.Windows.Forms.Cursors.Hand;
            this.page_previous.Location = new System.Drawing.Point(4, 542);
            this.page_previous.Name = "page_previous";
            this.page_previous.Size = new System.Drawing.Size(53, 69);
            this.page_previous.TabIndex = 18;
            this.page_previous.TabStop = false;
            this.page_previous.Click += new System.EventHandler(this.page_previous_Click);
            // 
            // page_picture
            // 
            this.page_picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.page_picture.Location = new System.Drawing.Point(63, 114);
            this.page_picture.Name = "page_picture";
            this.page_picture.Size = new System.Drawing.Size(539, 497);
            this.page_picture.TabIndex = 20;
            this.page_picture.TabStop = false;
            // 
            // frmViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 615);
            this.Controls.Add(this.page_picture);
            this.Controls.Add(this.page_next);
            this.Controls.Add(this.page_previous);
            this.Controls.Add(this.pageend);
            this.Controls.Add(this.seperatorlbl);
            this.Controls.Add(this.pageselect);
            this.Controls.Add(chapterselect);
            this.Controls.Add(this.materialDivider1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmViewer";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.page_next)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.page_previous)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.page_picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        public static System.Windows.Forms.ComboBox chapterselect;
        private System.Windows.Forms.Label seperatorlbl;
        private System.Windows.Forms.ComboBox pageselect;
        private System.Windows.Forms.Label pageend;
        private System.Windows.Forms.PictureBox page_next;
        private System.Windows.Forms.PictureBox page_previous;
        private System.Windows.Forms.PictureBox page_picture;
    }
}