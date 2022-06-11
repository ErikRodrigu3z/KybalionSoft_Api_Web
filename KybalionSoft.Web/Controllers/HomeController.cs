using KybalionSoft.Services.HttpClientService;
using KybalionSoft.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KybalionSoft.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClientService _HttpClient;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _HttpClient = new HttpClientService("https://localhost:7247/v1/");
        }

        public async Task<IActionResult> Index()
        {
            //var res = await _HttpClient.Get<string[]>("Account");
            return View();
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