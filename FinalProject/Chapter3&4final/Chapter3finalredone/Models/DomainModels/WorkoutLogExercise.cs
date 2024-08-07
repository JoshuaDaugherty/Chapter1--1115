namespace Chapter3finalredone.Models.DomainModels
{
	public class WorkoutLogExercise
	{
		public int WorkoutLogId { get; set; } //fk

		public WorkoutLog WorkoutLog { get; set; } //nav prop

		public int ExerciseId { get; set; } //fk

		public Exercise Exercise { get; set; }  //nav prop
	}
}