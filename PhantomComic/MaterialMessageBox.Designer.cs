namespace PhantomComic
{
    partial class MaterialMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialMessageBox));
            this.message = new System.Windows.Forms.Label();
            this.ok = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // message
            // 
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.message.Location = new System.Drawing.Point(12, 75);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(321, 64);
            this.message.TabIndex = 23;
            this.message.Text = "message";
            // 
            // ok
            // 
            this.ok.AutoSize = true;
            this.ok.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ok.Depth = 0;
            this.ok.Icon = null;
            this.ok.Location = new System.Drawing.Point(294, 142);
            this.ok.MouseState = MaterialSkin.MouseState.HOVER;
            this.ok.Name = "ok";
            this.ok.Primary = true;
            this.ok.Size = new System.Drawing.Size(39, 36);
            this.ok.TabIndex = 24;
            this.ok.Text = "ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // MaterialMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 186);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.message);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialMessageBox";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MaterialMessageBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label message;
        private MaterialSkin.Controls.MaterialRaisedButton ok;
    }
}