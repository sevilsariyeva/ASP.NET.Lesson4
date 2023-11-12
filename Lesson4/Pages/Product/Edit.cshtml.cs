using Lesson4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lesson4.Pages.Product
{
    public class EditModel : PageModel
    {
        private readonly ProductDBContext _context;

        public EditModel(ProductDBContext context)
        {
            _context = context;
        }
        public List<Entities.Product> Products { get; set; }
        [BindProperty]
        public Entities.Product Product { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = _context.Products.Find(id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }
        public string Info { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _context.Entry(Product);
            if (entry.State == EntityState.Detached)
            {
                _context.Attach(Product);
                entry.State = EntityState.Modified;
            }

            _context.SaveChanges();
            return RedirectToPage("/Product/Index");
        }

    }
}
