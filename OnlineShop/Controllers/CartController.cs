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
        var cartJson = HttpContext.Session.GetString("Cart");

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
        HttpContext.Session.SetString("Cart", cartJson);
    }

    // نمایش سبد خرید
    public IActionResult Index()
    {
        var cart = GetCart();
        return View(cart);
    }

    // افزودن محصول به سبد خرید
    public IActionResult AddToCart(int id)
    {
        var product = _context.Products
            .FirstOrDefault(p => p.Id == id && !p.IsDeleted);

        if (product == null)
        {
            return NotFound();
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
            item.Quantity++;
        }

        SaveCart(cart);

        return RedirectToAction("Index");
    }

    // افزایش تعداد
    public IActionResult Increase(int id)
    {
        var cart = GetCart();

        var item = cart.FirstOrDefault(c => c.ProductId == id);

        if (item != null)
        {
            item.Quantity++;
            SaveCart(cart);
        }

        return RedirectToAction("Index");
    }

    // کاهش تعداد
    public IActionResult Decrease(int id)
    {
        var cart = GetCart();

        var item = cart.FirstOrDefault(c => c.ProductId == id);

        if (item != null)
        {
            item.Quantity--;

            if (item.Quantity <= 0)
            {
                cart.Remove(item);
            }

            SaveCart(cart);
        }

        return RedirectToAction("Index");
    }

    // حذف کامل یک کالا
    public IActionResult Remove(int id)
    {
        var cart = GetCart();

        var item = cart.FirstOrDefault(c => c.ProductId == id);

        if (item != null)
        {
            cart.Remove(item);
            SaveCart(cart);
        }

        return RedirectToAction("Index");
    }

    // خالی کردن کل سبد خرید
    public IActionResult Clear()
    {
        HttpContext.Session.Remove("Cart");
        return RedirectToAction("Index");
    }

}