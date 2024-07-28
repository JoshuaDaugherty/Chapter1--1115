using System.ComponentModel.DataAnnotations;
using Appointment.Models;
using Appointment.Models.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Controllers
{
    public class AppointmentsController : Controller
    {

        private AppointmentContext context;

        public AppointmentsController(AppointmentContext context) { this.context = context; }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Customers = context.Customers.OrderBy(e => e.UserName).ToList();
            return View();
        }
		public IActionResult Add(Appointments appointments)
		{

			string msg = Validate.CheckAppointment(context, appointments);
			if (!string.IsNullOrEmpty(msg))
			{
				ModelState.AddModelError(nameof(Appointments.CustomerId), msg);
			}




			if (ModelState.IsValid)
			{
				context.Appointments.Add(appointments);
				context.SaveChanges();
				TempData["message"] = " Appointment added";
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ViewBag.Customers = context.Customers.OrderBy(e => e.UserName).ToList();
				return View();
			}
		}
	}
}
