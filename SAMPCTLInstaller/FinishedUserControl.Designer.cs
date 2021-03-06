﻿namespace SAMPCTLInstaller
{
    partial class FinishedUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinishedUserControl));
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.introPanel = new System.Windows.Forms.Panel();
            this.wikiPageLinkLabel = new System.Windows.Forms.LinkLabel();
            this.gitHubIssuesTrackerPageLinkLabel = new System.Windows.Forms.LinkLabel();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.sampctlPictureBox = new System.Windows.Forms.PictureBox();
            this.mainTableLayoutPanel.SuspendLayout();
            this.introPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampctlPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.mainTableLayoutPanel.Controls.Add(this.introPanel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.sampctlPictureBox, 0, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 1;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(800, 600);
            this.mainTableLayoutPanel.TabIndex = 6;
            // 
            // introPanel
            // 
            this.introPanel.BackColor = System.Drawing.SystemColors.Control;
            this.introPanel.Controls.Add(this.wikiPageLinkLabel);
            this.introPanel.Controls.Add(this.gitHubIssuesTrackerPageLinkLabel);
            this.introPanel.Controls.Add(this.descriptionLabel);
            this.introPanel.Controls.Add(this.welcomeLabel);
            this.introPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.introPanel.Location = new System.Drawing.Point(203, 3);
            this.introPanel.Name = "introPanel";
            this.introPanel.Size = new System.Drawing.Size(594, 594);
            this.introPanel.TabIndex = 6;
            // 
            // wikiPageLinkLabel
            // 
            this.wikiPageLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.wikiPageLinkLabel.AutoSize = true;
            this.wikiPageLinkLabel.Font = new System.Drawing.Font("Verdana", 10F);
            this.wikiPageLinkLabel.Location = new System.Drawing.Point(32, 546);
            this.wikiPageLinkLabel.Name = "wikiPageLinkLabel";
            this.wikiPageLinkLabel.Size = new System.Drawing.Size(75, 17);
            this.wikiPageLinkLabel.TabIndex = 3;
            this.wikiPageLinkLabel.TabStop = true;
            this.wikiPageLinkLabel.Text = "Wiki Page";
            this.wikiPageLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.wikiPageLinkLabel_LinkClicked);
            // 
            // gitHubIssuesTrackerPageLinkLabel
            // 
            this.gitHubIssuesTrackerPageLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gitHubIssuesTrackerPageLinkLabel.AutoSize = true;
            this.gitHubIssuesTrackerPageLinkLabel.Font = new System.Drawing.Font("Verdana", 10F);
            this.gitHubIssuesTrackerPageLinkLabel.Location = new System.Drawing.Point(32, 529);
            this.gitHubIssuesTrackerPageLinkLabel.Name = "gitHubIssuesTrackerPageLinkLabel";
            this.gitHubIssuesTrackerPageLinkLabel.Size = new System.Drawing.Size(201, 17);
            this.gitHubIssuesTrackerPageLinkLabel.TabIndex = 2;
            this.gitHubIssuesTrackerPageLinkLabel.TabStop = true;
            this.gitHubIssuesTrackerPageLinkLabel.Text = "GitHub Issues Tracker Page";
            this.gitHubIssuesTrackerPageLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gitHubIssuesTrackerPageLinkLabel_LinkClicked);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionLabel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(32, 96);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(530, 435);
            this.descriptionLabel.TabIndex = 1;
            this.descriptionLabel.Text = resources.GetString("descriptionLabel.Text");
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.welcomeLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.Location = new System.Drawing.Point(32, 32);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(530, 64);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "sampctl has been successfully installed";
            // 
            // sampctlPictureBox
            // 
            this.sampctlPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.sampctlPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sampctlPictureBox.Image = global::SAMPCTLInstaller.Properties.Resources.SAMPCTLLogoRotated;
            this.sampctlPictureBox.Location = new System.Drawing.Point(3, 3);
            this.sampctlPictureBox.Name = "sampctlPictureBox";
            this.sampctlPictureBox.Size = new System.Drawing.Size(194, 594);
            this.sampctlPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sampctlPictureBox.TabIndex = 1;
            this.sampctlPictureBox.TabStop = false;
            // 
            // FinishedUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Name = "FinishedUserControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.introPanel.ResumeLayout(false);
            this.introPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampctlPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        public System.Windows.Forms.Panel introPanel;
        public System.Windows.Forms.Label descriptionLabel;
        public System.Windows.Forms.Label welcomeLabel;
        public System.Windows.Forms.PictureBox sampctlPictureBox;
        private System.Windows.Forms.LinkLabel wikiPageLinkLabel;
        private System.Windows.Forms.LinkLabel gitHubIssuesTrackerPageLinkLabel;
    }
}
