namespace SAMPCTLInstaller
{
    partial class SetPathUserControl
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bodyPanel = new System.Windows.Forms.Panel();
            this.destinationDirectoryGroupBox = new System.Windows.Forms.GroupBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.destinationDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.sampctlPictureBox = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.bodyPanel.SuspendLayout();
            this.destinationDirectoryGroupBox.SuspendLayout();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampctlPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.bodyPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.titlePanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // bodyPanel
            // 
            this.bodyPanel.BackColor = System.Drawing.SystemColors.Control;
            this.bodyPanel.Controls.Add(this.destinationDirectoryGroupBox);
            this.bodyPanel.Controls.Add(this.descriptionLabel);
            this.bodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyPanel.Location = new System.Drawing.Point(3, 90);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Size = new System.Drawing.Size(794, 507);
            this.bodyPanel.TabIndex = 9;
            // 
            // destinationDirectoryGroupBox
            // 
            this.destinationDirectoryGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.destinationDirectoryGroupBox.Controls.Add(this.browseButton);
            this.destinationDirectoryGroupBox.Controls.Add(this.destinationDirectoryTextBox);
            this.destinationDirectoryGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.destinationDirectoryGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.destinationDirectoryGroupBox.Location = new System.Drawing.Point(32, 411);
            this.destinationDirectoryGroupBox.Name = "destinationDirectoryGroupBox";
            this.destinationDirectoryGroupBox.Size = new System.Drawing.Size(730, 64);
            this.destinationDirectoryGroupBox.TabIndex = 1;
            this.destinationDirectoryGroupBox.TabStop = false;
            this.destinationDirectoryGroupBox.Text = "Destination directory";
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.browseButton.Location = new System.Drawing.Point(604, 26);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(110, 23);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // destinationDirectoryTextBox
            // 
            this.destinationDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.destinationDirectoryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.destinationDirectoryTextBox.Location = new System.Drawing.Point(16, 29);
            this.destinationDirectoryTextBox.Name = "destinationDirectoryTextBox";
            this.destinationDirectoryTextBox.Size = new System.Drawing.Size(582, 20);
            this.destinationDirectoryTextBox.TabIndex = 0;
            this.destinationDirectoryTextBox.TextChanged += new System.EventHandler(this.destinationDirectoryTextBox_TextChanged);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.descriptionLabel.Location = new System.Drawing.Point(32, 32);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(730, 128);
            this.descriptionLabel.TabIndex = 0;
            this.descriptionLabel.Text = "The Online Installer Wizard will install sampctl into the following directory. To" +
    " install into a different directory, click Browse and select a different directo" +
    "ry.\r\n\r\n\r\nClick Next to continue.";
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.SystemColors.Control;
            this.titlePanel.Controls.Add(this.subtitleLabel);
            this.titlePanel.Controls.Add(this.titleLabel);
            this.titlePanel.Controls.Add(this.sampctlPictureBox);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titlePanel.Location = new System.Drawing.Point(3, 3);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(794, 81);
            this.titlePanel.TabIndex = 8;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Verdana", 10F);
            this.subtitleLabel.Location = new System.Drawing.Point(32, 51);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(265, 17);
            this.subtitleLabel.TabIndex = 3;
            this.subtitleLabel.Text = "Choose a directory to install sampctl";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(32, 14);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(257, 23);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Choose install location";
            // 
            // sampctlPictureBox
            // 
            this.sampctlPictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.sampctlPictureBox.Image = global::SAMPCTLInstaller.Properties.Resources.SAMPCTLLogo;
            this.sampctlPictureBox.Location = new System.Drawing.Point(615, 0);
            this.sampctlPictureBox.Name = "sampctlPictureBox";
            this.sampctlPictureBox.Size = new System.Drawing.Size(179, 81);
            this.sampctlPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sampctlPictureBox.TabIndex = 1;
            this.sampctlPictureBox.TabStop = false;
            // 
            // SetPathUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SetPathUserControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.bodyPanel.ResumeLayout(false);
            this.destinationDirectoryGroupBox.ResumeLayout(false);
            this.destinationDirectoryGroupBox.PerformLayout();
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampctlPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Panel titlePanel;
        public System.Windows.Forms.Label subtitleLabel;
        public System.Windows.Forms.Label titleLabel;
        public System.Windows.Forms.PictureBox sampctlPictureBox;
        public System.Windows.Forms.Panel bodyPanel;
        public System.Windows.Forms.GroupBox destinationDirectoryGroupBox;
        public System.Windows.Forms.Button browseButton;
        public System.Windows.Forms.TextBox destinationDirectoryTextBox;
        public System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}
