using System;
using System.Windows.Forms;

/// <summary>
/// sampctl Uninstaller namespace
/// </summary>
namespace SAMPCTLUninstaller
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
        /// Current uninstallation step
        /// </summary>
        private UserControl currentUninstallationStep;

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
            Uninstaller.UninstallationStepAccessUpdate += OnUninstallationStepAccessUpdate;
            UpdateUninstallationStep();
        }

        /// <summary>
        /// Update uninstallation step
        /// </summary>
        public void UpdateUninstallationStep()
        {
            if (currentUninstallationStep != null)
            {
                currentUninstallationStep.Visible = false;
                mainTableLayoutPanel.Controls.Remove(currentUninstallationStep);
                currentUninstallationStep = null;
            }
            currentUninstallationStep = Uninstaller.UninstallationStep;
            if (currentUninstallationStep != null)
            {
                mainTableLayoutPanel.Controls.Add(currentUninstallationStep, 0, 0);
                currentUninstallationStep.Visible = true;
                ((IUninstallationDialogState)currentUninstallationStep).Awake();
            }
            UpdateButtons();
        }

        /// <summary>
        /// Update buttons
        /// </summary>
        private void UpdateButtons()
        {
            IUninstallationDialogState state = (IUninstallationDialogState)currentUninstallationStep;
            if (state != null)
            {
                backButton.Enabled = state.CanGoBack;
                nextButton.Enabled = state.CanContinue;
                cancelButton.Enabled = ((!(Uninstaller.IsAtEnd)) || (!(state.CanContinue)));
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
                nextButton.Text = (Uninstaller.IsAtEnd ? "Finish" : "Next");
            }
        }

        /// <summary>
        /// On uninstallation step access update event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void OnUninstallationStepAccessUpdate(object sender, EventArgs e)
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
            if (doNotCancel && (!(Uninstaller.IsAtEnd)))
            {
                if (MessageBox.Show("Do you really want to cancel the uninstallation?", "Cancel uninstallation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
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
            if (Uninstaller.RedoUninstallationStep())
            {
                UpdateUninstallationStep();
            }
        }

        /// <summary>
        /// Next button click event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void nextButton_Click(object sender, EventArgs e)
        {
            if (Uninstaller.IsAtEnd)
            {
                doNotCancel = false;
                Close();
            }
            else if (Uninstaller.ContinueUninstallationStep())
            {
                UpdateUninstallationStep();
            }
        }

        /// <summary>
        /// Cancel button click event button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to cancel the uninstallation?", "Cancel uninstallation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                doNotCancel = false;
                Close();
            }
        }
    }
}
