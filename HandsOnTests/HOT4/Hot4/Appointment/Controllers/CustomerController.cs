using System.ComponentModel.DataAnnotations;
using Appointment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Controllers
{
	public class CustomerController : Controller
	{
		private AppointmentContext context { get; set; }

		public CustomerController(AppointmentContext context)
		{
			this.context = context;
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Customers = context.Customers.OrderBy(e => e.UserName).ToList();
			return View();
		}

		[HttpPost]
		public IActionResult Add(Customer customer)
		{
			//server side checks for remote validation
			//string msg = Validate.CheckEmployee(context, customer);
			//if (!string.IsNullOrEmpty(msg))
			//{
			//	ModelState.AddModelError(nameof(Customer.UserName), msg);
			//}

			//msg = Validate.CheckManagerEmployeeMatch(context, customer);
			//if (string.IsNullOrEmpty(msg))
			//{
			//	ModelState.AddModelError(nameof(Customer.CustomerId), msg);

			//}
			if (ModelState.IsValid)
			{
				context.Customers.Add(customer);
				context.SaveChanges();
				TempData["message"] = $"Customer {customer.UserName} was added";
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
