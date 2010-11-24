namespace ResxEditor.Forms
{
    partial class FrmFind
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTextToFind = new System.Windows.Forms.Label();
            this.lblReplaceWith = new System.Windows.Forms.Label();
            this.txtTextToFind = new System.Windows.Forms.TextBox();
            this.txtReplaceWith = new System.Windows.Forms.TextBox();
            this.btnReplace = new System.Windows.Forms.Button();
            this.lblSeparator = new System.Windows.Forms.Label();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.btnFindPrevious = new System.Windows.Forms.Button();
            this.btnReplaceAll = new System.Windows.Forms.Button();
            this.ckbCaseSensitive = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblTextToFind, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblReplaceWith, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTextToFind, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtReplaceWith, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnReplace, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblSeparator, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnFindNext, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnFindPrevious, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnReplaceAll, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.ckbCaseSensitive, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(364, 162);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTextToFind
            // 
            this.lblTextToFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTextToFind.AutoSize = true;
            this.lblTextToFind.Location = new System.Drawing.Point(16, 5);
            this.lblTextToFind.Name = "lblTextToFind";
            this.lblTextToFind.Size = new System.Drawing.Size(71, 13);
            this.lblTextToFind.TabIndex = 0;
            this.lblTextToFind.Text = "lblTextToFind";
            // 
            // lblReplaceWith
            // 
            this.lblReplaceWith.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReplaceWith.AutoSize = true;
            this.lblReplaceWith.Location = new System.Drawing.Point(8, 54);
            this.lblReplaceWith.Name = "lblReplaceWith";
            this.lblReplaceWith.Size = new System.Drawing.Size(79, 13);
            this.lblReplaceWith.TabIndex = 2;
            this.lblReplaceWith.Text = "lblReplaceWith";
            // 
            // txtTextToFind
            // 
            this.txtTextToFind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtTextToFind, 5);
            this.txtTextToFind.Location = new System.Drawing.Point(93, 8);
            this.txtTextToFind.Multiline = true;
            this.txtTextToFind.Name = "txtTextToFind";
            this.txtTextToFind.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTextToFind.Size = new System.Drawing.Size(263, 43);
            this.txtTextToFind.TabIndex = 1;
            // 
            // txtReplaceWith
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtReplaceWith, 5);
            this.txtReplaceWith.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReplaceWith.Location = new System.Drawing.Point(93, 57);
            this.txtReplaceWith.Multiline = true;
            this.txtReplaceWith.Name = "txtReplaceWith";
            this.txtReplaceWith.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReplaceWith.Size = new System.Drawing.Size(263, 43);
            this.txtReplaceWith.TabIndex = 3;
            // 
            // btnReplace
            // 
            this.btnReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReplace.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.btnReplace, 2);
            this.btnReplace.Location = new System.Drawing.Point(8, 131);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(80, 23);
            this.btnReplace.TabIndex = 7;
            this.btnReplace.Text = "btnReplace";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // lblSeparator
            // 
            this.lblSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.lblSeparator, 6);
            this.lblSeparator.Location = new System.Drawing.Point(8, 126);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(348, 2);
            this.lblSeparator.TabIndex = 2;
            // 
            // btnFindNext
            // 
            this.btnFindNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindNext.AutoSize = true;
            this.btnFindNext.Location = new System.Drawing.Point(282, 131);
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(74, 23);
            this.btnFindNext.TabIndex = 5;
            this.btnFindNext.Text = "btnFindNext";
            this.btnFindNext.UseVisualStyleBackColor = true;
            this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
            // 
            // btnFindPrevious
            // 
            this.btnFindPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindPrevious.Location = new System.Drawing.Point(196, 131);
            this.btnFindPrevious.Name = "btnFindPrevious";
            this.btnFindPrevious.Size = new System.Drawing.Size(80, 23);
            this.btnFindPrevious.TabIndex = 6;
            this.btnFindPrevious.Text = "btnFindPrevious";
            this.btnFindPrevious.UseVisualStyleBackColor = true;
            this.btnFindPrevious.Click += new System.EventHandler(this.btnFindPrevious_Click);
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReplaceAll.AutoSize = true;
            this.btnReplaceAll.Location = new System.Drawing.Point(94, 131);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(83, 23);
            this.btnReplaceAll.TabIndex = 8;
            this.btnReplaceAll.Text = "btnReplaceAll";
            this.btnReplaceAll.UseVisualStyleBackColor = true;
            this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
            // 
            // ckbCaseSensitive
            // 
            this.ckbCaseSensitive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbCaseSensitive.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.ckbCaseSensitive, 5);
            this.ckbCaseSensitive.Location = new System.Drawing.Point(93, 106);
            this.ckbCaseSensitive.Name = "ckbCaseSensitive";
            this.ckbCaseSensitive.Size = new System.Drawing.Size(263, 17);
            this.ckbCaseSensitive.TabIndex = 4;
            this.ckbCaseSensitive.Text = "ckbCaseSensitive";
            this.ckbCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // FrmFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 162);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(380, 200);
            this.Name = "FrmFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmFind";
            this.Load += new System.EventHandler(this.FrmFind_Load);
            this.Move += new System.EventHandler(this.FrmFind_Move);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFind_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.FrmFind_ResizeEnd);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTextToFind;
        private System.Windows.Forms.Label lblReplaceWith;
        private System.Windows.Forms.Label lblSeparator;
        private System.Windows.Forms.TextBox txtTextToFind;
        private System.Windows.Forms.TextBox txtReplaceWith;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnReplaceAll;
        private System.Windows.Forms.Button btnFindPrevious;
        private System.Windows.Forms.Button btnFindNext;
        private System.Windows.Forms.CheckBox ckbCaseSensitive;
    }
}