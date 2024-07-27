using System.Diagnostics;
using Appointment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Controllers
{
    public class HomeController : Controller
    {
       private AppointmentContext context { get; set; }

        public HomeController(AppointmentContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Index(int id )
        {
            IQueryable<Appointments> query = context.Appointments
                .Include(s => s.Customer)
                .OrderByDescending(s => s.StartTime);

            if(id > 0)
            {
                query = query.Where(s => s.CustomerId == id);
            }

            AppointmentListViewModel vm = new AppointmentListViewModel
            {
                appointments = query.ToList(),
                customer = context.Customers.OrderBy(e => e.UserName).ToList(),
                CustomerId = id
            };

            return View(vm);
        }

        [HttpPost]
        public RedirectToActionResult Index(Customer customer)
        {
            string id = (customer.CustomerId > 0) ? customer.CustomerId.ToString() : "";
            return RedirectToAction("Index", new { id });
        }
    }
}
