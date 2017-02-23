namespace YoutubeDownloader.WinApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.inputLabel = new System.Windows.Forms.Label();
            this.outputLabel = new System.Windows.Forms.Label();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.chooseOutputButton = new System.Windows.Forms.Button();
            this.qualityLabel = new System.Windows.Forms.Label();
            this.convertLabel = new System.Windows.Forms.Label();
            this.convertCheckBox = new System.Windows.Forms.CheckBox();
            this.qualityComboBox = new System.Windows.Forms.ComboBox();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.LogTextBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.inputLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.outputLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.inputTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.outputTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.okButton, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.statusLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.cancelButton, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.chooseOutputButton, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.qualityLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.convertLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.convertCheckBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.qualityComboBox, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(510, 153);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // inputLabel
            // 
            this.inputLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.inputLabel.AutoSize = true;
            this.inputLabel.Location = new System.Drawing.Point(49, 6);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(84, 13);
            this.inputLabel.TabIndex = 0;
            this.inputLabel.Text = "URL de la vidéo";
            // 
            // outputLabel
            // 
            this.outputLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(11, 34);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(122, 13);
            this.outputLabel.TabIndex = 1;
            this.outputLabel.Text = "Enregistrer la vidéo sous";
            // 
            // inputTextBox
            // 
            this.inputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.inputTextBox, 2);
            this.inputTextBox.Location = new System.Drawing.Point(139, 3);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(287, 20);
            this.inputTextBox.TabIndex = 2;
            this.inputTextBox.TextChanged += new System.EventHandler(this.InputTextBoxTextChanged);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.outputTextBox, 2);
            this.outputTextBox.Location = new System.Drawing.Point(139, 30);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(287, 20);
            this.outputTextBox.TabIndex = 3;
            this.outputTextBox.TextChanged += new System.EventHandler(this.OutputTextBoxTextChanged);
            // 
            // okButton
            // 
            this.okButton.Enabled = false;
            this.okButton.Location = new System.Drawing.Point(351, 105);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "Télécharger";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.statusLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.statusLabel, 2);
            this.statusLabel.Location = new System.Drawing.Point(3, 121);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 13);
            this.statusLabel.TabIndex = 7;
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(432, 105);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Annuler";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // chooseOutputButton
            // 
            this.chooseOutputButton.Location = new System.Drawing.Point(432, 29);
            this.chooseOutputButton.Name = "chooseOutputButton";
            this.chooseOutputButton.Size = new System.Drawing.Size(75, 23);
            this.chooseOutputButton.TabIndex = 5;
            this.chooseOutputButton.Text = "Choisir...";
            this.chooseOutputButton.UseVisualStyleBackColor = true;
            this.chooseOutputButton.Click += new System.EventHandler(this.chooseOutputButton_Click);
            // 
            // qualityLabel
            // 
            this.qualityLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.qualityLabel.AutoSize = true;
            this.qualityLabel.Location = new System.Drawing.Point(3, 55);
            this.qualityLabel.Name = "qualityLabel";
            this.qualityLabel.Size = new System.Drawing.Size(130, 26);
            this.qualityLabel.TabIndex = 12;
            this.qualityLabel.Text = "Qualité maximale\r\n(permet de réduire la taille)";
            this.qualityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // convertLabel
            // 
            this.convertLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.convertLabel.AutoSize = true;
            this.convertLabel.Location = new System.Drawing.Point(44, 85);
            this.convertLabel.Name = "convertLabel";
            this.convertLabel.Size = new System.Drawing.Size(89, 13);
            this.convertLabel.TabIndex = 10;
            this.convertLabel.Text = "Convertir en MP4";
            // 
            // convertCheckBox
            // 
            this.convertCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.convertCheckBox.AutoSize = true;
            this.convertCheckBox.Location = new System.Drawing.Point(139, 85);
            this.convertCheckBox.Name = "convertCheckBox";
            this.convertCheckBox.Size = new System.Drawing.Size(15, 14);
            this.convertCheckBox.TabIndex = 9;
            this.convertCheckBox.UseVisualStyleBackColor = true;
            this.convertCheckBox.CheckedChanged += new System.EventHandler(this.ConvertCheckBoxCheckedChanged);
            // 
            // qualityComboBox
            // 
            this.qualityComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.qualityComboBox, 2);
            this.qualityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qualityComboBox.FormattingEnabled = true;
            this.qualityComboBox.Location = new System.Drawing.Point(139, 58);
            this.qualityComboBox.Name = "qualityComboBox";
            this.qualityComboBox.Size = new System.Drawing.Size(287, 21);
            this.qualityComboBox.TabIndex = 11;
            // 
            // folderBrowser
            // 
            this.folderBrowser.Description = "Choisissez le dossier où sera enregistré la vidéo YouTube";
            // 
            // LogTextBox
            // 
            this.LogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogTextBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.LogTextBox.DetectUrls = false;
            this.LogTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.LogTextBox.Location = new System.Drawing.Point(12, 171);
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ShortcutsEnabled = false;
            this.LogTextBox.Size = new System.Drawing.Size(510, 178);
            this.LogTextBox.TabIndex = 1;
            this.LogTextBox.TabStop = false;
            this.LogTextBox.Text = "";
            this.LogTextBox.WordWrap = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 361);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "MainForm";
            this.Text = "YouTube Downloader";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label inputLabel;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Button chooseOutputButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox convertCheckBox;
        private System.Windows.Forms.Label convertLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        public System.Windows.Forms.RichTextBox LogTextBox;
        private System.Windows.Forms.ComboBox qualityComboBox;
        private System.Windows.Forms.Label qualityLabel;
    }
}

