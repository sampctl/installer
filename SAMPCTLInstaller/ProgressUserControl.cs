﻿using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// sampctl Installer namespace
/// </summary>
namespace SAMPCTLInstaller
{
    /// <summary>
    /// Progress user control class
    /// </summary>
    public partial class ProgressUserControl : UserControl, IInstallationDialogState
    {
        /// <summary>
        /// Installation has finished
        /// </summary>
        private bool installationFinished;

        /// <summary>
        /// Error messages
        /// </summary>
        private StringBuilder errorMessages = new StringBuilder();

        /// <summary>
        /// Download directory
        /// </summary>
        private string downloadDirectory;

        /// <summary>
        /// Download path
        /// </summary>
        private string downloadPath;

        /// <summary>
        /// Asset
        /// </summary>
        private GitHubReleaseAssetDataContract releaseAsset;

        /// <summary>
        /// Uninstall registry key
        /// </summary>
        private static readonly string uninstallRegistryKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall";

        /// <summary>
        /// sampctl registry sub key
        /// </summary>
        private static readonly string sampctlRegistrySubKey = "sampctl";

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
                return installationFinished;
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
            Installer.InstallationErrorMessage = message;
            installationFinished = true;
            MainForm.Instance.UpdateInstallationStep();
        }

        /// <summary>
        /// Awake
        /// </summary>
        public void Awake()
        {
            SAMPCTLProvider.StdErr = new StringWriter(errorMessages);
            WriteLine("Looking for release information...");
            ServicePointManager.ServerCertificateValidationCallback += OnValidateRemoteCertificate;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            releaseAsset = SAMPCTLProvider.ReleaseAsset;
            if (releaseAsset == null)
            {
                SetError(errorMessages.ToString());
            }
            else
            {
                try
                {
                    downloadDirectory = Path.Combine(Environment.GetEnvironmentVariable("Temp"), "sampctl");
                    downloadPath = Path.Combine(downloadDirectory, SAMPCTLProvider.SAMPCTLArchiveFileName);
                    WriteLine("Downloading package \"" + releaseAsset.Name + "\" from \"" + releaseAsset.BrowserDownloadURL + "\"...");
                    WebClient wc = new WebClient();
                    wc.Headers.Set(HttpRequestHeader.UserAgent, "Mozilla/3.0 (compatible; sampctl Installer)");
                    wc.DownloadProgressChanged += OnDownloadProgressChanged;
                    wc.DownloadFileCompleted += OnDownloadFileCompleted;
                    if (File.Exists(downloadPath))
                    {
                        File.Delete(downloadPath);
                    }
                    else if (!(Directory.Exists(downloadDirectory)))
                    {
                        Directory.CreateDirectory(downloadDirectory);
                    }
                    wc.DownloadFileAsync(new Uri(releaseAsset.BrowserDownloadURL), downloadPath);
                    TaskbarProgress.SetState(MainForm.Instance, TaskbarProgress.TaskbarStates.Normal);
                }
                catch (Exception e)
                {
                    SetError(e.Message);
                }
            }
        }

        /// <summary>
        /// On download progress changed event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Download progress changed event arguments</param>
        private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            installationProgressBar.Maximum = (int)(e.TotalBytesToReceive);
            installationProgressBar.Value = (int)(e.BytesReceived);
            TaskbarProgress.SetValue(MainForm.Instance, e.BytesReceived, e.TotalBytesToReceive);
        }

        /// <summary>
        /// Export resource
        /// </summary>
        /// <param name="resourceName">Resource name</param>
        /// <param name="destinationPath">Destination path</param>
        private void ExportResource(string resourceName, string destinationPath)
        {
            try
            {
                WriteLine("Exporting \"" + resourceName + "\" to \"" + destinationPath + "\"...");
                if (File.Exists(destinationPath))
                {
                    File.Delete(destinationPath);
                }
                using (Stream resource_stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    if (resource_stream == null)
                    {
                        WriteLine("Failed to export \"" + resourceName + "\" to \"" + destinationPath + "\"");
                    }
                    else
                    {
                        using (Stream file_stream = File.OpenWrite(destinationPath))
                        {
                            resource_stream.CopyTo(file_stream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLine("Failed to export \"" + resourceName + "\" to \"" + destinationPath + "\"");
                Console.Error.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Automaticly continue
        /// </summary>
        private void AutoContinue()
        {
            installationFinished = true;
            if (Installer.ContinueInstallationStep())
            {
                MainForm.Instance.UpdateInstallationStep();
            }
        }

        /// <summary>
        /// On download file completed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Async completed event arguments</param>
        private void OnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                SetError(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                SetError("Download has been canceled.");
            }
            else
            {
                try
                {
                    bool failure = true;
                    string destination_directory = Installer.DestinationDirectory;
                    string destination_path = Path.Combine(destination_directory, SAMPCTLProvider.SAMPCTLFileName);
                    if (File.Exists(downloadPath))
                    {
                        try
                        {
                            WriteLine("Deleting existing binaries and registry entries...");
                            using (RegistryKey uninstall_key = Registry.LocalMachine.OpenSubKey(uninstallRegistryKey, true))
                            {
                                foreach (string sub_key in uninstall_key.GetSubKeyNames())
                                {
                                    if (sub_key == sampctlRegistrySubKey)
                                    {
                                        using (RegistryKey app_key = uninstall_key.OpenSubKey(sampctlRegistrySubKey))
                                        {
                                            object install_location_obj = app_key.GetValue("InstallLocation");
                                            if (install_location_obj != null)
                                            {
                                                string install_location = install_location_obj.ToString();
                                                try
                                                {
                                                    if (Directory.Exists(install_location))
                                                    {
                                                        Directory.Delete(install_location, true);
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.Error.WriteLine(ex.Message);
                                                }
                                            }
                                        }
                                        uninstall_key.DeleteSubKey(sampctlRegistrySubKey);
                                        break;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine(ex.Message);
                        }
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
                        try
                        {
                            WriteLine("Unpacking \"" + downloadPath + "\" content to \"" + destination_path + "\"...");
                            using (FileStream archive_file_stream = File.Open(downloadPath, FileMode.Open))
                            {
                                using (GZipInputStream gzip_stream = new GZipInputStream(archive_file_stream))
                                {
                                    using (TarInputStream tar_stream = new TarInputStream(gzip_stream))
                                    {
                                        TarEntry tar_entry;
                                        while ((tar_entry = tar_stream.GetNextEntry()) != null)
                                        {
                                            if (!(tar_entry.IsDirectory))
                                            {
                                                if (tar_entry.Name == SAMPCTLProvider.SAMPCTLFileName)
                                                {
                                                    if (File.Exists(destination_path))
                                                    {
                                                        File.Delete(destination_path);
                                                    }
                                                    else if (!(Directory.Exists(destination_directory)))
                                                    {
                                                        Directory.CreateDirectory(destination_directory);
                                                    }
                                                    using (FileStream file_stream = File.Open(destination_path, FileMode.Create))
                                                    {
                                                        tar_stream.CopyEntryContents(file_stream);
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            try
                            {
                                WriteLine("Modifying %PATH% environment variable...");
                                string env_var_val = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);
                                if ((!(string.IsNullOrEmpty(env_var_val))) && (!(env_var_val.EndsWith(";"))))
                                {
                                    env_var_val += ';';
                                }
                                Environment.SetEnvironmentVariable("PATH", env_var_val + destination_directory, EnvironmentVariableTarget.Machine);
                                WriteLine("%PATH% environment variable has been successfully modified!");
                                try
                                {
                                    WriteLine("Writing data to registry...");
                                    using (RegistryKey uninstall_key = Registry.LocalMachine.OpenSubKey(uninstallRegistryKey, true))
                                    {
                                        using (RegistryKey app_key = uninstall_key.CreateSubKey(sampctlRegistrySubKey))
                                        {
                                            GitHubLatestReleaseDataContract latest_release = SAMPCTLProvider.LatestRelease;
                                            app_key.SetValue("DisplayName", "sampctl " + latest_release.Name);
                                            app_key.SetValue("DisplayIcon", Path.Combine(destination_directory, "sampctl.ico"));
                                            app_key.SetValue("Publisher", releaseAsset.Uploader.Login);
                                            app_key.SetValue("DisplayVersion", latest_release.TagName);
                                            app_key.SetValue("URLInfoAbout", SAMPCTLProvider.WebsiteURI);
                                            app_key.SetValue("Contact", "southclaws@gmail.com");
                                            app_key.SetValue("InstallLocation", destination_directory);
                                            app_key.SetValue("InstallDate", DateTime.Now.ToString("yyyyMMdd"));
                                            app_key.SetValue("UninstallString", Path.Combine(destination_directory, "SAMPCTLUninstaller.exe"));
                                            ExportResource("SAMPCTLInstaller.sampctl.ico", Path.Combine(destination_directory, "sampctl.ico"));
                                            ExportResource("SAMPCTLInstaller.SAMPCTLUninstaller.exe", Path.Combine(destination_directory, "SAMPCTLUninstaller.exe"));
                                            WriteLine("Installation has been finished!");
                                            failure = false;
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.Error.WriteLine(ex.Message);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.Error.WriteLine(ex.Message);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine(ex.Message);
                        }
                        try
                        {
                            Directory.Delete(downloadDirectory, true);
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine(ex.Message);
                        }
                    }
                    if (failure)
                    {
                        SetError("sampctl installation has failed");
                    }
                }
                catch (Exception ex)
                {
                    SetError(ex.Message);
                }
            }
            AutoContinue();
        }

        /// <summary>
        /// On validate remote certificate event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="cert">Certification</param>
        /// <param name="chain">Chain</param>
        /// <param name="error">Error</param>
        /// <returns>"true" if allowed, otherwise "false"</returns>
        private bool OnValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            bool ret = (error == SslPolicyErrors.None);
            if (!ret)
            {
                SetError("X509Certificate [" + cert.Subject + "] policy error: \"" + error + "\"");
            }
            return ret;
        }
    }
}
