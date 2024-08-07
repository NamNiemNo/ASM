using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PH47185.Data;
using PH47185.Models;

namespace PH47185.Controllers
{
    public class ProductsController : Controller
    {
        private readonly PH47185Context _context;

        public ProductsController(PH47185Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var pH47185Context = _context.Product.Include(p => p.category);
            return View(await pH47185Context.ToListAsync());
        }
        [HttpPost]
		public async Task<IActionResult> Index(int catid, string keywords)
		{
			var pH47185Context = _context.Product.Include(p => p.category).Where(p => p.Name.Contains(keywords) && p.CategoryId == catid);
			return View(await pH47185Context.ToListAsync());
		}
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            LoadCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private void LoadCategories(object selectedCategory = null)
        {
            var categoriesQuery = from c in _context.Category
                                  orderby c.Name
                                  select c;

            ViewBag.CategoryId = new SelectList(categoriesQuery.AsNoTracking(), "Id", "Name", selectedCategory);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            LoadCategories();
            var product = _context.Product.SingleOrDefault(x => x.Id == id);
            return View(product);
        }


        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var pr = _context.Product.SingleOrDefault(x => x.Id == product.Id);
            pr.Name = product.Name;
            pr.Price = product.Price;
            pr.Description = product.Description;
            pr.Img = product.Img;
            pr.CategoryId = product.CategoryId;
            pr.Quantity = product.Quantity;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            var pr = _context.Product.Find(id);
            if (pr == null)
            {
                return NotFound();
            }
            return View(pr);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            var pr = _context.Product.Find(id);
            if (pr == null)
            {
                return NotFound();
            }

            _context.Product.Remove(pr);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
   