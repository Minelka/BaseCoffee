using BaseCoffee.DAL.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BaseCoffee.DAL.Context
{
    public class MyDbContext : IdentityDbContext<AppUser, IdentityRole<string>, string>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<IdentityRole<string>> IdentityRoles { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole<string>>().HasData(
                new IdentityRole<string> { Id= "c9bbce7e-7372-47f2-80e9-029ce117f245", Name="Customer", NormalizedName="CUSTOMER"},
                new IdentityRole<string> { 
                Id= "329d3be5-8001-4997-85a9-ebc16be771c2",
                Name="Admin",
                NormalizedName = "ADMIN"
                }
                );
            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = "252d1809-cd07-4ebd-87d1-83cefac3b78c",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin123."),
                SecurityStamp = "87b82a5e-69c1-4831-87d0-678b208084ae",
                ConcurrencyStamp = "55c5fc1a-1d71-4de4-b65e-e14eed798ade",
                LockoutEnabled = false
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "329d3be5-8001-4997-85a9-ebc16be771c2",
                UserId = "252d1809-cd07-4ebd-87d1-83cefac3b78c"
            });

            base.OnModelCreating(modelBuilder);
            // Kategorileri Seed Et
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Beverages", Description = "Hot and cold drinks" },
                new Category { Id = 2, Name = "Snacks", Description = "Light snacks and appetizers" },
                new Category { Id = 3, Name = "Desserts", Description = "Sweet treats" },
                new Category { Id = 4, Name = "Breakfast", Description = "Morning meals" }
            );

            // Ürünleri Seed Et
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, CategoryID = 1, Name = "Coffee", Price = 3.50m, Description = "Freshly brewed coffee", StockQuantity = 50 },
                new Product { Id = 2, CategoryID = 1, Name = "Tea", Price = 2.50m, Description = "Assorted teas", StockQuantity = 60 },
                new Product { Id = 3, CategoryID = 2, Name = "Sandwich", Price = 5.00m, Description = "Grilled cheese sandwich", StockQuantity = 30 },
                new Product { Id = 4, CategoryID = 2, Name = "Chips", Price = 1.50m, Description = "Bag of potato chips", StockQuantity = 100 },
                new Product { Id = 5, CategoryID = 3, Name = "Cake", Price = 4.00m, Description = "Slice of chocolate cake", StockQuantity = 20 },
                new Product { Id = 6, CategoryID = 4, Name = "Pancakes", Price = 5.00m, Description = "Fluffy pancakes with syrup", StockQuantity = 15 },
                new Product { Id = 7, CategoryID = 4, Name = "Omelette", Price = 4.00m, Description = "Three-egg omelette", StockQuantity = 25 }
            );

            // Siparişleri Seed Et
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, OrderDate = DateTime.Now.AddDays(-2), TotalAmount = 9.50m, Status = "Completed" },
                new Order { Id = 2, OrderDate = DateTime.Now.AddDays(-1), TotalAmount = 6.50m, Status = "Pending" },
                new Order { Id = 3, OrderDate = DateTime.Now, TotalAmount = 15.00m, Status = "Processing" }
            );

            // Sipariş Detaylarını Seed Et
            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail { Id = 1, OrderID = 1, ProductID = 1, Quantity = 2, UnitPrice = 3.50m },
                new OrderDetail { Id = 2, OrderID = 1, ProductID = 3, Quantity = 1, UnitPrice = 5.00m },
                new OrderDetail { Id = 3, OrderID = 2, ProductID = 2, Quantity = 1, UnitPrice = 2.50m },
                new OrderDetail { Id = 4, OrderID = 2, ProductID = 5, Quantity = 1, UnitPrice = 4.00m },
                new OrderDetail { Id = 5, OrderID = 3, ProductID = 6, Quantity = 2, UnitPrice = 5.00m },
                new OrderDetail { Id = 6, OrderID = 3, ProductID = 7, Quantity = 1, UnitPrice = 4.00m }
            );

            // Sepetleri Seed Et
            modelBuilder.Entity<Cart>().HasData(
                new Cart { Id = 1, ProductID = 1, Quantity = 3 },
                new Cart { Id = 2, ProductID = 4, Quantity = 2 },
                new Cart { Id = 3, ProductID = 6, Quantity = 1 },
                new Cart { Id = 4, ProductID = 7, Quantity = 1 }
            );
        }

    }

    
}
