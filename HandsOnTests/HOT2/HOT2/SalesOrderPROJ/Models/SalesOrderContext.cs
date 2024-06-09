using Microsoft.EntityFrameworkCore;

namespace SalesOrderPROJ.Models
{
	public class SalesOrderContext : DbContext
	{
		public DbSet<Product> Product { get; set; } = null!;

		public SalesOrderContext(DbContextOptions<SalesOrderContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>().HasData(
				new Product() { ProductID = 1, ProductName = "AeroFlo ATB Wheels", ProductDescShort = "", ProductDescLong = "", ProductImage = "", ProductPrice = 189.00m, ProductQty = 40 },

				new Product() { ProductID = 2, ProductName = "Clear Shade 85-T Glasses", ProductDescShort = "", ProductDescLong = "", ProductImage = "", ProductPrice = 45.00m, ProductQty = 14 },

				new Product() { ProductID = 3, ProductName = "Cosmic Elite Road Warrior Wheels", ProductDescShort = "", ProductDescLong = "", ProductImage = "", ProductPrice = 165.00m, ProductQty = 22 },

				new Product() { ProductID = 4, ProductName = "Cycle-Doc Pro Repair Stand", ProductDescShort = "", ProductDescLong = "", ProductImage = "", ProductPrice = 166.00m, ProductQty = 12 },

				new Product() { ProductID = 5, ProductName = "Dog Ear Aero-Flow Floor Pump", ProductDescShort = "", ProductDescLong = "", ProductImage = "", ProductPrice = 55.00m, ProductQty = 25 }


				);
		}
	}
}
