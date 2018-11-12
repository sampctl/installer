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
        private bool uninstallationFinished;

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
                    string destination_directory = null;
                    try
                    {
                        using (RegistryKey app_key = uninstall_key.OpenSubKey("sampctl"))
                        {
                            object destination_directory_obj = app_key.GetValue("InstallLocation");
                            if (destination_directory_obj != null)
                            {
                                destination_directory = destination_directory_obj.ToString();
                                Directory.Delete(destination_directory, true);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e.Message);
                    }
                    uninstall_key.DeleteSubKey("sampctl");
                    if (destination_directory != null)
                    {
                        try
                        {
                            WriteLine("Modifying %PATH% environment variable...");
                            string[] env_var_vals = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine).Split(';');
                            StringBuilder env_var_val = new StringBuilder();
                            string low_destination_directory = destination_directory.Trim('\\').Trim('/').ToLower();
                            bool first = true;
                            foreach (string val in env_var_vals)
                            {
                                if (val.Length > 0)
                                {
                                    if (val.Trim('\\').Trim('/').ToLower() != low_destination_directory)
                                    {
                                        if (first)
                                        {
                                            first = false;
                                        }
                                        else
                                        {
                                            env_var_val.Append(";");
                                        }
                                        env_var_val.Append(val);
                                    }
                                }
                            }
                            Environment.SetEnvironmentVariable("PATH", env_var_val.ToString(), EnvironmentVariableTarget.Machine);
                            WriteLine("%PATH% environment variable has been successfully modified!");
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine(ex.Message);
                        }
                    }
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
