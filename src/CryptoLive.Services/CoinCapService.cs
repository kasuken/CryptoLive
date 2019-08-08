using CryptoLive.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoLive.Services
{
    public class CoinCapService : ICoinCapService
    {
        const string baseAddress = "https://api.coincap.io";

        public async Task<List<CryptoModel>> RetrieveFrontValues()
        {
            var list = new List<CryptoModel>();

            using (var httpClient = new HttpClient())
            {
                var frontInfo = await httpClient.GetStringAsync($"{baseAddress}/v2/assets");

                list = JsonConvert.DeserializeObject<List<CryptoModel>>(frontInfo);
            }

            foreach (var item in list)
            {
                //item.PriceDollar = item.Price.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));
                //item.MktcapDollar = item.Mktcap.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));
                //item.VolumeDollar = item.Volume.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));

                //item.SupplyFormat = item.Supply.ToString("N", CultureInfo.CreateSpecificCulture("en-US"));
            }

            return list;
        }

        public async Task<GlobalData> RetrieveGlobalData()
        {
            var data = new GlobalData();

            using (var httpClient = new HttpClient())
            {
                var dataInfo = await httpClient.GetStringAsync($"{baseAddress}/global");

                data = JsonConvert.DeserializeObject<GlobalData>(dataInfo);
            }

            return data;
        }

        public async Task<CoinDetail> RetrieveCoinDetails(string coin)
        {
            var coinDetail = new CoinDetail();

            using (var httpClient = new HttpClient())
            {
                var coinInfo = await httpClient.GetStringAsync($"{baseAddress}/page/{coin}");

                coinDetail = JsonConvert.DeserializeObject<CoinDetail>(coinInfo);

                coinDetail.SupplyFormat = coinDetail.Supply.ToString("N", CultureInfo.CreateSpecificCulture("en-US"));
                coinDetail.PriceFormat = coinDetail.Price.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));
                coinDetail.MktcapDollar = coinDetail.MarketCap.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));
                coinDetail.VolumeDollar = coinDetail.Volume.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));
            }

            return coinDetail;
        }

        public async Task<CoinHistory> RetrieveCoinHistory(string coin, int days)
        {
            var history = new CoinHistory();

            using (var httpClient = new HttpClient())
            {
                var historyInfo = string.Empty;

                if (days == 0)
                {
                    historyInfo = await httpClient.GetStringAsync($"{baseAddress}/history/{coin}");
                }
                else
                {
                    historyInfo = await httpClient.GetStringAsync($"{baseAddress}/history/{days}DAY/{coin}");
                }

                history = JsonConvert.DeserializeObject<CoinHistory>(historyInfo);
            }

            return history;
        }
    }
}