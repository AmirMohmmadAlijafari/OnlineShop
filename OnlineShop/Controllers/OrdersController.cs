using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;
using System.Text.Json;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

        // صفحه نهایی کردن سفارش
        public IActionResult Checkout()
        {
            var cart = GetCart();

            if (!cart.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            ViewBag.Total = cart.Sum(x => x.TotalPrice);

            return View(cart);
        }

        // ثبت سفارش در دیتابیس
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder()
        {
            var cart = GetCart();

            if (!cart.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            foreach (var item in cart)
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == item.ProductId && !p.IsDeleted);

                if (product == null)
                {
                    TempData["Error"] = "یکی از محصولات دیگر وجود ندارد.";
                    return RedirectToAction("Checkout");
                }

                if (product.Stock < item.Quantity)
                {
                    TempData["Error"] =
                        $"موجودی محصول «{product.Name}» کافی نیست. موجودی فعلی: {product.Stock}";

                    return RedirectToAction("Checkout");
                }
            }

            var currentUser = await _userManager.GetUserAsync(User);

            var order = new Order
            {
                UserId = currentUser?.Id,
                CustomerName = currentUser?.FullName ?? "کاربر",
                CustomerPhone = "-",
                OrderDate = DateTime.Now,
                Status = "ثبت شده",
                TotalAmount = cart.Sum(x => x.TotalPrice)
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            foreach (var item in cart)
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == item.ProductId);

                if (product != null)
                {
                    product.Stock -= item.Quantity;

                    var orderItem = new OrderItem
                    {
                        OrderId = order.Id,
                        ProductId = product.Id,
                        Quantity = item.Quantity,
                        UnitPrice = item.Price,
                        TotalPrice = item.TotalPrice
                    };

                    _context.OrderItems.Add(orderItem);
                }
            }

            _context.SaveChanges();

            Response.Cookies.Delete("Cart");

            return RedirectToAction("Success");
        }

        // صفحه موفقیت سفارش
        public IActionResult Success()
        {
            return View();
        }

        public async Task<IActionResult> MyOrders()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var orders = _context.Orders
                .Where(o => o.UserId == currentUser.Id)
                .OrderByDescending(o => o.OrderDate)
                .ToList();

            return View(orders);
        }

        // لیست سفارش‌ها (فقط برای ادمین)
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var orders = _context.Orders
                .OrderByDescending(o => o.OrderDate)
                .ToList();

            return View(orders);
        }

        // جزئیات سفارش

        public IActionResult Details(int id, string? returnUrl)
        {
            var order = _context.Orders
            .Where(o => o.Id == id)
            .Select(o => new
            {
                Order = o,
                Items = _context.OrderItems
            .Where(oi => oi.OrderId == o.Id)
            .Select(oi => new
            {
                oi.Quantity,
                oi.UnitPrice,
                oi.TotalPrice,
                ProductName = oi.Product.Name
            }).ToList()
            })
            .FirstOrDefault();

            if (order == null)
            {
                return NotFound();
            }

            ViewBag.ReturnUrl = returnUrl ?? Url.Action("MyOrders", "Orders");

            return View(order);

        }
    }

}