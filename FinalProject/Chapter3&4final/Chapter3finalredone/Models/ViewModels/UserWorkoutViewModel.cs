using Chapter3finalredone.Models.DomainModels;

namespace Chapter3finalredone.Models.ViewModels
{
    public class UserWorkoutViewModel //View Model for sending data to the details view
	{
		public ApplicationUser User { get; set; }

		public List<WorkoutLog> Workouts { get; set; } = new List<WorkoutLog>();
	}
}
