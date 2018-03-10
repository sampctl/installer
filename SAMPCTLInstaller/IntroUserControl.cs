using System.Windows.Forms;

/// <summary>
/// sampctl Installer namespace
/// </summary>
namespace SAMPCTLInstaller
{
    /// <summary>
    /// Introduction user control class
    /// </summary>
    public partial class IntroUserControl : UserControl, IInstallationDialogState
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
        public IntroUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Awake
        /// </summary>
        public void Awake()
        {
            //
        }
    }
}
