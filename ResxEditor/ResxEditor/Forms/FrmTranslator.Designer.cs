namespace ResxEditor.Forms
{
    partial class FrmTranslator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTranslator));
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.cboxFrom = new System.Windows.Forms.ComboBox();
            this.btnSwap = new System.Windows.Forms.Button();
            this.lblLanguages = new System.Windows.Forms.Label();
            this.llblClearAll = new System.Windows.Forms.LinkLabel();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.cboxTo = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.llblCopy1 = new System.Windows.Forms.LinkLabel();
            this.llblCopy2 = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(184, 4);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(175, 142);
            this.txtResult.TabIndex = 1;
            // 
            // txtSource
            // 
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.Location = new System.Drawing.Point(4, 4);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(174, 142);
            this.txtSource.TabIndex = 0;
            this.txtSource.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSource_KeyUp);
            // 
            // cboxFrom
            // 
            this.cboxFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboxFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboxFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxFrom.FormattingEnabled = true;
            this.cboxFrom.Location = new System.Drawing.Point(3, 4);
            this.cboxFrom.Name = "cboxFrom";
            this.cboxFrom.Size = new System.Drawing.Size(120, 21);
            this.cboxFrom.TabIndex = 0;
            this.cboxFrom.SelectedIndexChanged += new System.EventHandler(this.cboxFrom_SelectedIndexChanged);
            // 
            // btnSwap
            // 
            this.btnSwap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSwap.AutoSize = true;
            this.btnSwap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSwap.Location = new System.Drawing.Point(129, 3);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(59, 23);
            this.btnSwap.TabIndex = 1;
            this.btnSwap.Text = "btnSwap";
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // lblLanguages
            // 
            this.lblLanguages.AutoSize = true;
            this.lblLanguages.Location = new System.Drawing.Point(12, 9);
            this.lblLanguages.Name = "lblLanguages";
            this.lblLanguages.Size = new System.Drawing.Size(70, 13);
            this.lblLanguages.TabIndex = 0;
            this.lblLanguages.Text = "lblLanguages";
            // 
            // llblClearAll
            // 
            this.llblClearAll.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.llblClearAll.AutoSize = true;
            this.llblClearAll.Location = new System.Drawing.Point(224, 8);
            this.llblClearAll.Name = "llblClearAll";
            this.llblClearAll.Size = new System.Drawing.Size(54, 13);
            this.llblClearAll.TabIndex = 1;
            this.llblClearAll.TabStop = true;
            this.llblClearAll.Text = "llblClearAll";
            this.llblClearAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblClearAll_LinkClicked);
            // 
            // btnTranslate
            // 
            this.btnTranslate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnTranslate.AutoSize = true;
            this.btnTranslate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTranslate.Location = new System.Drawing.Point(284, 3);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(76, 23);
            this.btnTranslate.TabIndex = 0;
            this.btnTranslate.Text = "btnTranslate";
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // cboxTo
            // 
            this.cboxTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboxTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboxTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxTo.FormattingEnabled = true;
            this.cboxTo.Location = new System.Drawing.Point(194, 4);
            this.cboxTo.Name = "cboxTo";
            this.cboxTo.Size = new System.Drawing.Size(120, 21);
            this.cboxTo.TabIndex = 2;
            this.cboxTo.SelectedIndexChanged += new System.EventHandler(this.cboxTo_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.cboxFrom, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSwap, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboxTo, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(360, 30);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.txtSource, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtResult, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.llblCopy1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.llblCopy2, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 61);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(363, 163);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // llblCopy1
            // 
            this.llblCopy1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.llblCopy1.AutoSize = true;
            this.llblCopy1.Location = new System.Drawing.Point(129, 149);
            this.llblCopy1.Name = "llblCopy1";
            this.llblCopy1.Size = new System.Drawing.Size(49, 13);
            this.llblCopy1.TabIndex = 2;
            this.llblCopy1.TabStop = true;
            this.llblCopy1.Text = "llblCopy1";
            this.llblCopy1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblCopy1_LinkClicked);
            // 
            // llblCopy2
            // 
            this.llblCopy2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.llblCopy2.AutoSize = true;
            this.llblCopy2.Location = new System.Drawing.Point(310, 149);
            this.llblCopy2.Name = "llblCopy2";
            this.llblCopy2.Size = new System.Drawing.Size(49, 13);
            this.llblCopy2.TabIndex = 3;
            this.llblCopy2.TabStop = true;
            this.llblCopy2.Text = "llblCopy2";
            this.llblCopy2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblCopy2_LinkClicked);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.llblClearAll, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnTranslate, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 227);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(363, 30);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // FrmTranslator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 266);
            this.Controls.Add(this.lblLanguages);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "FrmTranslator";
            this.Text = "FrmTranslator";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmTranslator_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTranslator_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboxFrom;
        private System.Windows.Forms.Button btnSwap;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Label lblLanguages;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.LinkLabel llblClearAll;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.ComboBox cboxTo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.LinkLabel llblCopy1;
        private System.Windows.Forms.LinkLabel llblCopy2;
    }
}