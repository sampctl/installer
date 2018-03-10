using System;
using System.Windows.Forms;

/// <summary>
/// sampctl Installer namespace
/// </summary>
namespace SAMPCTLInstaller
{
    /// <summary>
    /// Licence user control class
    /// </summary>
    public partial class LicenceUserControl : UserControl, IInstallationDialogState
    {
        /// <summary>
        /// Can go back
        /// </summary>
        public bool CanGoBack
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Can continue
        /// </summary>
        public bool CanContinue
        {
            get
            {
                return agreeCheckBox.Checked;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public LicenceUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Awake
        /// </summary>
        public void Awake()
        {
            agreeCheckBox.Checked = Installer.AgreeLicence;
        }

        /// <summary>
        /// Agree check box checked changed event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void agreeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Installer.AgreeLicence = agreeCheckBox.Checked;
            Installer.InstallationStepAccessUpdate(sender, e);
        }
    }
}
