namespace ResxEditor.Forms
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tscContainer = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gbComment = new System.Windows.Forms.GroupBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.gbValue = new System.Windows.Forms.GroupBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.ssBottom = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspMain = new System.Windows.Forms.ToolStrip();
            this.tsbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnKeys = new System.Windows.Forms.ToolStripButton();
            this.tsbtnFText = new System.Windows.Forms.ToolStripButton();
            this.tsbtnFAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnHDiffs = new System.Windows.Forms.ToolStripButton();
            this.tsbtnHEquals = new System.Windows.Forms.ToolStripButton();
            this.tsbtnHText = new System.Windows.Forms.ToolStripButton();
            this.tsbtnClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnTranslator = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnAbout = new System.Windows.Forms.ToolStripButton();
            this.imgListMain = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tscContainer.ContentPanel.SuspendLayout();
            this.tscContainer.TopToolStripPanel.SuspendLayout();
            this.tscContainer.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gbComment.SuspendLayout();
            this.gbValue.SuspendLayout();
            this.ssBottom.SuspendLayout();
            this.tspMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowDrop = true;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeight = 30;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ScrollBar;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(584, 106);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            this.dataGridView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dataGridView_SortCompare);
            this.dataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView_CellPainting);
            this.dataGridView.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragEnter);
            this.dataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEnter);
            this.dataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragDrop);
            // 
            // tscContainer
            // 
            // 
            // tscContainer.ContentPanel
            // 
            this.tscContainer.ContentPanel.Controls.Add(this.splitContainer1);
            this.tscContainer.ContentPanel.Controls.Add(this.ssBottom);
            this.tscContainer.ContentPanel.Size = new System.Drawing.Size(584, 237);
            this.tscContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscContainer.Location = new System.Drawing.Point(0, 0);
            this.tscContainer.Name = "tscContainer";
            this.tscContainer.Size = new System.Drawing.Size(584, 262);
            this.tscContainer.TabIndex = 2;
            // 
            // tscContainer.TopToolStripPanel
            // 
            this.tscContainer.TopToolStripPanel.Controls.Add(this.tspMain);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(584, 215);
            this.splitContainer1.SplitterDistance = 106;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gbComment);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gbValue);
            this.splitContainer2.Size = new System.Drawing.Size(584, 107);
            this.splitContainer2.SplitterDistance = 200;
            this.splitContainer2.SplitterWidth = 2;
            this.splitContainer2.TabIndex = 0;
            // 
            // gbComment
            // 
            this.gbComment.Controls.Add(this.txtComment);
            this.gbComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbComment.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbComment.Location = new System.Drawing.Point(0, 0);
            this.gbComment.Name = "gbComment";
            this.gbComment.Size = new System.Drawing.Size(200, 107);
            this.gbComment.TabIndex = 0;
            this.gbComment.TabStop = false;
            this.gbComment.Text = "gbComment";
            // 
            // txtComment
            // 
            this.txtComment.AcceptsReturn = true;
            this.txtComment.AcceptsTab = true;
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Enabled = false;
            this.txtComment.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment.Location = new System.Drawing.Point(12, 22);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtComment.Size = new System.Drawing.Size(182, 79);
            this.txtComment.TabIndex = 0;
            this.txtComment.Leave += new System.EventHandler(this.txtComment_Leave);
            // 
            // gbValue
            // 
            this.gbValue.Controls.Add(this.txtValue);
            this.gbValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbValue.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbValue.Location = new System.Drawing.Point(0, 0);
            this.gbValue.Name = "gbValue";
            this.gbValue.Size = new System.Drawing.Size(382, 107);
            this.gbValue.TabIndex = 1;
            this.gbValue.TabStop = false;
            this.gbValue.Text = "gbValue";
            // 
            // txtValue
            // 
            this.txtValue.AcceptsReturn = true;
            this.txtValue.AcceptsTab = true;
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Enabled = false;
            this.txtValue.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(6, 22);
            this.txtValue.Multiline = true;
            this.txtValue.Name = "txtValue";
            this.txtValue.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtValue.Size = new System.Drawing.Size(364, 79);
            this.txtValue.TabIndex = 0;
            this.txtValue.Leave += new System.EventHandler(this.txtValue_Leave);
            // 
            // ssBottom
            // 
            this.ssBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.ssBottom.Location = new System.Drawing.Point(0, 215);
            this.ssBottom.Name = "ssBottom";
            this.ssBottom.Size = new System.Drawing.Size(584, 22);
            this.ssBottom.TabIndex = 2;
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // tspMain
            // 
            this.tspMain.Dock = System.Windows.Forms.DockStyle.None;
            this.tspMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tspMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnOpen,
            this.tsbtnSave,
            this.toolStripSeparator1,
            this.tsbtnKeys,
            this.tsbtnFText,
            this.tsbtnFAll,
            this.toolStripSeparator2,
            this.tsbtnHDiffs,
            this.tsbtnHEquals,
            this.tsbtnHText,
            this.tsbtnClear,
            this.toolStripSeparator3,
            this.tsbtnTranslator,
            this.toolStripSeparator4,
            this.tsbtnSettings,
            this.toolStripSeparator5,
            this.tsbtnAbout});
            this.tspMain.Location = new System.Drawing.Point(3, 0);
            this.tspMain.Name = "tspMain";
            this.tspMain.Size = new System.Drawing.Size(316, 25);
            this.tspMain.TabIndex = 0;
            this.tspMain.Text = "tspMain";
            // 
            // tsbtnOpen
            // 
            this.tsbtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpen.Name = "tsbtnOpen";
            this.tsbtnOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbtnOpen.Text = "tsbtnOpen";
            this.tsbtnOpen.Click += new System.EventHandler(this.tsbtnOpen_Click);
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(23, 22);
            this.tsbtnSave.Text = "tsbtnSave";
            this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnKeys
            // 
            this.tsbtnKeys.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnKeys.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnKeys.Name = "tsbtnKeys";
            this.tsbtnKeys.Size = new System.Drawing.Size(23, 22);
            this.tsbtnKeys.Text = "tsbtnKeys";
            this.tsbtnKeys.Click += new System.EventHandler(this.tsbtnKeys_Click);
            // 
            // tsbtnFText
            // 
            this.tsbtnFText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnFText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFText.Name = "tsbtnFText";
            this.tsbtnFText.Size = new System.Drawing.Size(23, 22);
            this.tsbtnFText.Text = "tsbtnFText";
            this.tsbtnFText.Click += new System.EventHandler(this.tsbtnFText_Click);
            // 
            // tsbtnFAll
            // 
            this.tsbtnFAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnFAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFAll.Name = "tsbtnFAll";
            this.tsbtnFAll.Size = new System.Drawing.Size(23, 22);
            this.tsbtnFAll.Text = "tsbtnFAll";
            this.tsbtnFAll.Click += new System.EventHandler(this.tsbtnFAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnHDiffs
            // 
            this.tsbtnHDiffs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnHDiffs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnHDiffs.Name = "tsbtnHDiffs";
            this.tsbtnHDiffs.Size = new System.Drawing.Size(23, 22);
            this.tsbtnHDiffs.Text = "tsbtnHDiffs";
            this.tsbtnHDiffs.ToolTipText = "tsbtnHDiffs";
            this.tsbtnHDiffs.Click += new System.EventHandler(this.tsbtnHDiffs_Click);
            // 
            // tsbtnHEquals
            // 
            this.tsbtnHEquals.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnHEquals.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnHEquals.Name = "tsbtnHEquals";
            this.tsbtnHEquals.Size = new System.Drawing.Size(23, 22);
            this.tsbtnHEquals.Text = "tsbtnHEquals";
            this.tsbtnHEquals.Click += new System.EventHandler(this.tsbtnHEquals_Click);
            // 
            // tsbtnHText
            // 
            this.tsbtnHText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnHText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnHText.Name = "tsbtnHText";
            this.tsbtnHText.Size = new System.Drawing.Size(23, 22);
            this.tsbtnHText.Text = "tsbtnHText";
            this.tsbtnHText.Click += new System.EventHandler(this.tsbtnHText_Click);
            // 
            // tsbtnClear
            // 
            this.tsbtnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClear.Name = "tsbtnClear";
            this.tsbtnClear.Size = new System.Drawing.Size(23, 22);
            this.tsbtnClear.Text = "tsbtnClear";
            this.tsbtnClear.Click += new System.EventHandler(this.tsbtnClear_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnTranslator
            // 
            this.tsbtnTranslator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnTranslator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnTranslator.Name = "tsbtnTranslator";
            this.tsbtnTranslator.Size = new System.Drawing.Size(23, 22);
            this.tsbtnTranslator.Click += new System.EventHandler(this.tsbtnTranslator_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnSettings
            // 
            this.tsbtnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSettings.Name = "tsbtnSettings";
            this.tsbtnSettings.Size = new System.Drawing.Size(23, 22);
            this.tsbtnSettings.Text = "tsbtnSettings";
            this.tsbtnSettings.Click += new System.EventHandler(this.tsbtnSettings_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnAbout
            // 
            this.tsbtnAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAbout.Name = "tsbtnAbout";
            this.tsbtnAbout.Size = new System.Drawing.Size(23, 22);
            this.tsbtnAbout.Text = "tsbtnAbout";
            this.tsbtnAbout.Click += new System.EventHandler(this.tsbtnAbout_Click);
            // 
            // imgListMain
            // 
            this.imgListMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgListMain.ImageSize = new System.Drawing.Size(32, 32);
            this.imgListMain.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.Controls.Add(this.tscContainer);
            this.MinimumSize = new System.Drawing.Size(400, 100);
            this.Name = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Move += new System.EventHandler(this.FrmMain_Move);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.FrmMain_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tscContainer.ContentPanel.ResumeLayout(false);
            this.tscContainer.ContentPanel.PerformLayout();
            this.tscContainer.TopToolStripPanel.ResumeLayout(false);
            this.tscContainer.TopToolStripPanel.PerformLayout();
            this.tscContainer.ResumeLayout(false);
            this.tscContainer.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.gbComment.ResumeLayout(false);
            this.gbComment.PerformLayout();
            this.gbValue.ResumeLayout(false);
            this.gbValue.PerformLayout();
            this.ssBottom.ResumeLayout(false);
            this.ssBottom.PerformLayout();
            this.tspMain.ResumeLayout(false);
            this.tspMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripContainer tscContainer;
        private System.Windows.Forms.StatusStrip ssBottom;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.ImageList imgListMain;
        private System.Windows.Forms.ToolStrip tspMain;
        private System.Windows.Forms.ToolStripButton tsbtnOpen;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnHDiffs;
        private System.Windows.Forms.ToolStripButton tsbtnHEquals;
        private System.Windows.Forms.ToolStripButton tsbtnHText;
        private System.Windows.Forms.ToolStripButton tsbtnClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnAbout;
        private System.Windows.Forms.ToolStripButton tsbtnKeys;
        private System.Windows.Forms.ToolStripButton tsbtnFText;
        private System.Windows.Forms.ToolStripButton tsbtnFAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox gbComment;
        private System.Windows.Forms.GroupBox gbValue;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ToolStripButton tsbtnTranslator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}

