using Microsoft.AspNetCore.Mvc;
using royuie.Data;
using royuie.Helpers; //Required to use SetObjectAsJson and GetObjectFromJson//
using royuie.Models;


namespace royuie.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const string CartSessionKey = "CartItems";

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // View Cart
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            return View(cart);
        }

        // Add to Cart
        public IActionResult AddToCart(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();

            var existingItem = cart.FirstOrDefault(i => i.ProductId == id);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    ImagePath = "/images/" + product.ImagePath,
                    Quantity = 1
                });
            }

            HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);
            return RedirectToAction("Index");
        }

        // Remove item
        public IActionResult Remove(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            var item = cart.FirstOrDefault(i => i.ProductId == id);
            if (item != null) cart.Remove(item);
            HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);
            return RedirectToAction("Index");
        }
    }
}
