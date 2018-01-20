using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using sampCTL_installer.UI;

namespace sampCTL_installer.Internal
{
    class CompressionHandler
    {
        private Stream Archive;
        private UIEnvironmentHandler UIEnv;

        public CompressionHandler(UIEnvironmentHandler UIHandler, FileStream FStream)
        {
            Archive = FStream;
            UIEnv = UIHandler;
        }

        public void Extract(string Destination)
        {
            try
            {
                Stream GZStream = new GZipInputStream(Archive);
                TarArchive TARArch = TarArchive.CreateInputTarArchive(GZStream);

                TARArch.ExtractContents(Destination);
                File.WriteAllBytes(Path.Combine(Destination, "sampCTL-uninstaller.exe"), Properties.Resources.sampCTL_uninstaller);
                TARArch.Close();
                GZStream.Close();
            }
            catch(Exception Exc)
            {
                UIEnv.ExitInstallation(false, "Error: Extract -> " + Exc.Message.ToString());
            }
        }
    }
}
