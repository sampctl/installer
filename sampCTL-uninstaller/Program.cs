using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace sampCTL_uninstaller
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            if (MessageBox.Show("Are you sure you want to completely remove sampctl?", "SAMPCTL Uninstaller", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                
            }
            else
            {
                Uninstall();
                MessageBox.Show("sampctl has been successfully removed from your system", "SAMPCTL Uninstaller", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static void Uninstall()
        {
            try
            {
                string InstallPath;
                using (RegistryKey RKeyHKLM = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall", true))
                {
                    if (RKeyHKLM != null)
                    {
                        using (RegistryKey RSubKey = RKeyHKLM.OpenSubKey("sampctl"))
                        {
                            if (RSubKey != null)
                            { 
                                InstallPath = RSubKey.GetValue("InstallLocation").ToString();
                                RSubKey.Close();

                                if (Directory.Exists(InstallPath))
                                {
                                    //--- Remove sampctl path
                                    string PATHEnv = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);
                                    if (PATHEnv.Contains(String.Concat(";", InstallPath)))
                                    {
                                        IList<string> PATHList = PATHEnv.Split(';').ToList();
                                        PATHList.Remove(InstallPath);
                                        string NewPATH = String.Empty;
                                        foreach (string str in PATHList)
                                        {
                                            NewPATH += str + ";";
                                        }
                                        Environment.SetEnvironmentVariable("PATH", NewPATH, EnvironmentVariableTarget.User);
                                        
                                        //--- Remove sampctl files
                                        ProcessStartInfo PInfo = new ProcessStartInfo();
                                        PInfo.Arguments = "/C ping 1.1.1.1 -n 1 -w 3000 > Nul & Del " + Application.ExecutablePath;
                                        PInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                        PInfo.CreateNoWindow = true;
                                        PInfo.FileName = "cmd.exe";
                                        Process.Start(PInfo);

                                        Directory.Delete(InstallPath, true);
                                    }
                                }
                            }
                        }
                        //--- Remove sampctl Uninstall reg key
                        RKeyHKLM.DeleteSubKey("sampctl", true);
                    }
                }
            }
            catch
            {

            }
        }
    }
}
