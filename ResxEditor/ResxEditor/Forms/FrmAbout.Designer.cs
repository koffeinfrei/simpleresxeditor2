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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
            this.tlpAbout = new System.Windows.Forms.TableLayoutPanel();
            this.lblCoded = new System.Windows.Forms.Label();
            this.llblAuthor = new System.Windows.Forms.LinkLabel();
            this.lblTranslated = new System.Windows.Forms.Label();
            this.btnWebsite = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tlpAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpAbout
            // 
            this.tlpAbout.ColumnCount = 2;
            this.tlpAbout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAbout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAbout.Controls.Add(this.lblCoded, 0, 1);
            this.tlpAbout.Controls.Add(this.llblAuthor, 0, 2);
            this.tlpAbout.Controls.Add(this.lblTranslated, 0, 3);
            this.tlpAbout.Controls.Add(this.btnWebsite, 0, 5);
            this.tlpAbout.Controls.Add(this.btnClose, 1, 5);
            this.tlpAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAbout.Location = new System.Drawing.Point(0, 0);
            this.tlpAbout.Name = "tlpAbout";
            this.tlpAbout.RowCount = 6;
            this.tlpAbout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpAbout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpAbout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpAbout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpAbout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpAbout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpAbout.Size = new System.Drawing.Size(232, 186);
            this.tlpAbout.TabIndex = 0;
            // 
            // lblCoded
            // 
            this.lblCoded.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCoded.AutoSize = true;
            this.tlpAbout.SetColumnSpan(this.lblCoded, 2);
            this.lblCoded.Location = new System.Drawing.Point(3, 38);
            this.lblCoded.Name = "lblCoded";
            this.lblCoded.Size = new System.Drawing.Size(226, 13);
            this.lblCoded.TabIndex = 2;
            this.lblCoded.Text = "lblCoded";
            // 
            // llblAuthor
            // 
            this.llblAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.llblAuthor.AutoSize = true;
            this.tlpAbout.SetColumnSpan(this.llblAuthor, 2);
            this.llblAuthor.Location = new System.Drawing.Point(3, 68);
            this.llblAuthor.Name = "llblAuthor";
            this.llblAuthor.Size = new System.Drawing.Size(226, 13);
            this.llblAuthor.TabIndex = 3;
            this.llblAuthor.TabStop = true;
            this.llblAuthor.Text = "llblAuthor";
            this.llblAuthor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblAuthor_LinkClicked);
            // 
            // lblTranslated
            // 
            this.lblTranslated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTranslated.AutoSize = true;
            this.tlpAbout.SetColumnSpan(this.lblTranslated, 2);
            this.lblTranslated.Location = new System.Drawing.Point(3, 98);
            this.lblTranslated.Name = "lblTranslated";
            this.lblTranslated.Size = new System.Drawing.Size(226, 13);
            this.lblTranslated.TabIndex = 4;
            this.lblTranslated.Text = "lblTranslated";
            // 
            // btnWebsite
            // 
            this.btnWebsite.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnWebsite.AutoSize = true;
            this.btnWebsite.Location = new System.Drawing.Point(3, 156);
            this.btnWebsite.Name = "btnWebsite";
            this.btnWebsite.Size = new System.Drawing.Size(75, 23);
            this.btnWebsite.TabIndex = 0;
            this.btnWebsite.Text = "btnWebsite";
            this.btnWebsite.UseVisualStyleBackColor = true;
            this.btnWebsite.Click += new System.EventHandler(this.btnWebsite_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.AutoSize = true;
            this.btnClose.Location = new System.Drawing.Point(154, 156);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 186);
            this.Controls.Add(this.tlpAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmAbout";
            this.Load += new System.EventHandler(this.FrmAbout_Load);
            this.tlpAbout.ResumeLayout(false);
            this.tlpAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpAbout;
        private System.Windows.Forms.Button btnWebsite;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCoded;
        private System.Windows.Forms.LinkLabel llblAuthor;
        private System.Windows.Forms.Label lblTranslated;
    }
}