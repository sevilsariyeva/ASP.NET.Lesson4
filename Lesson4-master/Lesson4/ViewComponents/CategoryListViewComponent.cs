using Lesson4.Data;
using Lesson4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Lesson4.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly ProductDBContext _context;

        public CategoryListViewComponent(ProductDBContext context)
        {
            _context = context;
        }

        public ViewViewComponentResult Invoke()
        {
            var categories = _context.Categories.ToList().Select(c =>
            {
                return new CategoryViewModel
                {
                    Title = c.Title,
                };
            });

            return View(
                new CategoryListViewModel
                {
                    Categories = categories.ToList()
                }
                );
        }
    }
}
