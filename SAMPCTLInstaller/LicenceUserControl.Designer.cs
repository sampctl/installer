namespace SAMPCTLInstaller
{
    partial class LicenceUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenceUserControl));
            this.titlePanel = new System.Windows.Forms.Panel();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.sampctlPictureBox = new System.Windows.Forms.PictureBox();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.bodyPanel = new System.Windows.Forms.Panel();
            this.requestLabel = new System.Windows.Forms.Label();
            this.agreeCheckBox = new System.Windows.Forms.CheckBox();
            this.licenceRichTextBox = new System.Windows.Forms.RichTextBox();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampctlPictureBox)).BeginInit();
            this.mainTableLayoutPanel.SuspendLayout();
            this.bodyPanel.SuspendLayout();
            this.SuspendLayout();
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
            this.titlePanel.TabIndex = 7;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Verdana", 10F);
            this.subtitleLabel.Location = new System.Drawing.Point(32, 51);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(400, 17);
            this.subtitleLabel.TabIndex = 3;
            this.subtitleLabel.Text = "Please review the license terms before installing sampctl";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(32, 14);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(217, 23);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "License Agreement";
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
            this.mainTableLayoutPanel.TabIndex = 8;
            // 
            // bodyPanel
            // 
            this.bodyPanel.BackColor = System.Drawing.SystemColors.Control;
            this.bodyPanel.Controls.Add(this.requestLabel);
            this.bodyPanel.Controls.Add(this.agreeCheckBox);
            this.bodyPanel.Controls.Add(this.licenceRichTextBox);
            this.bodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyPanel.Location = new System.Drawing.Point(3, 90);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Size = new System.Drawing.Size(794, 507);
            this.bodyPanel.TabIndex = 8;
            // 
            // requestLabel
            // 
            this.requestLabel.AutoSize = true;
            this.requestLabel.Font = new System.Drawing.Font("Verdana", 10F);
            this.requestLabel.Location = new System.Drawing.Point(32, 16);
            this.requestLabel.Name = "requestLabel";
            this.requestLabel.Size = new System.Drawing.Size(374, 17);
            this.requestLabel.TabIndex = 2;
            this.requestLabel.Text = "Please read the following license agreement carefully";
            // 
            // agreeCheckBox
            // 
            this.agreeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.agreeCheckBox.AutoSize = true;
            this.agreeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.agreeCheckBox.Location = new System.Drawing.Point(32, 483);
            this.agreeCheckBox.Name = "agreeCheckBox";
            this.agreeCheckBox.Size = new System.Drawing.Size(298, 21);
            this.agreeCheckBox.TabIndex = 1;
            this.agreeCheckBox.Text = "I &accept the terms in the license agreement";
            this.agreeCheckBox.UseVisualStyleBackColor = true;
            this.agreeCheckBox.CheckedChanged += new System.EventHandler(this.agreeCheckBox_CheckedChanged);
            // 
            // licenceRichTextBox
            // 
            this.licenceRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.licenceRichTextBox.BackColor = System.Drawing.Color.White;
            this.licenceRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.licenceRichTextBox.Font = new System.Drawing.Font("Courier New", 8F);
            this.licenceRichTextBox.Location = new System.Drawing.Point(32, 36);
            this.licenceRichTextBox.Name = "licenceRichTextBox";
            this.licenceRichTextBox.ReadOnly = true;
            this.licenceRichTextBox.Size = new System.Drawing.Size(730, 441);
            this.licenceRichTextBox.TabIndex = 0;
            this.licenceRichTextBox.Text = resources.GetString("licenceRichTextBox.Text");
            // 
            // LicenceUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Name = "LicenceUserControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampctlPictureBox)).EndInit();
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.bodyPanel.ResumeLayout(false);
            this.bodyPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel titlePanel;
        public System.Windows.Forms.Label subtitleLabel;
        public System.Windows.Forms.Label titleLabel;
        public System.Windows.Forms.PictureBox sampctlPictureBox;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        public System.Windows.Forms.Panel bodyPanel;
        public System.Windows.Forms.Label requestLabel;
        public System.Windows.Forms.CheckBox agreeCheckBox;
        public System.Windows.Forms.RichTextBox licenceRichTextBox;
    }
}
