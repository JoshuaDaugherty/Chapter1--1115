using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
namespace FitnessApp.Models
{
    public class ExcersizeContext : DbContext
    {
        public DbSet<ExerciseLog> ExerciseLog { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public ExcersizeContext(DbContextOptions<ExcersizeContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre()
                {
                    GenreId = "B",
                    Name = "Bodyweight"
                },
				new Genre()
				{
					GenreId = "C",
					Name = "Core"
				},
				new Genre()
				{
					GenreId = "L",
					Name = "Lower body"
				},
				new Genre()
				{
					GenreId = "P",
					Name = "Plyometrics"
				},

				new Genre()
				{
					GenreId = "P",
					Name = "HIIT (High-intensity interval training)"
				}

				);

            modelBuilder.Entity<ExerciseLog>().HasData(
              new ExerciseLog() { ExerciseId = 1,
                                  Workout = "Sqauts",
                                  Activity = "Leg Day",
                                  Sets = 3,
                                  Reps = 8,
                                  Weight = 200,
                                   GenreId = "P"},


              new ExerciseLog() { ExerciseId = 2,
                                  Workout = "Push-Ups",
                                  Activity = "Upper Body",
                                  Sets = 4,
                                  Reps = 10,
                                  Weight = 150,

								   GenreId = "B"
			  },

               new ExerciseLog() { ExerciseId = 3,
                                   Workout = "Dips",
                                   Activity = "Upper Body",
                                   Sets = 3,
                                   Reps = 10,
                                   Weight = 150,

									GenreId = "C"
			   }
              );
        }
    }
}
