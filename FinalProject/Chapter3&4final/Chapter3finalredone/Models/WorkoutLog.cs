using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Chapter3finalredone.Models
{
	public class WorkoutLog
	{
		public int WorkoutLogId { get; set; }

		public  DateOnly Date { get; set; }

		public int UserId { get; set; } //FK
		[ValidateNever]
		public User? User { get; set; } // navigation property

		public int CaloriesBurned { get; set; }	

		public string Notes { get; set; } = string.Empty;
	}
}
