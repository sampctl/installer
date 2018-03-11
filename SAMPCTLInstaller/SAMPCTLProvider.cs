using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;

/// <summary>
/// sampctl Installer namespace
/// </summary>
namespace SAMPCTLInstaller
{
    /// <summary>
    /// sampctl provider class
    /// </summary>
    public static class SAMPCTLProvider
    {
        /// <summary>
        /// sampctl file name
        /// </summary>
        public static readonly string SAMPCTLFileName = "sampctl.exe";

        /// <summary>
        /// sampctl archive file name
        /// </summary>
        public static readonly string SAMPCTLArchiveFileName = "sampctl.tar.gz";

        /// <summary>
        /// GitHub API URI
        /// </summary>
        private static readonly string GitHubAPIURI = "https://api.github.com/repos/Southclaws/sampctl/releases/latest";

        /// <summary>
        /// Website URI
        /// </summary>
        public static readonly string WebsiteURI = "http://sampctl.com/";

        /// <summary>
        /// Standard out
        /// </summary>
        private static TextWriter stdOut;

        /// <summary>
        /// Standard error
        /// </summary>
        private static TextWriter stdErr;

        /// <summary>
        /// Serializer
        /// </summary>
        private static readonly DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(GitHubLatestReleaseDataContract));

        /// <summary>
        /// Latest release
        /// </summary>
        private static GitHubLatestReleaseDataContract latestRelease;

        /// <summary>
        /// Release asset
        /// </summary>
        private static GitHubReleaseAssetDataContract releaseAsset;

        /// <summary>
        /// Standard error
        /// </summary>
        public static TextWriter StdErr
        {
            get
            {
                return stdErr;
            }
            set
            {
                if (stdErr != value)
                {
                    stdErr = value;
                }
            }
        }

        /// <summary>
        /// Write error line
        /// </summary>
        /// <param name="value">Value</param>
        public static void WriteErrorLine(string value)
        {
            if (stdErr != null)
            {
                stdErr.WriteLine(value);
            }
        }

        /// <summary>
        /// Latest release
        /// </summary>
        public static GitHubLatestReleaseDataContract LatestRelease
        {
            get
            {
                if (latestRelease == null)
                {
                    using (WebClientEx wc = new WebClientEx(3000))
                    {
                        wc.Headers.Set(HttpRequestHeader.Accept, "application/json");
                        wc.Headers.Set(HttpRequestHeader.UserAgent, "Mozilla/3.0 (compatible; sampctl Installer)");
                        try
                        {
                            using (MemoryStream stream = new MemoryStream(wc.DownloadData(GitHubAPIURI)))
                            {
                                latestRelease = serializer.ReadObject(stream) as GitHubLatestReleaseDataContract;
                            }
                        }
                        catch (Exception e)
                        {
                            WriteErrorLine(e.Message);
                        }
                    }
                    if (latestRelease == null)
                    {
                        WriteErrorLine("Latest release information is not available");
                    }
                }
                return latestRelease;
            }
        }

        /// <summary>
        /// Release asset
        /// </summary>
        public static GitHubReleaseAssetDataContract ReleaseAsset
        {
            get
            {
                if (LatestRelease != null)
                {
                    string sub_name = (Environment.Is64BitOperatingSystem ? "windows_amd64" : "windows_386");
                    foreach (GitHubReleaseAssetDataContract asset in latestRelease.Assets)
                    {
                        if (asset.Name.Contains(sub_name))
                        {
                            releaseAsset = asset;
                            break;
                        }
                    }
                    if (releaseAsset == null)
                    {
                        WriteErrorLine("Installation package is missing");
                    }
                }
                return releaseAsset;
            }
        }
    }
}
