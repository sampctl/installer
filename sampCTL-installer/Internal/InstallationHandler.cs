using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;

using Microsoft.Win32;

using sampCTL_installer.UI;
using sampCTL_installer.Network;
using sampCTL_installer.Internal;

namespace sampCTL_installer.Internal
{
    class InstallationHandler
    {
        private UIEnvironmentHandler UIEnv;
        private StateHandler UIState;
        private BackgroundWorker BGWorker;
        private string InstallPath;
        private string DownloadPath;
        private string SCTLVersion;

        public InstallationHandler(UIEnvironmentHandler UIHandler, StateHandler UIStateHandler)
        {
            UIEnv = UIHandler;
            UIState = UIStateHandler;

            BGWorker = new BackgroundWorker();
            BGWorker.DoWork += new DoWorkEventHandler(InitializeInstallation);
            BGWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(FinalizeInstallation);
        }

        public void SetInstallationPath(string InstPath)
        {
            InstallPath = InstPath;
            if (!Directory.Exists(InstallPath))
            {
                Directory.CreateDirectory(InstallPath);
            }
        }

        #region "Handlers"
        public void HandleInstallation()
        {
            BGWorker.RunWorkerAsync();
        }

        public void HandleInstallationCleanup()
        {
            PerformGenericCleanup();
        }

        public void HandleFailureCleanup()
        {
            PerformGenericCleanup();
            DeleteInstalledFiles();
            RemoveApplication();
            RemovePath();
        }
        #endregion

        #region "BGHandlers"
        private void InitializeInstallation(object s, DoWorkEventArgs a)
        {
             DownloadPath = CreateDownloadEnv();

            UIEnv.UpdateUIProgressControls("Initializing...", false, true);
            UIEnv.UpdateUIProgressControls("Getting latest sampctl release...");
            RequestHandler RQHandler = RequestHandler.GHAPI_CreateRequest(UIEnv);
            SCTLVersion = RQHandler.Version;
            UIEnv.UpdateUIProgressControls("Download Info: File( " + RQHandler.ExportedURL.Replace("https://github.com/Southclaws/sampctl/releases/download","...") + ") Size( " + RQHandler.FileSize + " )");

            DownloadHandler DLHandler = new DownloadHandler(UIEnv, RQHandler.ExportedURL, DownloadPath);
            UIEnv.UpdateUIProgressControls("Downloading sampctl, Please wait...", true, true);
            DLHandler.DownloadFile();
            UIEnv.UpdateUIProgressControls("Download completed!", true, true);

            UIEnv.UpdateUIProgressControls("Installing sampctl, Please wait...", true, true);
            CompressionHandler CSHandler = new CompressionHandler(UIEnv, DLHandler.DownloadedFile);
            CSHandler.Extract(DownloadPath);
            MoveFilesToInstallPath();
            RegisterPath();
            RegisterApplication();
            UIEnv.UpdateUIProgressControls("Installation completed!", true, true);

        }

        private void FinalizeInstallation(object s, RunWorkerCompletedEventArgs a)
        {
            UIEnv.ExitInstallation(true);
        }
        #endregion

        #region "Utils"
        private string CreateDownloadEnv()
        {
            string DLTempDir = Path.Combine(Path.GetTempPath(), "sampctl_" + Path.GetRandomFileName());
            Directory.CreateDirectory(DLTempDir);
            return DLTempDir;
        }


        private void MoveFilesToInstallPath()
        {
            try
            {
                string[] Files = Directory.GetFiles(DownloadPath);
                foreach(string file in Files)
                {
                    FileInfo Info = new FileInfo(file);
                    if (Info.Name != "sampctl.tmp")
                    {
                        string Target = Path.Combine(InstallPath, Info.Name);
                        if(File.Exists(Target))
                        {
                            File.Delete(Target);
                        }
                        Info.MoveTo(Target);
                    }
                }
            }
            catch(Exception Exc)
            {
                UIEnv.ExitInstallation(false, "Error: MoveFilesToInstallPath -> " + Exc.Message.ToString());
            }
        }

        private void RegisterApplication()
        {
            try
            {

                using (RegistryKey RKeyHKLM = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall", true))
                {
                    if (RKeyHKLM != null)
                    {
                        RegistryKey RSubKey = RKeyHKLM.CreateSubKey("sampctl");
                        RSubKey.SetValue("DisplayName", "sampctl " + SCTLVersion);
                        RSubKey.SetValue("DisplayIcon", Path.Combine(InstallPath, "sampCTL-uninstaller.exe"));
                        RSubKey.SetValue("Publisher", "Barnaby Keene");
                        RSubKey.SetValue("DisplayVersion", SCTLVersion);
                        RSubKey.SetValue("URLInfoAbout", "https://sampctl.com");
                        RSubKey.SetValue("Contact", "southclaws@gmail.com");
                        RSubKey.SetValue("InstallLocation", InstallPath);
                        RSubKey.SetValue("InstallDate", DateTime.Now.ToString("yyyyMMdd"));
                        RSubKey.SetValue("UninstallString", Path.Combine(InstallPath, "sampCTL-uninstaller.exe"));
                        RSubKey.Close();
                    }
                }
            }
            catch
            {
            }
        }

        private void RemoveApplication()
        {
            try
            {

                using (RegistryKey RKeyHKLM = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall", true))
                {
                    if (RKeyHKLM != null)
                    {
                        RKeyHKLM.DeleteSubKey("sampctl", false);
                    }
                }
            }
            catch
            {
            }
        }

        private void RegisterPath()
        {
            try
            {
                string PATHEnv = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);
                if (!PATHEnv.Contains(String.Concat(";", InstallPath)))
                {
                    Environment.SetEnvironmentVariable("PATH", String.Concat(PATHEnv, ";", InstallPath), EnvironmentVariableTarget.User);
                }
            }
            catch(Exception Exc)
            {
                UIEnv.ExitInstallation(false, "Error: RegisterPath -> " + Exc.Message.ToString());
            }
        }

        private void RemovePath()
        {
            string PATHEnv = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);
            if (PATHEnv.Contains(String.Concat(";", InstallPath)))
            {
                IList<string> PATHList = PATHEnv.Split(';').ToList();
                PATHList.Remove(InstallPath);
                string NewPATH = String.Empty;
                foreach(string str in PATHList)
                {
                    NewPATH += str + ";";
                }
                Environment.SetEnvironmentVariable("PATH", NewPATH, EnvironmentVariableTarget.User);
            }
        }

        private void PerformGenericCleanup()
        {
            if (Directory.Exists(DownloadPath))
            {
                Directory.Delete(DownloadPath, true);
            }
        }

        private void DeleteInstalledFiles()
        {
            if(Directory.Exists(InstallPath))
            {
                Directory.Delete(InstallPath, true);
            }
        }
        #endregion
    }
}
