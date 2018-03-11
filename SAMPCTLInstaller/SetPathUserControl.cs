using System;
using System.IO;
using System.Windows.Forms;

/// <summary>
/// sampctl Installer namespace
/// </summary>
namespace SAMPCTLInstaller
{
    /// <summary>
    /// Set path user control class
    /// </summary>
    public partial class SetPathUserControl : UserControl, IInstallationDialogState
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
                return true;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SetPathUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Awake
        /// </summary>
        public void Awake()
        {
            try
            {
                destinationDirectoryTextBox.Text = Installer.DestinationDirectory;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Destination directory text box text changed event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void destinationDirectoryTextBox_TextChanged(object sender, EventArgs e)
        {
            Installer.DestinationDirectory = destinationDirectoryTextBox.Text;
        }

        /// <summary>
        /// Browse button click event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        private void browseButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = destinationDirectoryTextBox.Text;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                destinationDirectoryTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
