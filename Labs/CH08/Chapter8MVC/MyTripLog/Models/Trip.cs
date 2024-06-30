using System.ComponentModel.DataAnnotations;

namespace MyTripLog.Models
{
	public class Trip
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Please enter a destination")]
		public string Destination { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter an Accomodation")]
		public string Accomodation { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a start date")]
		public DateTime? StartDate { get; set; }

		[Required(ErrorMessage = "Please enter a start date")]
		public DateTime? EndDate { get; set; }

		public string AccomodationPhone { get; set; } = string.Empty;
		public string AccomodationEmail { get; set; } = string.Empty;

		public string? Activity1 {  get; set; } 
		public string? Activity2 {  get; set; } 
		public string? Activity3 {  get; set; } 

	}
}
