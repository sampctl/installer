using System;
using System.Diagnostics;
using System.Windows.Forms;

/// <summary>
/// sampctl Uninstaller namespace
/// </summary>
namespace SAMPCTLUninstaller
{
    /// <summary>
    /// Failed user control class
    /// </summary>
    public partial class FailedUserControl : UserControl, IUninstallationDialogState
    {
        /// <summary>
        /// Can go back
        /// </summary>
        public bool CanGoBack
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Can continue
        /// </summary>
        public bool CanContinue
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public FailedUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Awake
        /// </summary>
        public void Awake()
        {
            errorLabel.Text = ((Uninstaller.UninstallationErrorMessage == null) ? "Unknown error" : Uninstaller.UninstallationErrorMessage);
        }

        /// <summary>
        /// GitHub issues tracker page link label link clicked event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Link label clicked event arguments</param>
        private void gitHubIssuesTrackerPageLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("https://github.com/Southclaws/sampctl/issues");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Wiki page link label link clicked event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Link label clicked event arguments</param>
        private void wikiPageLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("https://github.com/Southclaws/sampctl/wiki");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
