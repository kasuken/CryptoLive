using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoLive.Models
{
    public class HomeViewModel
    {
        public GlobalData GlobalData { get; set; }

        public List<CryptoModel> CryptoList { get; set; }
    }
}