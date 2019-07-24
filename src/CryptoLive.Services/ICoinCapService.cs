using CryptoLive.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoLive.Services
{
    public interface ICoinCapService
    {
        Task<CoinDetail> RetrieveCoinDetails(string coin);
        Task<CoinHistory> RetrieveCoinHistory(string coin, int days);
        Task<List<CryptoModel>> RetrieveFrontValues();
        Task<GlobalData> RetrieveGlobalData();
    }
}
