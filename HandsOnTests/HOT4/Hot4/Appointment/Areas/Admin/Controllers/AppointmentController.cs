using Appointment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentController : Controller
    {
        AppointmentContext _ctx;
        public AppointmentController(AppointmentContext ctx)
        {
            _ctx = ctx;
        }

        [Route("[area]/appointment/{StartTime?}")]
        public IActionResult List(string brand = "all")
        {
            List<Appointments> appointments;

            if (brand.Equals("all"))
            {
                appointments = _ctx.Appointments.ToList();
            }
            else
            {
                appointments = _ctx.Appointments.ToList();
            }

            return View(appointments);
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var appointments = _ctx.Appointments.Find(id);

            return View(appointments);
        }

        [HttpPost]
        public IActionResult Delete(Appointments appointments)
        {
            _ctx.Appointments.Remove(appointments);
            _ctx.SaveChanges();
            return RedirectToAction("List");
        }


        [HttpGet]
        public IActionResult Add(int? id)
        {
            if (id.HasValue)
            {
                var appointments = _ctx.Appointments.Find(id.Value);
                if (appointments != null)
                {
                    return View("AddEdit", appointments);
                }
            }
            return View("AddEdit", new Appointments());
        }


        [HttpPost]
        public IActionResult Add(Appointments appointments)
        {
            //Add operation if id is 0

            if (ModelState.IsValid)
            {
                if (appointments.AppointmentsId == 0)
                {
                    _ctx.Appointments.Add(appointments);
                }
                else
                {
                    _ctx.Appointments.Update(appointments);
                }

                _ctx.SaveChanges();
                return RedirectToAction("List");
            }
            return View("AddEdit", appointments);
        }
    }
}
