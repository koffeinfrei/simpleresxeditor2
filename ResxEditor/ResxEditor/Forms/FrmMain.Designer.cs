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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tscContainer = new System.Windows.Forms.ToolStripContainer();
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
            this.tsbtnSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnAbout = new System.Windows.Forms.ToolStripButton();
            this.imgListMain = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tscContainer.ContentPanel.SuspendLayout();
            this.tscContainer.TopToolStripPanel.SuspendLayout();
            this.tscContainer.SuspendLayout();
            this.ssBottom.SuspendLayout();
            this.tspMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowDrop = true;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(592, 212);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            this.dataGridView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dataGridView_SortCompare);
            this.dataGridView.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragEnter);
            this.dataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragDrop);
            // 
            // tscContainer
            // 
            // 
            // tscContainer.ContentPanel
            // 
            this.tscContainer.ContentPanel.Controls.Add(this.dataGridView);
            this.tscContainer.ContentPanel.Controls.Add(this.ssBottom);
            this.tscContainer.ContentPanel.Size = new System.Drawing.Size(592, 234);
            this.tscContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscContainer.Location = new System.Drawing.Point(0, 0);
            this.tscContainer.Name = "tscContainer";
            this.tscContainer.Size = new System.Drawing.Size(592, 273);
            this.tscContainer.TabIndex = 2;
            // 
            // tscContainer.TopToolStripPanel
            // 
            this.tscContainer.TopToolStripPanel.Controls.Add(this.tspMain);
            // 
            // ssBottom
            // 
            this.ssBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.ssBottom.Location = new System.Drawing.Point(0, 212);
            this.ssBottom.Name = "ssBottom";
            this.ssBottom.Size = new System.Drawing.Size(592, 22);
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
            this.tsbtnSettings,
            this.toolStripSeparator4,
            this.tsbtnAbout});
            this.tspMain.Location = new System.Drawing.Point(3, 0);
            this.tspMain.Name = "tspMain";
            this.tspMain.Size = new System.Drawing.Size(432, 39);
            this.tspMain.TabIndex = 3;
            this.tspMain.Text = "tspMain";
            // 
            // tsbtnOpen
            // 
            this.tsbtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOpen.Image")));
            this.tsbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpen.Name = "tsbtnOpen";
            this.tsbtnOpen.Size = new System.Drawing.Size(36, 36);
            this.tsbtnOpen.Text = "tsbtnOpen";
            this.tsbtnOpen.Click += new System.EventHandler(this.tsbtnOpen_Click);
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSave.Image")));
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(36, 36);
            this.tsbtnSave.Text = "tsbtnSave";
            this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnKeys
            // 
            this.tsbtnKeys.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnKeys.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnKeys.Image")));
            this.tsbtnKeys.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnKeys.Name = "tsbtnKeys";
            this.tsbtnKeys.Size = new System.Drawing.Size(36, 36);
            this.tsbtnKeys.Text = "tsbtnKeys";
            this.tsbtnKeys.Click += new System.EventHandler(this.tsbtnKeys_Click);
            // 
            // tsbtnFText
            // 
            this.tsbtnFText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnFText.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFText.Image")));
            this.tsbtnFText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFText.Name = "tsbtnFText";
            this.tsbtnFText.Size = new System.Drawing.Size(36, 36);
            this.tsbtnFText.Text = "tsbtnFText";
            this.tsbtnFText.Click += new System.EventHandler(this.tsbtnFText_Click);
            // 
            // tsbtnFAll
            // 
            this.tsbtnFAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnFAll.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFAll.Image")));
            this.tsbtnFAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFAll.Name = "tsbtnFAll";
            this.tsbtnFAll.Size = new System.Drawing.Size(36, 36);
            this.tsbtnFAll.Text = "tsbtnFAll";
            this.tsbtnFAll.Click += new System.EventHandler(this.tsbtnFAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnHDiffs
            // 
            this.tsbtnHDiffs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnHDiffs.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnHDiffs.Image")));
            this.tsbtnHDiffs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnHDiffs.Name = "tsbtnHDiffs";
            this.tsbtnHDiffs.Size = new System.Drawing.Size(36, 36);
            this.tsbtnHDiffs.Text = "tsbtnHDiffs";
            this.tsbtnHDiffs.ToolTipText = "tsbtnHDiffs";
            this.tsbtnHDiffs.Click += new System.EventHandler(this.tsbtnHDiffs_Click);
            // 
            // tsbtnHEquals
            // 
            this.tsbtnHEquals.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnHEquals.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnHEquals.Image")));
            this.tsbtnHEquals.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnHEquals.Name = "tsbtnHEquals";
            this.tsbtnHEquals.Size = new System.Drawing.Size(36, 36);
            this.tsbtnHEquals.Text = "tsbtnHEquals";
            this.tsbtnHEquals.Click += new System.EventHandler(this.tsbtnHEquals_Click);
            // 
            // tsbtnHText
            // 
            this.tsbtnHText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnHText.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnHText.Image")));
            this.tsbtnHText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnHText.Name = "tsbtnHText";
            this.tsbtnHText.Size = new System.Drawing.Size(36, 36);
            this.tsbtnHText.Text = "tsbtnHText";
            this.tsbtnHText.Click += new System.EventHandler(this.tsbtnHText_Click);
            // 
            // tsbtnClear
            // 
            this.tsbtnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnClear.Image")));
            this.tsbtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClear.Name = "tsbtnClear";
            this.tsbtnClear.Size = new System.Drawing.Size(36, 36);
            this.tsbtnClear.Text = "tsbtnClear";
            this.tsbtnClear.Click += new System.EventHandler(this.tsbtnClear_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnSettings
            // 
            this.tsbtnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSettings.Image")));
            this.tsbtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSettings.Name = "tsbtnSettings";
            this.tsbtnSettings.Size = new System.Drawing.Size(36, 36);
            this.tsbtnSettings.Text = "tsbtnSettings";
            this.tsbtnSettings.Click += new System.EventHandler(this.tsbtnSettings_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnAbout
            // 
            this.tsbtnAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAbout.Image")));
            this.tsbtnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAbout.Name = "tsbtnAbout";
            this.tsbtnAbout.Size = new System.Drawing.Size(36, 36);
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
            this.ClientSize = new System.Drawing.Size(592, 273);
            this.Controls.Add(this.tscContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 100);
            this.Name = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tscContainer.ContentPanel.ResumeLayout(false);
            this.tscContainer.ContentPanel.PerformLayout();
            this.tscContainer.TopToolStripPanel.ResumeLayout(false);
            this.tscContainer.TopToolStripPanel.PerformLayout();
            this.tscContainer.ResumeLayout(false);
            this.tscContainer.PerformLayout();
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
    }
}

