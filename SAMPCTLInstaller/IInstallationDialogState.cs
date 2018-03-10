/// <summary>
/// sampctl Installer namespace
/// </summary>
namespace SAMPCTLInstaller
{
    /// <summary>
    /// Installation dialog state interface
    /// </summary>
    public interface IInstallationDialogState
    {
        /// <summary>
        /// Can go back
        /// </summary>
        bool CanGoBack
        {
            get;
        }

        /// <summary>
        /// Can continue
        /// </summary>
        bool CanContinue
        {
            get;
        }

        /// <summary>
        /// Awake
        /// </summary>
        void Awake();
    }
}
