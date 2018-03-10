namespace SAMPCTLUninstaller
{
    partial class ProgressUserControl
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
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.bodyPanel = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.progressRichTextBox = new System.Windows.Forms.RichTextBox();
            this.uninstallationProgressBar = new System.Windows.Forms.ProgressBar();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.sampctlPictureBox = new System.Windows.Forms.PictureBox();
            this.mainTableLayoutPanel.SuspendLayout();
            this.bodyPanel.SuspendLayout();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampctlPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 1;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.bodyPanel, 0, 1);
            this.mainTableLayoutPanel.Controls.Add(this.titlePanel, 0, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 2;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(800, 600);
            this.mainTableLayoutPanel.TabIndex = 11;
            // 
            // bodyPanel
            // 
            this.bodyPanel.BackColor = System.Drawing.SystemColors.Control;
            this.bodyPanel.Controls.Add(this.statusLabel);
            this.bodyPanel.Controls.Add(this.progressRichTextBox);
            this.bodyPanel.Controls.Add(this.uninstallationProgressBar);
            this.bodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyPanel.Location = new System.Drawing.Point(3, 90);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Size = new System.Drawing.Size(794, 507);
            this.bodyPanel.TabIndex = 0;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.statusLabel.Location = new System.Drawing.Point(32, 32);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(48, 17);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "Status";
            // 
            // progressRichTextBox
            // 
            this.progressRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressRichTextBox.BackColor = System.Drawing.Color.White;
            this.progressRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.progressRichTextBox.DetectUrls = false;
            this.progressRichTextBox.Location = new System.Drawing.Point(32, 72);
            this.progressRichTextBox.Name = "progressRichTextBox";
            this.progressRichTextBox.ReadOnly = true;
            this.progressRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.progressRichTextBox.Size = new System.Drawing.Size(730, 403);
            this.progressRichTextBox.TabIndex = 1;
            this.progressRichTextBox.Text = "";
            this.progressRichTextBox.WordWrap = false;
            // 
            // uninstallationProgressBar
            // 
            this.uninstallationProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uninstallationProgressBar.Location = new System.Drawing.Point(32, 52);
            this.uninstallationProgressBar.MarqueeAnimationSpeed = 10;
            this.uninstallationProgressBar.Name = "uninstallationProgressBar";
            this.uninstallationProgressBar.Size = new System.Drawing.Size(730, 14);
            this.uninstallationProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.uninstallationProgressBar.TabIndex = 0;
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
            this.titlePanel.TabIndex = 9;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Verdana", 10F);
            this.subtitleLabel.Location = new System.Drawing.Point(32, 51);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(321, 17);
            this.subtitleLabel.TabIndex = 3;
            this.subtitleLabel.Text = "Please wait while sampctl is being uninstalled";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(32, 14);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(141, 23);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Uninstalling";
            // 
            // sampctlPictureBox
            // 
            this.sampctlPictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.sampctlPictureBox.Image = global::SAMPCTLUninstaller.Properties.Resources.SAMPCTLLogo;
            this.sampctlPictureBox.Location = new System.Drawing.Point(615, 0);
            this.sampctlPictureBox.Name = "sampctlPictureBox";
            this.sampctlPictureBox.Size = new System.Drawing.Size(179, 81);
            this.sampctlPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sampctlPictureBox.TabIndex = 1;
            this.sampctlPictureBox.TabStop = false;
            // 
            // ProgressUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Name = "ProgressUserControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.bodyPanel.ResumeLayout(false);
            this.bodyPanel.PerformLayout();
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampctlPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        public System.Windows.Forms.Panel bodyPanel;
        public System.Windows.Forms.Label statusLabel;
        public System.Windows.Forms.RichTextBox progressRichTextBox;
        public System.Windows.Forms.ProgressBar uninstallationProgressBar;
        public System.Windows.Forms.Panel titlePanel;
        public System.Windows.Forms.Label subtitleLabel;
        public System.Windows.Forms.Label titleLabel;
        public System.Windows.Forms.PictureBox sampctlPictureBox;
    }
}
