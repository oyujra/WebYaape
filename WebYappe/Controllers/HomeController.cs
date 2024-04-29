using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Transactions;
using WebYappe.Models;
using WebYappe.Services;

namespace WebYappe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConsumirAPIService _consumirAPIService;
        public HomeController(IConsumirAPIService consumirAPIService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _consumirAPIService = consumirAPIService;
            
        }

        public async Task<IActionResult> Index()
        {
            var token = await _consumirAPIService.GenerateToken();

            var exchangeRatesList = await _consumirAPIService.ExchangeRates(token);
            return View(exchangeRatesList);
        }
        public async Task<IActionResult> Edit(string Id, string SourceCurrency, string TargetCurrency, string Rate, string Amount, string AmountWithExchangeRate)
        {
            var token = await _consumirAPIService.GenerateToken();
            ExchangeRates exchangeRates = new ExchangeRates();
            exchangeRates.Id = Convert.ToInt16(Id);
            exchangeRates.SourceCurrency = SourceCurrency;
            exchangeRates.TargetCurrency = TargetCurrency;
            exchangeRates.Rate = Convert.ToDecimal(Rate);
            exchangeRates.Amount = Convert.ToDecimal(Amount);
            exchangeRates.AmountWithExchangeRate = Convert.ToDecimal(AmountWithExchangeRate);
            return View(exchangeRates);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Update()
        {
            var token = await _consumirAPIService.GenerateToken();
            ExchangeRatesPut exchangeRatesPost = new ExchangeRatesPut();
            exchangeRatesPost.Id = Convert.ToInt16(Request.Form["Id"]);
            exchangeRatesPost.Rate = Convert.ToDecimal(Request.Form["Rate"]);
            var exchangeRates = await _consumirAPIService.PutExchangeRates(exchangeRatesPost, token);
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}