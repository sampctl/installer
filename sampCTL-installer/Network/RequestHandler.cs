using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using sampCTL_installer.Serialization;
using sampCTL_installer.UI;
namespace sampCTL_installer.Network
{
    class RequestHandler
    {
        private readonly static string APIRequestURL = "https://api.github.com/repos/Southclaws/sampctl/releases/latest";
        private readonly static string APIRequestUserAgent = "SAMPCTL Online Installer Wizard (v0.0.1)";
        private static UIEnvironmentHandler UIEnv;

        public string ExportedURL { get; private set; }
        public int FileSize { get; private set; }
        public string Version { get; private set; }

        public static RequestHandler GHAPI_CreateRequest(UIEnvironmentHandler UIHandler)
        {
            UIEnv = UIHandler;
            Task<RequestHandler> RHTask = Task.Factory.StartNew<RequestHandler>(() =>
            {
                string DLink;
                string DVersion;
                int DSize;

                IList<GHAPIAssetData> Data = GHAPI_SendRequest();
                GetArchDownloadInfo(Data, out DLink, out DSize, out DVersion);
                RequestHandler RQHandler = new RequestHandler()
                {
                    ExportedURL = DLink,
                    FileSize = DSize,
                    Version = DVersion
                };
                return RQHandler;
            });
            return RHTask.Result;
        }

        private static IList<GHAPIAssetData> GHAPI_SendRequest()
        {
            try
            {
                HttpWebRequest APIRequest = (HttpWebRequest)HttpWebRequest.Create(APIRequestURL);
                APIRequest.UserAgent = APIRequestUserAgent;
                APIRequest.Proxy = null;
                APIRequest.Timeout = 500;

                Task<IList<GHAPIAssetData>> WRTask = Task.Factory.FromAsync<WebResponse>(APIRequest.BeginGetResponse, AResult => APIRequest.EndGetResponse(AResult), null)
                .ContinueWith(TReq =>
                {
                    string APIResponse;
                    using (Stream RawStream = TReq.Result.GetResponseStream())
                    using (StreamReader SReader = new StreamReader(RawStream))
                    {
                        APIResponse = SReader.ReadToEnd();
                    }
                    IList<GHAPIAssetData> DeserializedData = Deserializer.DeserializeResponse(APIResponse);
                    return DeserializedData;
                });
                return WRTask.Result;
            }
            catch (Exception Exc)
            {
                UIEnv.ExitInstallation(false,"Error: GHAPI_SendRequest -> " + Exc.Message.ToString());
                return null;
            }
        }

        private static void GetArchDownloadInfo(IList<GHAPIAssetData> Assets, out string DLink, out int DSize, out string DVersion)
        {
            Regex LinkPattern = new Regex(Environment.Is64BitOperatingSystem ? ("sampctl_(.+)_windows_amd64.tar.gz") : ("sampctl_(.+)_windows_386.tar.gz"));

            DLink = String.Empty;
            DSize = Int32.MaxValue;
            DVersion = String.Empty;
            try
            {
                foreach (GHAPIAssetData Asset in Assets)
                {
                    Match RMatch = LinkPattern.Match(Asset.browser_download_url);
                    if (RMatch.Success)
                    {
                        DLink = Asset.browser_download_url;
                        DSize = Asset.size;
                        DVersion = RMatch.Groups[1].Value.ToString();
                    }
                }
            }
            catch(Exception Exc)
            {
                UIEnv.ExitInstallation(false, "Error: GetArchDownloadInfo -> " + Exc.Message.ToString());
            }
        }
    }
}
