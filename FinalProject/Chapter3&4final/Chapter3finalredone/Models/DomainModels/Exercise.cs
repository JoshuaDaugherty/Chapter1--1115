namespace Chapter3finalredone.Models.DomainModels
{
	public class Exercise
	{
		public int ExerciseId { get; set; }

		public string ExerciseName { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public ICollection<WorkoutLogExercise> WorkoutLogExercises { get; set; }
	}
}