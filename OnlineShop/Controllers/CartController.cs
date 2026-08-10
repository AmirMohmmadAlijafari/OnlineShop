using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;
using System.Text.Json;

public class CartController : Controller
{
    private readonly ApplicationDbContext _context;

    public CartController(ApplicationDbContext context)
    {
        _context = context;
    }

    private List<CartItem> GetCart()
    {
        var cartJson = Request.Cookies["Cart"];

        if (string.IsNullOrEmpty(cartJson))
        {
            return new List<CartItem>();
        }

        return JsonSerializer.Deserialize<List<CartItem>>(cartJson)
               ?? new List<CartItem>();
    }

    private void SaveCart(List<CartItem> cart)
    {
        var cartJson = JsonSerializer.Serialize(cart);

        var options = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(1),
            HttpOnly = true,
            IsEssential = true
        };

        Response.Cookies.Append("Cart", cartJson, options);
    }

    // نمایش سبد خرید
    public IActionResult Index(string? returnUrl)
    {
        var cart = GetCart();

        var stockMap = _context.Products
            .Where(p => !p.IsDeleted)
            .ToDictionary(p => p.Id, p => p.Stock);

        ViewBag.StockMap = stockMap;
        ViewBag.ReturnUrl = returnUrl ?? Url.Action("Index", "Products");

        return View(cart);
    }

    // افزودن محصول به سبد خرید
    [HttpPost]
    public IActionResult AddToCart(int id, string? returnUrl)
    {
        var product = _context.Products
            .FirstOrDefault(p => p.Id == id && !p.IsDeleted);

        if (product == null)
        {
            return NotFound();
        }

        if (product.Stock <= 0)
        {
            TempData["Error"] = "این محصول ناموجود است و امکان سفارش آن وجود ندارد.";
            return RedirectToAction("Details", "Products", new { id = product.Id });
        }

        var cart = GetCart();

        var item = cart.FirstOrDefault(c => c.ProductId == id);

        if (item == null)
        {
            cart.Add(new CartItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = 1,
                ImageUrl = product.ImageUrl
            });
        }
        else
        {
            if (item.Quantity >= product.Stock)
            {
                TempData["Error"] = "تعداد درخواستی بیشتر از موجودی محصول است.";
                return RedirectToAction("Details", "Products", new { id = product.Id });
            }

            item.Quantity++;
        }

        SaveCart(cart);

        return RedirectToAction("Index", new { returnUrl });
    }

    // افزایش تعداد
    public IActionResult Increase(int id, string? returnUrl)
    {
        var cart = GetCart();

        var item = cart.FirstOrDefault(c => c.ProductId == id);

        if (item != null)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product != null && item.Quantity < product.Stock)
            {
                item.Quantity++;
                SaveCart(cart);
            }
        }

        return RedirectToAction("Index", new { returnUrl });
    }

    // کاهش تعداد
    public IActionResult Decrease(int id, string? returnUrl)
    {
        var cart = GetCart();

        var item = cart.FirstOrDefault(c => c.ProductId == id);

        if (item != null)
        {
            item.Quantity--;

            if (item.Quantity <= 1)
            {
                item.Quantity = 1;
            }

            SaveCart(cart);
        }

        return RedirectToAction("Index", new { returnUrl });
    }

    // حذف کامل یک کالا
    public IActionResult Remove(int id, string? returnUrl)
    {
        var cart = GetCart();

        var item = cart.FirstOrDefault(c => c.ProductId == id);

        if (item != null)
        {
            cart.Remove(item);
            SaveCart(cart);
        }

        return RedirectToAction("Index", new { returnUrl });
    }

    // خالی کردن کل سبد خرید
    public IActionResult Clear(string? returnUrl)
    {
        Response.Cookies.Delete("Cart");
        return RedirectToAction("Index", new { returnUrl });
    }

}