using Appointment.Models;
using Appointment.Models.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Controllers
{
	public class ValidationController : Controller
	{

		private AppointmentContext context { get; set; }

		public ValidationController(AppointmentContext context)
		{
			this.context = context;
		}


		public IActionResult Index()
		{
			return View();
		}

		public JsonResult CheckAppointments( DateTime starttime, int customerId)
		{
			var appointments = new Appointments { StartTime = starttime, CustomerId = customerId };

			string msg = Validate.CheckAppointment(context, appointments);

			if (string.IsNullOrEmpty(msg))
			{
				return Json(true);
			}
			else
			{
				return Json(msg);
			}
		}
	}
}
