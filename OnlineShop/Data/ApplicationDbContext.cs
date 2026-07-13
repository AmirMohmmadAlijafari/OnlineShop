using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<ProductImage> ProductImages => Set<ProductImage>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasOne(c => c.Parent)
                .WithMany(c => c.Children)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>().HasData(

                new Category
                {
                    Id = 1,
                    Name = "لپ تاپ"
                },

                new Category
                {
                    Id = 2,
                    Name = "موبایل"
                },

                new Category
                {
                    Id = 3,
                    Name = "مانیتور"
                },

                new Category
                {
                    Id = 4,
                    Name = "تبلت"
                }

            
            );

            modelBuilder.Entity<Product>().HasData(

                new Product
                {
                    Id = 1,
                    Name = "Laptop Dell",
                    Price = 35000000,
                    Stock = 5,
                    CategoryId = 1
                },

                new Product
                {
                    Id = 2,
                    Name = "HP Laptop",
                    Price = 42000000,
                    Stock = 7,
                    CategoryId = 1
                },

                new Product
                {
                    Id = 3,
                    Name = "Samsung S25",
                    Price = 58000000,
                    Stock = 12,
                    CategoryId = 2
                },

                new Product
                {
                    Id = 4,
                    Name = "iPhone 17",
                    Price = 98000000,
                    Stock = 4,
                    CategoryId = 2
                },

                new Product
                {
                    Id = 5,
                    Name = "LG 27 Inch",
                    Price = 15000000,
                    Stock = 10,
                    CategoryId = 3
                },

                new Product
                {
                    Id = 6,
                    Name = "Samsung Odyssey",
                    Price = 23000000,
                    Stock = 6,
                    CategoryId = 3
                },

                new Product
                {
                    Id = 7,
                    Name = "iPad Air",
                    Price = 47000000,
                    Stock = 8,
                    CategoryId = 4
                },

                new Product
                {
                    Id = 8,
                    Name = "Galaxy Tab S10",
                    Price = 36000000,
                    Stock = 9,
                    CategoryId = 4
                }

            
            );
        }
    }
}