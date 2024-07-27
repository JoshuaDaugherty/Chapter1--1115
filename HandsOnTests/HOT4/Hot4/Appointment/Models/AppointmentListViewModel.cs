namespace Appointment.Models
{
	public class AppointmentListViewModel
	{
		public List<Appointments> appointments { get; set; } = null!;
		public List<Customer> customer { get; set; } = null!;

		public int CustomerId { get; set; }
	}
}
