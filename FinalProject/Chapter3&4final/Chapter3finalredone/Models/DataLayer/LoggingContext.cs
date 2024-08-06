using Chapter3finalredone.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Chapter3finalredone.Models.DataLayer
{
	public class LoggingContext : DbContext
	{
		public LoggingContext(DbContextOptions<LoggingContext> options) 
			:base(options)
		{ }

		

		public DbSet<User> Users { get; set; } = null!;

		public DbSet<WorkoutLog> Workouts { get; set; }

		public DbSet<Exercise> Exercises { get; set; }

		public DbSet<WorkoutLogExercize> workoutLogExercizes { get; set; }

		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			//Define composite key and relationships for WorkoutLogExercise
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<WorkoutLogExercize>()
				.HasKey(we => new { we.WorkoutLogId, we.ExerciseId });

			modelBuilder.Entity<WorkoutLogExercize>()
				.HasOne(we => we.WorkoutLog)
				.WithMany(w => w.WorkoutLogExercizes)
				.HasForeignKey(we => we.WorkoutLogId);

			modelBuilder.Entity<WorkoutLogExercize>()
				.HasOne(we => we.exercise)
				.WithMany(e => e.WorkoutLogExercizes)
				.HasForeignKey(we => we.ExerciseId);



			//Seed Data
			//modelBuilder.ApplyConfiguration(new DateConfig());
			//modelBuilder.ApplyConfiguration(new NoteConfig());
			//modelBuilder.ApplyConfiguration(new ExcersizeLogConfig());

			

			modelBuilder.Entity<User>().HasData(
			   new User() { UserId = 1, UserName = "Joshua555", Email = "killerclutch@gmail.com", Reason = "Lose weight." },
			   new User() { UserId = 2, UserName = "Random616", Email = "Random616@gmail.com", Reason = "Gain weight." },
			   new User() { UserId = 3, UserName = "CoolBeans83", Email = "CoolBeans83@gmail.com", Reason = "I want to jump higher." },
			   new User() { UserId = 4, UserName = "Fitnessguy454", Email = "Fitnessguy454@gmail.com", Reason = "I want to fill out shirts." }
			   );

			modelBuilder.Entity<WorkoutLog>().HasData(
				new WorkoutLog() { WorkoutLogId = 1, UserId = 1, Date = new DateOnly(2021, 10, 1),  Notes = "I struggled with leg day." },
				new WorkoutLog() { WorkoutLogId = 2, UserId = 2, Date = new DateOnly(2021, 10, 2), Notes = "I did good on squats." },
				new WorkoutLog() { WorkoutLogId = 3, UserId = 2, Date = new DateOnly(2021, 10, 1),  Notes = "My form on front rows needs improvement." },
				new WorkoutLog() { WorkoutLogId = 4, UserId = 3, Date = new DateOnly(2021, 10, 2),  Notes = "I felt really motivated today." }

				);

			modelBuilder.Entity<Exercise>().HasData(
				new Exercise() { ExerciseId = 1, ExerciseName = "Squats", Description = "A squat is a strength exercise that involves lowering the hips from a standing position and then standing back up." },
				new Exercise() { ExerciseId = 2, ExerciseName = "Bench Press", Description = "The bench press is a compound exercise that targets the muscles of the upper body." },
				new Exercise() { ExerciseId = 3, ExerciseName = "Row", Description = "The bent-over row is an exercise you can do with dumbbells to work the muscles in the back of the shoulder" },
				new Exercise() { ExerciseId = 4, ExerciseName = "Barbell Curl", Description = "A barbell curl is a variation of the biceps curl that uses a weighted barbell. " }
				);


			modelBuilder.Entity<WorkoutLogExercize>().HasData(
				new WorkoutLogExercize { WorkoutLogId = 1, ExerciseId = 3},
				new WorkoutLogExercize { WorkoutLogId = 1, ExerciseId = 2},
				new WorkoutLogExercize { WorkoutLogId = 2, ExerciseId = 1},
				new WorkoutLogExercize { WorkoutLogId = 2, ExerciseId = 4},
				new WorkoutLogExercize { WorkoutLogId = 3, ExerciseId = 2},
				new WorkoutLogExercize { WorkoutLogId = 3, ExerciseId = 4},
				new WorkoutLogExercize { WorkoutLogId = 4, ExerciseId = 3},
				new WorkoutLogExercize { WorkoutLogId = 4, ExerciseId = 1}
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







//    public class UserContext : DbContext
//    {
//        //Collection of Users



//		public UserContext(DbContextOptions<UserContext> options) : base(options) { }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            // Many-to-Many: Product <-> Ingredient
//            //modelBuilder.Entity<WorkoutLogExercise>()
//            //	.HasKey(we => new {
//            //		we.WorkoutLogId,
//            //		we.ExerciseId
//            //	});

//            modelBuilder.Entity<User>().HasData(
//                new User() { UserId = 1, UserName = "Joshua555", Email = "killerclutch@gmail.com", Reason = "Lose weight." },
//                new User() { UserId = 2, UserName = "Random616", Email = "Random616@gmail.com", Reason = "Gain weight." },
//                new User() { UserId = 3, UserName = "CoolBeans83", Email = "CoolBeans83@gmail.com", Reason = "I want to jump higher." },
//                new User() { UserId = 4, UserName = "Fitnessguy454", Email = "Fitnessguy454@gmail.com", Reason = "I want to fill out shirts." }
//                );

//            modelBuilder.Entity<WorkoutLog>().HasData(
//                new WorkoutLog() { WorkoutLogId = 1, UserId = 1, Date = new DateOnly(2021, 10, 1), CaloriesBurned = 600, Notes = "I struggled with leg day." },
//                new WorkoutLog() { WorkoutLogId = 2, UserId = 1, Date = new DateOnly(2021, 10, 2), CaloriesBurned = 400, Notes = "I did good on squats." },
//                new WorkoutLog() { WorkoutLogId = 3, UserId = 2, Date = new DateOnly(2021, 10, 1), CaloriesBurned = 350, Notes = "My form on front rows needs improvement." },
//                new WorkoutLog() { WorkoutLogId = 4, UserId = 3, Date = new DateOnly(2021, 10, 2), CaloriesBurned = 650, Notes = "I felt really motivated today." },
//                new WorkoutLog() { WorkoutLogId = 5, UserId = 4, Date = new DateOnly(2021, 10, 6), CaloriesBurned = 500, Notes = "Today I participated in a yoga class." }

//                );

//			//modelBuilder.Entity<WorkoutLogExercise>().HasData(
//	  //          new WorkoutLogExercise { WorkoutLogId = 1, ExerciseId = 1 },
//	  //          new WorkoutLogExercise { WorkoutLogId = 2, ExerciseId = 4 },
//	  //          new WorkoutLogExercise { WorkoutLogId = 3, ExerciseId = 5 },
//	  //          new WorkoutLogExercise { WorkoutLogId = 4, ExerciseId = 6 },
//	  //          new WorkoutLogExercise { WorkoutLogId = 5, ExerciseId = 2 }

//				//);
//		}

//	}
//}