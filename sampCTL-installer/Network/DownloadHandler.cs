using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.ComponentModel;
using sampCTL_installer.UI;

namespace sampCTL_installer.Network
{
    class DownloadHandler
    {

        public FileStream DownloadedFile { get; private set; }

        private string Link;
        private string TempDir;
        private UIEnvironmentHandler UIEnv;

        private readonly static string APIRequestUserAgent = "SAMPCTL Online Installer Wizard (v0.0.1)";

        public DownloadHandler(UIEnvironmentHandler UIHandler, string DLink, string Path)
        {
            UIEnv = UIHandler;
            Link = DLink;
            TempDir = Path;
        }

        public void DownloadFile()
        {
            Task<FileStream> DLFStream = Task.Factory.StartNew<FileStream>(() =>
            {
                try
                {
                    using (WebClient WClient = new WebClient())
                    {
                        Uri DLUrl = new Uri(Link);

                        string FullTempDir = Path.Combine(TempDir,"sampctl.tmp");

                        WClient.Headers["User-Agent"] = APIRequestUserAgent;
                        WClient.Proxy = GlobalProxySelection.GetEmptyWebProxy();

                        WClient.DownloadFile(DLUrl, FullTempDir);
                        FileStream FStream = File.Open(FullTempDir, FileMode.Open);
                        return FStream;
                    }
                }
                catch (Exception Exc)
                {
                    UIEnv.ExitInstallation(false, "Error: DownloadFile -> " + Exc.Message.ToString());
                    return null;
                }
            });
            DownloadedFile = DLFStream.Result;
        }
    }
}
