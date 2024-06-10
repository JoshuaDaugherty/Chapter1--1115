using Microsoft.EntityFrameworkCore;

namespace SalesOrder.Models
{
    public class SalesOrdersDB : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        public SalesOrdersDB(DbContextOptions<SalesOrdersDB> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, CategoryName = "Components"},
			    new Category() { CategoryId = 2, CategoryName = "Accessories" }


				);

            modelBuilder.Entity<Product>().HasData(
                new Product() { ProductID = 1, ProductName = "AeroFlo ATB Wheels", ProductDescShort = "", ProductDescLong = "", ProductImage = "", ProductPrice = 189.00m, ProductQty = 40, CategoryId = 1 },

                new Product() { ProductID = 2, ProductName = "Clear Shade 85-T Glasses", ProductDescShort = "", ProductDescLong = "", ProductImage = "", ProductPrice = 45.00m, ProductQty = 14, CategoryId = 2 },

                new Product() { ProductID = 3, ProductName = "Cosmic Elite Road Warrior Wheels", ProductDescShort = "", ProductDescLong = "", ProductImage = "", ProductPrice = 165.00m, ProductQty = 22, CategoryId = 1 },

                new Product() { ProductID = 4, ProductName = "Cycle-Doc Pro Repair Stand", ProductDescShort = "", ProductDescLong = "", ProductImage = "", ProductPrice = 166.00m, ProductQty = 12, CategoryId = 2 },

                new Product() { ProductID = 5, ProductName = "Dog Ear Aero-Flow Floor Pump", ProductDescShort = "", ProductDescLong = "", ProductImage = "", ProductPrice = 55.00m, ProductQty = 25, CategoryId = 2 }


                );
        }
    }
}
