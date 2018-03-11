using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// sampctl Installer namespace
/// </summary>
namespace SAMPCTLInstaller
{
    /// <summary>
    /// Main form class
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Instance
        /// </summary>
        private static MainForm instance;

        /// <summary>
        /// Current installation step
        /// </summary>
        private UserControl currentInstallationStep;

        /// <summary>
        /// Do not cancel installation
        /// </summary>
        private bool doNotCancel = true;

        /// <summary>
        /// Instance
        /// </summary>
        public static MainForm Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainForm()
        {
            instance = this;
            InitializeComponent();
            Installer.InstallationStepAccessUpdate += OnInstallationStepAccessUpdate;
            UpdateInstallationStep();
        }

        /// <summary>
        /// Update installation step
        /// </summary>
        public void UpdateInstallationStep()
        {
            if (currentInstallationStep != null)
            {
                currentInstallationStep.Visible = false;
                mainTableLayoutPanel.Controls.Remove(currentInstallationStep);
                currentInstallationStep = null;
            }
            currentInstallationStep = Installer.InstallationStep;
            if (currentInstallationStep != null)
            {
                mainTableLayoutPanel.Controls.Add(currentInstallationStep, 0, 0);
                currentInstallationStep.Visible = true;
                ((IInstallationDialogState)currentInstallationStep).Awake();
            }
            UpdateButtons();
        }

        /// <summary>
        /// Update buttons
        /// </summary>
        private void UpdateButtons()
        {
            IInstallationDialogState state = (IInstallationDialogState)currentInstallationStep;
            if (state != null)
            {
                backButton.Enabled = state.CanGoBack;
                nextButton.Enabled = state.CanContinue;
                cancelButton.Enabled = ((!(Installer.IsAtEnd)) || (!(state.CanContinue)));
                if (nextButton.Enabled)
                {
                    nextButton.Focus();
                }
                else if (backButton.Enabled)
                {
                    backButton.Focus();
                }
                else
                {
                    cancelButton.Focus();
                }
                nextButton.Text = (Installer.IsAtEnd ? "Finish" : "Next");
            }
        }

        /// <summary>
        /// On installation step access update event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void OnInstallationStepAccessUpdate(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        /// <summary>
        /// Main form closing
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (doNotCancel && (!(Installer.IsAtEnd)))
            {
                if (MessageBox.Show("Do you really want to cancel the installation?", "Cancel installation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = false;
                }
                else
                {
                    doNotCancel = false;
                }
            }
        }

        /// <summary>
        /// Back button click event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void backButton_Click(object sender, EventArgs e)
        {
            if (Installer.RedoInstallationStep())
            {
                UpdateInstallationStep();
            }
        }

        /// <summary>
        /// Next button click event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void nextButton_Click(object sender, EventArgs e)
        {
            if (Installer.IsAtEnd)
            {
                doNotCancel = false;
                Close();
            }
            else if (Installer.ContinueInstallationStep())
            {
                UpdateInstallationStep();
            }
        }

        /// <summary>
        /// Cancel button click event button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to cancel the installation?", "Cancel installation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                doNotCancel = false;
                Close();
            }
        }
    }
}
