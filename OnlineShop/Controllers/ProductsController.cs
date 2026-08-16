using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;

public class ProductsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _environment;

    public ProductsController(ApplicationDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    // نمایش محصولات یک دسته
    [AllowAnonymous]
    public IActionResult ByCategory(int id)
    {
        var products = _context.Products
        .Include(p => p.Category)
        .Where(p => p.CategoryId == id && !p.IsDeleted)
        .ToList();

        return View(products);

    }

    // لیست محصولات
    [AllowAnonymous]
    public IActionResult Index(string search, int? categoryId, int page = 1)
    {
        int pageSize = 5;

        var products = _context.Products
            .Include(p => p.Category)
            .Where(p => !p.IsDeleted)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            products = products.Where(p => p.Name.Contains(search));
        }

        if (categoryId.HasValue)
        {
            products = products.Where(p => p.CategoryId == categoryId);
        }

        int totalProducts = products.Count();

        var productList = products
            .OrderByDescending(p => p.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

        ViewBag.Categories = new SelectList(
            _context.Categories,
            "Id",
            "Name",
            categoryId);

        return View(productList);
    }

    // جزئیات محصول
    [AllowAnonymous]
    public IActionResult Details(int id, string? returnUrl)
    {
        var product = _context.Products
        .Include(p => p.Category)
        .FirstOrDefault(p => p.Id == id && !p.IsDeleted);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);

    }

    // فرم افزودن محصول فقط ادمین
    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
        return View();
    }

    // ثبت محصول جدید فقط ادمین
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Product product)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        if (product.ImageFile != null)
        {
            string fileName = Guid.NewGuid() + Path.GetExtension(product.ImageFile.FileName);
            string folderPath = Path.Combine(_environment.WebRootPath, "images", "products");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                product.ImageFile.CopyTo(stream);
            }

            product.ImageUrl = "/images/products/" + fileName;
        }

        product.CreatedAt = DateTime.Now;
        product.UpdatedAt = DateTime.Now;
        product.IsActive = true;
        product.IsDeleted = false;

        _context.Products.Add(product);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    // فرم ویرایش محصول فقط ادمین
    [Authorize(Roles = "Admin")]
    public IActionResult Edit(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id && !p.IsDeleted);

        if (product == null)
            return NotFound();

        ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
        return View(product);
    }

    // ویرایش محصول فقط ادمین
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Product product)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        var dbProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id && !p.IsDeleted);

        if (dbProduct == null)
            return NotFound();

        dbProduct.Name = product.Name;
        dbProduct.Description = product.Description;
        dbProduct.Price = product.Price;
        dbProduct.Stock = product.Stock;
        dbProduct.CategoryId = product.CategoryId;
        dbProduct.IsActive = product.IsActive;
        dbProduct.UpdatedAt = DateTime.Now;

        if (product.ImageFile != null)
        {
            if (!string.IsNullOrEmpty(dbProduct.ImageUrl))
            {
                string oldImagePath = Path.Combine(
                    _environment.WebRootPath,
                    dbProduct.ImageUrl.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString()));

                if (System.IO.File.Exists(oldImagePath))
                    System.IO.File.Delete(oldImagePath);
            }

            string fileName = Guid.NewGuid() + Path.GetExtension(product.ImageFile.FileName);
            string folderPath = Path.Combine(_environment.WebRootPath, "images", "products");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                product.ImageFile.CopyTo(stream);
            }

            dbProduct.ImageUrl = "/images/products/" + fileName;
        }

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    // صفحه حذف محصول فقط ادمین
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(int id)
    {
        var product = _context.Products
            .Include(p => p.Category)
            .FirstOrDefault(p => p.Id == id && !p.IsDeleted);

        if (product == null)
            return NotFound();

        return View(product);
    }

    // حذف محصول فقط ادمین
    [HttpPost, ActionName("Delete")]
    [Authorize(Roles = "Admin")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id && !p.IsDeleted);

        if (product == null)
            return NotFound();

        if (!string.IsNullOrEmpty(product.ImageUrl))
        {
            string imagePath = Path.Combine(
                _environment.WebRootPath,
                product.ImageUrl.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString()));

            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }

        product.IsDeleted = true;
        product.UpdatedAt = DateTime.Now;

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

}