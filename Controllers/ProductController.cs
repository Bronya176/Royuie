using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoyuieStore1.Data;
using RoyuieStore1.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RoyuieStore1.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // View all products under a subcategory
        public async Task<IActionResult> SubCategory(int id)
        {
            var products = await _context.Products
                .Where(p => p.SubCategoryId == id)
                .ToListAsync();

            // Get the SubCategory name and pass it to the View
            var subCategoryName = await _context.SubCategories
                .Where(s => s.Id == id)
                .Select(s => s.Name)
                .FirstOrDefaultAsync();

            ViewBag.SubCategoryName = subCategoryName ?? "Products";
            ViewBag.SubCategoryId = id;

            return View(products);
        }

        // View a product detail page
        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products
                .Include(p => p.SubCategory)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}