/// <summary>
/// sampctl Uninstaller namespace
/// </summary>
namespace SAMPCTLUninstaller
{
    /// <summary>
    /// Uninstallation dialog state interface
    /// </summary>
    public interface IUninstallationDialogState
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
