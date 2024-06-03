using Microsoft.EntityFrameworkCore;

namespace ContactPROJ.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options) 
        {

        }

        public DbSet<Contact> Contacts { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Family" },
                new Category { CategoryId = 2, Name = "Friend" },
                new Category { CategoryId = 3, Name = "Work" }
                );

            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    FirstName = "Josh",
                    LastName = "Daughety",
                    PhoneNumber = "123-456-7890",
                    Email = "snappyd124@gmail.com",
                    CategoryId = 1
                },

                new Contact
                {
                    ContactId = 2,
                    FirstName = "Jake",
                    LastName = "Daughety",
                    PhoneNumber = "123-456-7890",
                    Email = "snappyd124@gmail.com",
                    CategoryId = 1
                },

                new Contact
                {
                    ContactId = 3,
                    FirstName = "Jaz",
                    LastName = "Daughety",
                    PhoneNumber = "123-456-7890",
                    Email = "snappyd124@gmail.com",
                    CategoryId = 2
                }
                );
        }

    }
}
