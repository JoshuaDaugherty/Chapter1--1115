namespace Chapter3finalredone.Models.ViewModel
{
	public class UserWorkoutViewModel //View Model for sending data to the details view
	{
		public List<User> User { get; set; }

		public List<WorkoutLog> Workouts { get; set; } = new List<WorkoutLog>();
	}
}
