namespace ResxEditor.Forms
{
    partial class FrmAbout
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
            this.lblCoded = new System.Windows.Forms.Label();
            this.llblAuthor = new System.Windows.Forms.LinkLabel();
            this.lblTranslated = new System.Windows.Forms.Label();
            this.btnWebsite = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDonate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCoded
            // 
            this.lblCoded.AutoSize = true;
            this.lblCoded.Location = new System.Drawing.Point(157, 23);
            this.lblCoded.Name = "lblCoded";
            this.lblCoded.Size = new System.Drawing.Size(48, 13);
            this.lblCoded.TabIndex = 0;
            this.lblCoded.Text = "lblCoded";
            // 
            // llblAuthor
            // 
            this.llblAuthor.AutoSize = true;
            this.llblAuthor.Location = new System.Drawing.Point(157, 46);
            this.llblAuthor.Name = "llblAuthor";
            this.llblAuthor.Size = new System.Drawing.Size(50, 13);
            this.llblAuthor.TabIndex = 1;
            this.llblAuthor.TabStop = true;
            this.llblAuthor.Text = "llblAuthor";
            this.llblAuthor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblAuthor_LinkClicked);
            // 
            // lblTranslated
            // 
            this.lblTranslated.AutoSize = true;
            this.lblTranslated.Location = new System.Drawing.Point(157, 69);
            this.lblTranslated.Name = "lblTranslated";
            this.lblTranslated.Size = new System.Drawing.Size(67, 13);
            this.lblTranslated.TabIndex = 2;
            this.lblTranslated.Text = "lblTranslated";
            // 
            // btnWebsite
            // 
            this.btnWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWebsite.AutoSize = true;
            this.btnWebsite.Location = new System.Drawing.Point(266, 117);
            this.btnWebsite.Name = "btnWebsite";
            this.btnWebsite.Size = new System.Drawing.Size(75, 23);
            this.btnWebsite.TabIndex = 4;
            this.btnWebsite.Text = "btnWebsite";
            this.btnWebsite.UseVisualStyleBackColor = true;
            this.btnWebsite.Click += new System.EventHandler(this.btnWebsite_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.Location = new System.Drawing.Point(347, 117);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ResxEditor.Properties.Resources.Logo128;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnDonate
            // 
            this.btnDonate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDonate.AutoSize = true;
            this.btnDonate.Location = new System.Drawing.Point(185, 117);
            this.btnDonate.Name = "btnDonate";
            this.btnDonate.Size = new System.Drawing.Size(75, 23);
            this.btnDonate.TabIndex = 3;
            this.btnDonate.Text = "btnDonate";
            this.btnDonate.UseVisualStyleBackColor = true;
            this.btnDonate.Click += new System.EventHandler(this.btnDonate_Click);
            // 
            // FrmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 152);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCoded);
            this.Controls.Add(this.llblAuthor);
            this.Controls.Add(this.lblTranslated);
            this.Controls.Add(this.btnDonate);
            this.Controls.Add(this.btnWebsite);
            this.Controls.Add(this.btnClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 190);
            this.Name = "FrmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmAbout";
            this.Load += new System.EventHandler(this.FrmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWebsite;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCoded;
        private System.Windows.Forms.LinkLabel llblAuthor;
        private System.Windows.Forms.Label lblTranslated;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDonate;
    }
}