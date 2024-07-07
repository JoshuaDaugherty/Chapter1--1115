using Microsoft.EntityFrameworkCore;

namespace CrackersPROJ.Models
{
    public class CrackerContext : DbContext
    {
        public CrackerContext(DbContextOptions<CrackerContext> options)
                    : base(options)
        {
        }

        public DbSet<Crackers> Crackers { get; set; }
		public DbSet<Purchase> Purchases { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crackers>().HasData(
                new Crackers { CrackersId = 1, Invented = "1933", Calories = 20, Price = "$2.00", Name = "Graham Crackers", ImageFileName = "grahamCrackers.jpg" },
                new Crackers { CrackersId = 2, Invented = "1945", Calories = 25, Price = "$2.50", Name = "Ritz", ImageFileName = "Ritz.jpg" },
                new Crackers { CrackersId = 3, Invented = "1950", Calories = 15, Price = "$3.50", Name = "GoldFish", ImageFileName = "GoldFish.jpg" },
                new Crackers { CrackersId = 4, Invented = "1960", Calories = 8, Price = "$4.50", Name = "Saltine", ImageFileName = "Saltine.jpg" },
                new Crackers { CrackersId = 5, Invented = "1970", Calories = 7, Price = "$4.00", Name = "Animal Crackers", ImageFileName = "animal Crackers.jpg" }
                );

        }
    }
}
