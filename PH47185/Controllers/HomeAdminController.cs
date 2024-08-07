using Microsoft.AspNetCore.Mvc;
using PH47185.Models;
using System.Diagnostics;

namespace PH47185.Controllers
{
    public class HomeAdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeAdminController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

