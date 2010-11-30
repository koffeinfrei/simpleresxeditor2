namespace ResxEditor.Forms
{
    partial class FrmSettings
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpgInterface = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.lblColor1 = new System.Windows.Forms.Label();
            this.btnColor1 = new System.Windows.Forms.Button();
            this.lblColor2 = new System.Windows.Forms.Label();
            this.btnColor2 = new System.Windows.Forms.Button();
            this.lblColor3 = new System.Windows.Forms.Label();
            this.btnColor3 = new System.Windows.Forms.Button();
            this.lblColor4 = new System.Windows.Forms.Label();
            this.btnColor4 = new System.Windows.Forms.Button();
            this.lblColor5 = new System.Windows.Forms.Label();
            this.btnColor5 = new System.Windows.Forms.Button();
            this.tpgBehavior = new System.Windows.Forms.TabPage();
            this.chbShowKeyColumnOnStart = new System.Windows.Forms.CheckBox();
            this.chbSortByKeyOnSave = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.colorDialog3 = new System.Windows.Forms.ColorDialog();
            this.colorDialog4 = new System.Windows.Forms.ColorDialog();
            this.colorDialog5 = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.tpgInterface.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tpgBehavior.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpgInterface);
            this.tabControl1.Controls.Add(this.tpgBehavior);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(560, 309);
            this.tabControl1.TabIndex = 0;
            // 
            // tpgInterface
            // 
            this.tpgInterface.Controls.Add(this.tableLayoutPanel1);
            this.tpgInterface.Location = new System.Drawing.Point(4, 22);
            this.tpgInterface.Name = "tpgInterface";
            this.tpgInterface.Padding = new System.Windows.Forms.Padding(3);
            this.tpgInterface.Size = new System.Drawing.Size(552, 283);
            this.tpgInterface.TabIndex = 0;
            this.tpgInterface.Text = "tpgInterface";
            this.tpgInterface.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblLanguage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbLanguage, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblColor1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnColor1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblColor2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnColor2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblColor3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnColor3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblColor4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnColor4, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblColor5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnColor5, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(546, 277);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblLanguage
            // 
            this.lblLanguage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(3, 7);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(65, 13);
            this.lblLanguage.TabIndex = 0;
            this.lblLanguage.Text = "lblLanguage";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.DropDownWidth = 200;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(74, 3);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(200, 21);
            this.cmbLanguage.TabIndex = 1;
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            // 
            // lblColor1
            // 
            this.lblColor1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblColor1.AutoSize = true;
            this.lblColor1.Location = new System.Drawing.Point(21, 35);
            this.lblColor1.Name = "lblColor1";
            this.lblColor1.Size = new System.Drawing.Size(47, 13);
            this.lblColor1.TabIndex = 2;
            this.lblColor1.Text = "lblColor1";
            // 
            // btnColor1
            // 
            this.btnColor1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnColor1.Location = new System.Drawing.Point(74, 30);
            this.btnColor1.Name = "btnColor1";
            this.btnColor1.Size = new System.Drawing.Size(75, 23);
            this.btnColor1.TabIndex = 8;
            this.btnColor1.UseVisualStyleBackColor = true;
            this.btnColor1.Click += new System.EventHandler(this.btnColor1_Click);
            // 
            // lblColor2
            // 
            this.lblColor2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblColor2.AutoSize = true;
            this.lblColor2.Location = new System.Drawing.Point(21, 64);
            this.lblColor2.Name = "lblColor2";
            this.lblColor2.Size = new System.Drawing.Size(47, 13);
            this.lblColor2.TabIndex = 3;
            this.lblColor2.Text = "lblColor2";
            // 
            // btnColor2
            // 
            this.btnColor2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnColor2.Location = new System.Drawing.Point(74, 59);
            this.btnColor2.Name = "btnColor2";
            this.btnColor2.Size = new System.Drawing.Size(75, 23);
            this.btnColor2.TabIndex = 9;
            this.btnColor2.UseVisualStyleBackColor = true;
            this.btnColor2.Click += new System.EventHandler(this.btnColor2_Click);
            // 
            // lblColor3
            // 
            this.lblColor3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblColor3.AutoSize = true;
            this.lblColor3.Location = new System.Drawing.Point(21, 93);
            this.lblColor3.Name = "lblColor3";
            this.lblColor3.Size = new System.Drawing.Size(47, 13);
            this.lblColor3.TabIndex = 4;
            this.lblColor3.Text = "lblColor3";
            // 
            // btnColor3
            // 
            this.btnColor3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnColor3.Location = new System.Drawing.Point(74, 88);
            this.btnColor3.Name = "btnColor3";
            this.btnColor3.Size = new System.Drawing.Size(75, 23);
            this.btnColor3.TabIndex = 10;
            this.btnColor3.UseVisualStyleBackColor = true;
            this.btnColor3.Click += new System.EventHandler(this.btnColor3_Click);
            // 
            // lblColor4
            // 
            this.lblColor4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblColor4.AutoSize = true;
            this.lblColor4.Location = new System.Drawing.Point(21, 122);
            this.lblColor4.Name = "lblColor4";
            this.lblColor4.Size = new System.Drawing.Size(47, 13);
            this.lblColor4.TabIndex = 5;
            this.lblColor4.Text = "lblColor4";
            // 
            // btnColor4
            // 
            this.btnColor4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnColor4.Location = new System.Drawing.Point(74, 117);
            this.btnColor4.Name = "btnColor4";
            this.btnColor4.Size = new System.Drawing.Size(75, 23);
            this.btnColor4.TabIndex = 11;
            this.btnColor4.UseVisualStyleBackColor = true;
            this.btnColor4.Click += new System.EventHandler(this.btnColor4_Click);
            // 
            // lblColor5
            // 
            this.lblColor5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblColor5.AutoSize = true;
            this.lblColor5.Location = new System.Drawing.Point(21, 151);
            this.lblColor5.Name = "lblColor5";
            this.lblColor5.Size = new System.Drawing.Size(47, 13);
            this.lblColor5.TabIndex = 6;
            this.lblColor5.Text = "lblColor5";
            // 
            // btnColor5
            // 
            this.btnColor5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnColor5.Location = new System.Drawing.Point(74, 146);
            this.btnColor5.Name = "btnColor5";
            this.btnColor5.Size = new System.Drawing.Size(75, 23);
            this.btnColor5.TabIndex = 12;
            this.btnColor5.UseVisualStyleBackColor = true;
            this.btnColor5.Click += new System.EventHandler(this.btnColor5_Click);
            // 
            // tpgBehavior
            // 
            this.tpgBehavior.Controls.Add(this.tableLayoutPanel2);
            this.tpgBehavior.Location = new System.Drawing.Point(4, 22);
            this.tpgBehavior.Name = "tpgBehavior";
            this.tpgBehavior.Padding = new System.Windows.Forms.Padding(3);
            this.tpgBehavior.Size = new System.Drawing.Size(552, 283);
            this.tpgBehavior.TabIndex = 1;
            this.tpgBehavior.Text = "tpgBehavior";
            this.tpgBehavior.UseVisualStyleBackColor = true;
            // 
            // chbShowKeyColumnOnStart
            // 
            this.chbShowKeyColumnOnStart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chbShowKeyColumnOnStart.AutoSize = true;
            this.chbShowKeyColumnOnStart.Location = new System.Drawing.Point(3, 26);
            this.chbShowKeyColumnOnStart.Name = "chbShowKeyColumnOnStart";
            this.chbShowKeyColumnOnStart.Size = new System.Drawing.Size(160, 17);
            this.chbShowKeyColumnOnStart.TabIndex = 1;
            this.chbShowKeyColumnOnStart.Text = "chbShowKeyColumnOnStart";
            this.chbShowKeyColumnOnStart.UseVisualStyleBackColor = true;
            // 
            // chbSortByKeyOnSave
            // 
            this.chbSortByKeyOnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chbSortByKeyOnSave.AutoSize = true;
            this.chbSortByKeyOnSave.Location = new System.Drawing.Point(3, 3);
            this.chbSortByKeyOnSave.Name = "chbSortByKeyOnSave";
            this.chbSortByKeyOnSave.Size = new System.Drawing.Size(132, 17);
            this.chbSortByKeyOnSave.TabIndex = 0;
            this.chbSortByKeyOnSave.Text = "chbSortByKeyOnSave";
            this.chbSortByKeyOnSave.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoSize = true;
            this.btnSave.Location = new System.Drawing.Point(416, 327);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.Location = new System.Drawing.Point(497, 327);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.chbSortByKeyOnSave, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chbShowKeyColumnOnStart, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(546, 277);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmSettings";
            this.Text = "FrmSettings";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.Move += new System.EventHandler(this.FrmSettings_Move);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSettings_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.FrmSettings_ResizeEnd);
            this.tabControl1.ResumeLayout(false);
            this.tpgInterface.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tpgBehavior.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpgInterface;
        private System.Windows.Forms.TabPage tpgBehavior;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label lblColor1;
        private System.Windows.Forms.Label lblColor2;
        private System.Windows.Forms.Label lblColor3;
        private System.Windows.Forms.Label lblColor4;
        private System.Windows.Forms.Label lblColor5;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.Button btnColor1;
        private System.Windows.Forms.Button btnColor2;
        private System.Windows.Forms.Button btnColor3;
        private System.Windows.Forms.Button btnColor4;
        private System.Windows.Forms.Button btnColor5;
        private System.Windows.Forms.ColorDialog colorDialog3;
        private System.Windows.Forms.ColorDialog colorDialog4;
        private System.Windows.Forms.ColorDialog colorDialog5;
        private System.Windows.Forms.CheckBox chbSortByKeyOnSave;
        private System.Windows.Forms.CheckBox chbShowKeyColumnOnStart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}