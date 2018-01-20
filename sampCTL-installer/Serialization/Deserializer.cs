using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace sampCTL_installer.Serialization
{
    public class GHAPIAssetData
    {
        public string browser_download_url { get; set; }
        public int size { get; set; }
    }

    class Deserializer
    {
        public static IList<GHAPIAssetData> DeserializeResponse(string Response)
        {

            JObject GHAPIAssets = JObject.Parse(Response);
            IList<JToken> GHAPIExtractedData = GHAPIAssets["assets"].Children().ToList();
            IList<GHAPIAssetData> GHAPIAssetList = new List<GHAPIAssetData>();
            foreach(JToken data in GHAPIExtractedData)
            {
                GHAPIAssetData DeserializedAsset = data.ToObject<GHAPIAssetData>();
                GHAPIAssetList.Add(DeserializedAsset);
            }
            return GHAPIAssetList; 
        }
    }
}
