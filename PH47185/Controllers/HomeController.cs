using Microsoft.AspNetCore.Mvc;
using PH47185.Data;
using PH47185.Models;
using System.Diagnostics;

namespace PH47185.Controllers
{
    public class HomeController : Controller
    {
		private readonly PH47185Context _context;

		public HomeController(PH47185Context context)
		{
			_context = context;
		}

		public IActionResult Index()
        {
            return View(_context.Product.ToList());
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
