using Microsoft.AspNetCore.Mvc;
using PH47185.Data;

namespace PH47185.Models
{
	public class Navbar : ViewComponent
	{
		private readonly PH47185Context _context;

		public Navbar(PH47185Context context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke() { return View(_context.Category.ToList());}
	}
}
