using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// sampctl Uninstaller namespace
/// </summary>
namespace SAMPCTLUninstaller
{
    /// <summary>
    /// Progress user control class
    /// </summary>
    public partial class ProgressUserControl : UserControl, IUninstallationDialogState
    {
        /// <summary>
        /// Uninstallation has been finished
        /// </summary>
        private bool uninstallationFinished = false;

        /// <summary>
        /// Error messages
        /// </summary>
        private StringBuilder errorMessages = new StringBuilder();

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
                return uninstallationFinished;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProgressUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Write line
        /// </summary>
        /// <param name="value">Value</param>
        private void WriteLine(string value)
        {
            progressRichTextBox.Text = value + Environment.NewLine + progressRichTextBox.Text;
            progressRichTextBox.Refresh();
        }

        /// <summary>
        /// Set error
        /// </summary>
        /// <param name="message">Message</param>
        private void SetError(string message)
        {
            Uninstaller.UninstallationErrorMessage = message;
            uninstallationFinished = true;
            MainForm.Instance.UpdateUninstallationStep();
        }

        /// <summary>
        /// Automaticly continue
        /// </summary>
        private void AutoContinue()
        {
            uninstallationFinished = true;
            if (Uninstaller.ContinueUninstallationStep())
            {
                MainForm.Instance.UpdateUninstallationStep();
            }
        }

        /// <summary>
        /// Awake
        /// </summary>
        public void Awake()
        {
            try
            {
                WriteLine("Getting registry entry...");
                using (RegistryKey uninstall_key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall", true))
                {
                    try
                    {
                        using (RegistryKey app_key = uninstall_key.OpenSubKey("sampctl"))
                        {
                            string destination_directory = app_key.GetValue("InstallLocation").ToString();
                            Directory.Delete(destination_directory, true);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e.Message);
                    }
                    uninstall_key.DeleteSubKey("sampctl");
                    try
                    {
                        ProcessStartInfo psi = new ProcessStartInfo();
                        psi.Arguments = "/C choice /C Y /N /D Y /T 3 & Del " + Application.ExecutablePath;
                        psi.WindowStyle = ProcessWindowStyle.Hidden;
                        psi.CreateNoWindow = true;
                        psi.FileName = "cmd.exe";
                        Process.Start(psi);
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e.Message);
                    }
                    WriteLine("Uninstalled sampctl successfully!");
                    AutoContinue();
                }
            }
            catch (Exception e)
            {
                SetError(e.Message);
            }
        }
    }
}
