using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// sampctl Uninstaller namespace
/// </summary>
namespace SAMPCTLUninstaller
{
    /// <summary>
    /// Program class
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Main entry point
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                string execution_directory = Directory.GetCurrentDirectory();
                string destination_directory = Path.Combine(Environment.GetEnvironmentVariable("Temp"), "sampctl");
                if (execution_directory.ToLower() == destination_directory.ToLower())
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
                else
                {
                    string destination_path = Path.Combine(destination_directory, Path.GetFileName(Application.ExecutablePath));
                    if (File.Exists(destination_path))
                    {
                        File.Delete(destination_path);
                    }
                    else if (!(Directory.Exists(destination_directory)))
                    {
                        Directory.CreateDirectory(destination_directory);
                    }
                    File.Copy(Application.ExecutablePath, destination_path);
                    ProcessStartInfo psi = new ProcessStartInfo(destination_path);
                    psi.WorkingDirectory = destination_directory;
                    Process.Start(psi);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.Exit();
        }
    }
}
