using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoLive.Models
{
    public class CryptoModel
    {
        public class Detail
        {
            public string id { get; set; }
            public string rank { get; set; }
            public string symbol { get; set; }
            public string name { get; set; }
            public string supply { get; set; }
            public string maxSupply { get; set; }
            public string marketCapUsd { get; set; }
            public string volumeUsd24Hr { get; set; }
            public string priceUsd { get; set; }
            public string changePercent24Hr { get; set; }
            public string vwap24Hr { get; set; }
        }

        public string Short { get; set; }

        [JsonProperty("supply")]
        public long Supply { get; set; }

        public string SupplyFormat { get; set; }

        [JsonProperty("usdVolume")]
        public long UsdVolume { get; set; }

        [JsonProperty("volume")]
        public long Volume { get; set; }

        public string VolumeDollar { get; set; }

        [JsonProperty("vwapData")]
        public double VwapData { get; set; }

        [JsonProperty("vwapDataBTC")]
        public double VwapDataBtc { get; set; }
    }
}
