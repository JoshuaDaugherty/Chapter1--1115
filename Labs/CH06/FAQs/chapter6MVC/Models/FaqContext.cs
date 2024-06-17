using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace chapter6MVC.Models
{
    public class FaqContext : DbContext
    {
        public FaqContext(DbContextOptions<FaqContext> options) : base(options)
        { 
           
        }

        public DbSet<FAQ> FAQs { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Topic> Topics { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "gen", Name = "General" },
                new Category { CategoryId = "hist", Name = "History" }

               

                ) ;

            modelBuilder.Entity<Topic>().HasData(
              new Topic { TopicId = "asp", Name = "ASP.NET Core" },
              new Topic { TopicId = "blz", Name = "Blazor" },
              new Topic { TopicId = "ef", Name = "Entity Framework" }

                );

            modelBuilder.Entity<FAQ>().HasData(
                new FAQ
                {
                    FAQId = 1,
                    Question = "What is ASP.Net Core?",
                    Answer = "ASP.NET Core is a free and open-source web framework",
                    CategoryId = "gen",
                    TopicId = "asp"
                },

                new FAQ
                {
                    FAQId = 2,
                    Question = "When was ASP.NET Core released?",
                    Answer = "ASP.NET Core 1.0 was released on June 27,2016.",
                    CategoryId = "hist",
                    TopicId = "asp"
                },
                new FAQ
                {
                    FAQId = 3,
                    Question = "What is Blazer?",
                    Answer = "Blazer is a Free and open-source web framework",
                    CategoryId = "gen",
                    TopicId = "blz"
                },
                new FAQ
                {
                    FAQId = 4,
                    Question = "When was Blazor released?",
                    Answer = "Blazor was released on May 14 2020",
                    CategoryId = "hist",
                    TopicId = "blz"
                },
                new FAQ 
                {
                FAQId = 5,
                Question = "What is Entity Framework?",
                Answer = "Open source ORM framework",
                CategoryId = "gen",
                TopicId = "ef"
                },

                new FAQ
                {
                    FAQId = 6,
                    Question = "When was Entity Framework released?",
                    Answer = "Entity Framework 1.0 was released in 2008",
                    CategoryId = "hist",
                    TopicId = "ef"
                }

                ) ;


        }

    }
}
