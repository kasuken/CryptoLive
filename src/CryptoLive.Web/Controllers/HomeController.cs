using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CryptoLive.Web.Models;
using CryptoLive.Services;
using CryptoLive.Models;

namespace CryptoLive.Web.Controllers
{
    public class HomeController : Controller
    {
        public ICoinCapService CoinCapService { get; set; }

        public HomeController(ICoinCapService coinCapService)
        {
            CoinCapService = coinCapService;
        }

        public async Task<IActionResult> Index()
        {
            var homeModel = new HomeViewModel();

            homeModel.CryptoList = await CoinCapService.RetrieveFrontValues();
            homeModel.GlobalData = await CoinCapService.RetrieveGlobalData();

            return View(homeModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
