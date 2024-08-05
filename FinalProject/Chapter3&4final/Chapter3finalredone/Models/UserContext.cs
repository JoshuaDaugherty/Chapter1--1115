using Microsoft.EntityFrameworkCore;
namespace Chapter3finalredone.Models
{
    public class UserContext : DbContext
    {
        //Collection of Users
        public DbSet<User> Users { get; set; } = null!;

        public DbSet<WorkoutLog> Workouts { get; set; }
        //public DbSet<Exercise> exercise { get; set; }
        //public DbSet<WorkoutLogExercise> WorkoutLogExercise { get; set; }

		public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Many-to-Many: Product <-> Ingredient
            //modelBuilder.Entity<WorkoutLogExercise>()
            //	.HasKey(we => new {
            //		we.WorkoutLogId,
            //		we.ExerciseId
            //	});

            modelBuilder.Entity<User>().HasData(
                new User() { UserId = 1, UserName = "Joshua555", Email = "killerclutch@gmail.com", Reason = "Lose weight." },
                new User() { UserId = 2, UserName = "Random616", Email = "Random616@gmail.com", Reason = "Gain weight." },
                new User() { UserId = 3, UserName = "CoolBeans83", Email = "CoolBeans83@gmail.com", Reason = "I want to jump higher." },
                new User() { UserId = 4, UserName = "Fitnessguy454", Email = "Fitnessguy454@gmail.com", Reason = "I want to fill out shirts." }
                );

            modelBuilder.Entity<WorkoutLog>().HasData(
                new WorkoutLog() { WorkoutLogId = 1, UserId = 1, Date = new DateOnly(2021, 10, 1), CaloriesBurned = 600, Notes = "I struggled with leg day." },
                new WorkoutLog() { WorkoutLogId = 2, UserId = 1, Date = new DateOnly(2021, 10, 2), CaloriesBurned = 400, Notes = "I did good on squats." },
                new WorkoutLog() { WorkoutLogId = 3, UserId = 2, Date = new DateOnly(2021, 10, 1), CaloriesBurned = 350, Notes = "My form on front rows needs improvement." },
                new WorkoutLog() { WorkoutLogId = 4, UserId = 3, Date = new DateOnly(2021, 10, 2), CaloriesBurned = 650, Notes = "I felt really motivated today." },
                new WorkoutLog() { WorkoutLogId = 5, UserId = 4, Date = new DateOnly(2021, 10, 6), CaloriesBurned = 500, Notes = "Today I participated in a yoga class." }

                );

			//modelBuilder.Entity<WorkoutLogExercise>().HasData(
	  //          new WorkoutLogExercise { WorkoutLogId = 1, ExerciseId = 1 },
	  //          new WorkoutLogExercise { WorkoutLogId = 2, ExerciseId = 4 },
	  //          new WorkoutLogExercise { WorkoutLogId = 3, ExerciseId = 5 },
	  //          new WorkoutLogExercise { WorkoutLogId = 4, ExerciseId = 6 },
	  //          new WorkoutLogExercise { WorkoutLogId = 5, ExerciseId = 2 }

				//);
		}
		
	}
}
