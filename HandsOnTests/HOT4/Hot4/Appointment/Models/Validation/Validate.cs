namespace Appointment.Models.Validation
{
	public static class Validate
	{
		public static string CheckAppointment(AppointmentContext context,Appointments a1)
		{
			Appointments? dbAppointment = context.Appointments.FirstOrDefault(s =>
		   s.StartTime == a1.StartTime &&
		 
		   s.CustomerId == a1.CustomerId);

			if (dbAppointment == null)
			{
				return "";
			}
			else
			{
				var emp = context.Customers.Find(a1.CustomerId);
				return $"Appointment for {emp?.UserName} at {a1.StartTime} is already in the database.";
			}
		}
	}
	}

