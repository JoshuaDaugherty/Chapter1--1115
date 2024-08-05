using System.ComponentModel.DataAnnotations;

namespace Chapter3finalredone.Models.DomainModels
{
	public class Date
	{
		public Date() => excersizeLogs = new HashSet<ExcersizeLog>(); //constructor initializes collection


		public int DateId { get; set; }

		[Required(ErrorMessage = "Please enter a Date.")]
		public DateTime DateofWorkout { get; set; }

		public ICollection<ExcersizeLog> excersizeLogs { get; set; }
	}
}
