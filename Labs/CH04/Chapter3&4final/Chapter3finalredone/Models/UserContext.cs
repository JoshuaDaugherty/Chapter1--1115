using Microsoft.EntityFrameworkCore;
namespace Chapter3finalredone.Models
{
    public class UserContext : DbContext
    {
        //Collection of Users
        public DbSet<User> Users { get; set; } = null!;
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() { UserId = 1, UserName = "Joshua555", Email = "killerclutch@gmail.com", Reason = "Lose weight."},
                new User() { UserId = 2, UserName = "Random616", Email = "Random616@gmail.com", Reason = "Gain weight." },
                new User() { UserId = 3, UserName = "CoolBeans83", Email = "CoolBeans83@gmail.com", Reason = "I want to jump higher." },
                new User() { UserId = 4, UserName = "Fitnessguy454", Email = "Fitnessguy454@gmail.com", Reason = "I want to fill out shirts." }



                );
        }
    }
}
