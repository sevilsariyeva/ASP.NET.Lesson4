using Lesson4.Data;
using Lesson4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lesson4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductDBContext _context;

        public HomeController(ProductDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList().Select(p =>
            {
                return new ProductViewModel
                {
                    Name = p.Name,
                    Price = p.Price,
                };
            });

            var categories = _context.Categories.ToList().Select((c) =>
            {
                return new CategoryViewModel
                {
                    Title = c.Title
                };
            });

            var vm = new ProductListViewModel
            {
                Products = products,
                Categories = categories
            };
            return View(vm);
        }
    }
}