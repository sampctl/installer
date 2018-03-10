using System;
using System.IO;
using System.Windows.Forms;

/// <summary>
/// sampctl Uninstaller namespace
/// </summary>
namespace SAMPCTLUninstaller
{
    /// <summary>
    /// Uninstaller class
    /// </summary>
    public static class Uninstaller
    {
        /// <summary>
        /// Uninstallation step types
        /// </summary>
        private static readonly Type[] uninstallationStepTypes = new Type[]
        {
            typeof(IntroUserControl),
            typeof(ProgressUserControl),
            typeof(FinishedUserControl)
        };

        /// <summary>
        /// Failed uninstallation step type
        /// </summary>
        private static readonly Type failedUninstallationStepType = typeof(FailedUserControl);

        /// <summary>
        /// Uninstallation step access update
        /// </summary>
        public static UninstallationStepAccessUpdateEventHandler UninstallationStepAccessUpdate;

        /// <summary>
        /// Uninstallation steps
        /// </summary>
        private static UserControl[] uninstallationSteps;

        /// <summary>
        /// Failed uninstallation step
        /// </summary>
        private static UserControl failedUninstallationStep;

        /// <summary>
        /// Uninstallation step index
        /// </summary>
        private static uint uninstallationStepIndex;

        /// <summary>
        /// Uninstallation error message
        /// </summary>
        private static string uninstallationErrorMessage;

        /// <summary>
        /// Agree on licence
        /// </summary>
        private static bool agreeLicence = false;

        /// <summary>
        /// Destination directory
        /// </summary>
        private static string destinationDirectory;

        /// <summary>
        /// Uninstallation error message
        /// </summary>
        public static string UninstallationErrorMessage
        {
            get
            {
                return uninstallationErrorMessage;
            }
            set
            {
                if (value != null)
                {
                    uninstallationErrorMessage = value;
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
        }

        /// <summary>
        /// Uninstallation step
        /// </summary>
        public static UserControl UninstallationStep
        {
            get
            {
                UserControl ret = null;
                if (uninstallationSteps == null)
                {
                    uninstallationSteps = new UserControl[uninstallationStepTypes.Length];
                }
                ret = ((uninstallationErrorMessage == null) ? uninstallationSteps[uninstallationStepIndex] : failedUninstallationStep);
                if (ret == null)
                {
                    try
                    {
                        ret = Activator.CreateInstance((uninstallationErrorMessage == null) ? uninstallationStepTypes[uninstallationStepIndex] : failedUninstallationStepType) as UserControl;
                        if (ret is IUninstallationDialogState)
                        {
                            if (uninstallationErrorMessage == null)
                            {
                                uninstallationSteps[uninstallationStepIndex] = ret;
                            }
                            else
                            {
                                failedUninstallationStep = ret;
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
                return ((uninstallationErrorMessage == null) ? ((uninstallationStepIndex + 1U) >= uninstallationSteps.Length) : true);
            }
        }

        /// <summary>
        /// Continue uninstallation step
        /// </summary>
        /// <returns>"true" if successful, otherwise "false"</returns>
        public static bool ContinueUninstallationStep()
        {
            bool ret = false;
            UserControl control = UninstallationStep;
            if (control != null)
            {
                if (((IUninstallationDialogState)control).CanContinue)
                {
                    if ((uninstallationStepIndex + 1U) < uninstallationSteps.Length)
                    {
                        ++uninstallationStepIndex;
                        ret = true;
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// Redo uninstallation step
        /// </summary>
        /// <returns>"true" if successful, otherwise "false"</returns>
        public static bool RedoUninstallationStep()
        {
            bool ret = false;
            UserControl control = UninstallationStep;
            if (control != null)
            {
                if (((IUninstallationDialogState)control).CanGoBack)
                {
                    if (uninstallationStepIndex != 0U)
                    {
                        --uninstallationStepIndex;
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
            UserControl control = UninstallationStep;
            if (control != null)
            {
                ((IUninstallationDialogState)control).Awake();
            }
        }
    }
}
