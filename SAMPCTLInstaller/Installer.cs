using System;
using System.IO;
using System.Windows.Forms;

/// <summary>
/// sampctl Installer namespace
/// </summary>
namespace SAMPCTLInstaller
{
    /// <summary>
    /// Installer class
    /// </summary>
    public static class Installer
    {
        /// <summary>
        /// Installation step types
        /// </summary>
        private static readonly Type[] installationStepTypes = new Type[]
        {
            typeof(IntroUserControl),
            typeof(LicenceUserControl),
            typeof(SetPathUserControl),
            typeof(ProgressUserControl),
            typeof(FinishedUserControl)
        };

        /// <summary>
        /// Failed installation step type
        /// </summary>
        private static readonly Type failedInstallationStepType = typeof(FailedUserControl);

        /// <summary>
        /// Installation step access update
        /// </summary>
        public static InstallationStepAccessUpdateEventHandler InstallationStepAccessUpdate;

        /// <summary>
        /// Installation steps
        /// </summary>
        private static UserControl[] installationSteps;

        /// <summary>
        /// Failed installation step
        /// </summary>
        private static UserControl failedInstallationStep;

        /// <summary>
        /// Installation step index
        /// </summary>
        private static uint installationStepIndex;

        /// <summary>
        /// Installation error message
        /// </summary>
        private static string installationErrorMessage;

        /// <summary>
        /// Agree on licence
        /// </summary>
        private static bool agreeLicence = false;

        /// <summary>
        /// Destination directory
        /// </summary>
        private static string destinationDirectory;

        /// <summary>
        /// Installation error message
        /// </summary>
        public static string InstallationErrorMessage
        {
            get
            {
                return installationErrorMessage;
            }
            set
            {
                if (value != null)
                {
                    installationErrorMessage = value;
                }
            }
        }

        /// <summary>
        /// Agree on licence
        /// </summary>
        public static bool AgreeLicence
        {
            get
            {
                return agreeLicence;
            }
            set
            {
                agreeLicence = value;
            }
        }

        /// <summary>
        /// Destination directory
        /// </summary>
        public static string DestinationDirectory
        {
            get
            {
                if (destinationDirectory == null)
                {
                    destinationDirectory = Path.Combine(Environment.GetEnvironmentVariable("ProgramFiles"), "sampctl");
                }
                return destinationDirectory;
            }
            set
            {
                if (value != null)
                {
                    destinationDirectory = value;
                }
            }
        }

        /// <summary>
        /// Installation step
        /// </summary>
        public static UserControl InstallationStep
        {
            get
            {
                UserControl ret = null;
                if (installationSteps == null)
                {
                    installationSteps = new UserControl[installationStepTypes.Length];
                }
                ret = ((installationErrorMessage == null) ? installationSteps[installationStepIndex] : failedInstallationStep);
                if (ret == null)
                {
                    try
                    {
                        ret = Activator.CreateInstance((installationErrorMessage == null) ? installationStepTypes[installationStepIndex] : failedInstallationStepType) as UserControl;
                        if (ret is IInstallationDialogState)
                        {
                            if (installationErrorMessage == null)
                            {
                                installationSteps[installationStepIndex] = ret;
                            }
                            else
                            {
                                failedInstallationStep = ret;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e.Message);
                    }
                }
                return ret;
            }
        }

        /// <summary>
        /// Is at end
        /// </summary>
        public static bool IsAtEnd
        {
            get
            {
                return ((installationErrorMessage == null) ? ((installationStepIndex + 1U) >= installationSteps.Length) : true);
            }
        }

        /// <summary>
        /// Continue installation step
        /// </summary>
        /// <returns>"true" if successful, otherwise "false"</returns>
        public static bool ContinueInstallationStep()
        {
            bool ret = false;
            UserControl control = InstallationStep;
            if (control != null)
            {
                if (((IInstallationDialogState)control).CanContinue)
                {
                    if ((installationStepIndex + 1U) < installationSteps.Length)
                    {
                        ++installationStepIndex;
                        ret = true;
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// Redo installation step
        /// </summary>
        /// <returns>"true" if successful, otherwise "false"</returns>
        public static bool RedoInstallationStep()
        {
            bool ret = false;
            UserControl control = InstallationStep;
            if (control != null)
            {
                if (((IInstallationDialogState)control).CanGoBack)
                {
                    if (installationStepIndex != 0U)
                    {
                        --installationStepIndex;
                        ret = true;
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// Invoke awake method
        /// </summary>
        public static void InvokeAwake()
        {
            UserControl control = InstallationStep;
            if (control != null)
            {
                ((IInstallationDialogState)control).Awake();
            }
        }
    }
}
