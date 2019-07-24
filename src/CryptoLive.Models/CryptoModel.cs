using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoLive.Models
{
    public class CryptoModel
    {
        [JsonProperty("cap24hrChange")]
        public double Cap24HrChange { get; set; }

        [JsonProperty("long")]
        public string Long { get; set; }

        [JsonProperty("mktcap")]
        public double Mktcap { get; set; }

        public string MktcapDollar { get; set; }

        [JsonProperty("perc")]
        public double Perc { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        public string PriceDollar { get; set; }

        [JsonProperty("shapeshift")]
        public bool Shapeshift { get; set; }

        [JsonProperty("short")]
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
