namespace MovieHachiTool
{
    partial class MovieHachiToolForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.convertTabPage = new System.Windows.Forms.TabPage();
            this.wipeCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.destinationTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.inyouTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.footerTextBox = new System.Windows.Forms.TextBox();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.headerTextBox = new System.Windows.Forms.TextBox();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.settingTabPage = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.WipeText = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.PictureExportPathTextBox = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFonts = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.convertTabPage.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.settingTabPage.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.convertTabPage);
            this.tabControl1.Controls.Add(this.settingTabPage);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1171, 619);
            this.tabControl1.TabIndex = 8;
            // 
            // convertTabPage
            // 
            this.convertTabPage.Controls.Add(this.wipeCheckBox);
            this.convertTabPage.Controls.Add(this.tableLayoutPanel2);
            this.convertTabPage.Controls.Add(this.groupBox1);
            this.convertTabPage.Controls.Add(this.ConvertButton);
            this.convertTabPage.Location = new System.Drawing.Point(4, 22);
            this.convertTabPage.Name = "convertTabPage";
            this.convertTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.convertTabPage.Size = new System.Drawing.Size(1163, 593);
            this.convertTabPage.TabIndex = 0;
            this.convertTabPage.Text = "変換";
            this.convertTabPage.UseVisualStyleBackColor = true;
            // 
            // wipeCheckBox
            // 
            this.wipeCheckBox.AutoSize = true;
            this.wipeCheckBox.Checked = global::MovieHachiTool.Properties.Settings.Default.WipeYesNo;
            this.wipeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wipeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MovieHachiTool.Properties.Settings.Default, "WipeYesNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.wipeCheckBox.Location = new System.Drawing.Point(530, 216);
            this.wipeCheckBox.Name = "wipeCheckBox";
            this.wipeCheckBox.Size = new System.Drawing.Size(111, 16);
            this.wipeCheckBox.TabIndex = 1;
            this.wipeCheckBox.Text = "ワイプテキスト挿入";
            this.wipeCheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(641, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.14651F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.85349F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(519, 587);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.destinationTextBox);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 133);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(513, 451);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "変換先";
            // 
            // destinationTextBox
            // 
            this.destinationTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.destinationTextBox.Location = new System.Drawing.Point(3, 15);
            this.destinationTextBox.Multiline = true;
            this.destinationTextBox.Name = "destinationTextBox";
            this.destinationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.destinationTextBox.Size = new System.Drawing.Size(507, 433);
            this.destinationTextBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.inyouTextBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(513, 124);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "引用HTML";
            // 
            // inyouTextBox
            // 
            this.inyouTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inyouTextBox.Location = new System.Drawing.Point(3, 15);
            this.inyouTextBox.Multiline = true;
            this.inyouTextBox.Name = "inyouTextBox";
            this.inyouTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.inyouTextBox.Size = new System.Drawing.Size(507, 106);
            this.inyouTextBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 587);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "元ソース";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.footerTextBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.sourceTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.headerTextBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(519, 569);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // footerTextBox
            // 
            this.footerTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MovieHachiTool.Properties.Settings.Default, "ScriptFooter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.footerTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footerTextBox.Location = new System.Drawing.Point(3, 457);
            this.footerTextBox.Multiline = true;
            this.footerTextBox.Name = "footerTextBox";
            this.footerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.footerTextBox.Size = new System.Drawing.Size(513, 109);
            this.footerTextBox.TabIndex = 2;
            this.footerTextBox.Text = global::MovieHachiTool.Properties.Settings.Default.ScriptFooter;
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceTextBox.Location = new System.Drawing.Point(3, 116);
            this.sourceTextBox.Multiline = true;
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.sourceTextBox.Size = new System.Drawing.Size(513, 335);
            this.sourceTextBox.TabIndex = 1;
            // 
            // headerTextBox
            // 
            this.headerTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MovieHachiTool.Properties.Settings.Default, "ScriptHeader", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.headerTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerTextBox.Location = new System.Drawing.Point(3, 3);
            this.headerTextBox.Multiline = true;
            this.headerTextBox.Name = "headerTextBox";
            this.headerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.headerTextBox.Size = new System.Drawing.Size(513, 107);
            this.headerTextBox.TabIndex = 0;
            this.headerTextBox.Text = global::MovieHachiTool.Properties.Settings.Default.ScriptHeader;
            // 
            // ConvertButton
            // 
            this.ConvertButton.Location = new System.Drawing.Point(547, 238);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(75, 23);
            this.ConvertButton.TabIndex = 2;
            this.ConvertButton.Text = "->";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // settingTabPage
            // 
            this.settingTabPage.Controls.Add(this.groupBox5);
            this.settingTabPage.Controls.Add(this.groupBox3);
            this.settingTabPage.Location = new System.Drawing.Point(4, 22);
            this.settingTabPage.Name = "settingTabPage";
            this.settingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingTabPage.Size = new System.Drawing.Size(1163, 593);
            this.settingTabPage.TabIndex = 1;
            this.settingTabPage.Text = "設定";
            this.settingTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.WipeText);
            this.groupBox5.Location = new System.Drawing.Point(3, 78);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(550, 116);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ワイプテキスト";
            // 
            // WipeText
            // 
            this.WipeText.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MovieHachiTool.Properties.Settings.Default, "WipeText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.WipeText.Location = new System.Drawing.Point(3, 18);
            this.WipeText.Multiline = true;
            this.WipeText.Name = "WipeText";
            this.WipeText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.WipeText.Size = new System.Drawing.Size(541, 91);
            this.WipeText.TabIndex = 1;
            this.WipeText.Text = global::MovieHachiTool.Properties.Settings.Default.WipeText;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbFonts);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.PictureExportPathTextBox);
            this.groupBox3.Location = new System.Drawing.Point(3, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(550, 66);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "画像出力";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(469, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "参照";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // PictureExportPathTextBox
            // 
            this.PictureExportPathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::MovieHachiTool.Properties.Settings.Default, "PictureHtmlExportPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PictureExportPathTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.PictureExportPathTextBox.Location = new System.Drawing.Point(3, 15);
            this.PictureExportPathTextBox.Name = "PictureExportPathTextBox";
            this.PictureExportPathTextBox.Size = new System.Drawing.Size(465, 19);
            this.PictureExportPathTextBox.TabIndex = 0;
            this.PictureExportPathTextBox.Text = global::MovieHachiTool.Properties.Settings.Default.PictureHtmlExportPath;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1163, 593);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tempTabPage";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "フォント";
            // 
            // cbFonts
            // 
            this.cbFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFonts.FormattingEnabled = true;
            this.cbFonts.Location = new System.Drawing.Point(51, 38);
            this.cbFonts.Name = "cbFonts";
            this.cbFonts.Size = new System.Drawing.Size(100, 20);
            this.cbFonts.TabIndex = 16;
            // 
            // MovieHachiToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 619);
            this.Controls.Add(this.tabControl1);
            this.Name = "MovieHachiToolForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Shown += new System.EventHandler(this.MovieHachiToolForm_Shown);
            this.tabControl1.ResumeLayout(false);
            this.convertTabPage.ResumeLayout(false);
            this.convertTabPage.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.settingTabPage.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage convertTabPage;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.TabPage settingTabPage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox PictureExportPathTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox footerTextBox;
        private System.Windows.Forms.TextBox headerTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox destinationTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox inyouTextBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox WipeText;
        private System.Windows.Forms.CheckBox wipeCheckBox;
        private System.Windows.Forms.ComboBox cbFonts;
        private System.Windows.Forms.Label label1;
    }
}

