using Microsoft.AspNetCore.Mvc;
using MyTripLog.Models;

namespace MyTripLog.Controllers
{
    public class TripController : Controller
    {

        private readonly TripLogContext _context;

        public TripController(TripLogContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Add(string id="")
        {
            var vm = new TripViewModel();

            switch (id)
            {
                    case "1":
                    vm.PageNumber = 1;
                    return View("Add1", vm);
                    case "2":
                    vm.PageNumber = 2;
                    return View("Add2", vm);
                    case "3":
                    vm.PageNumber = 3;
                    return View("Add3", vm);
                default: return View("Index", "Home");
            }

            
        }

        [HttpPost]
        public IActionResult Add(TripViewModel vm)
        {
            if (vm.PageNumber == 1)
            {
                if (ModelState.IsValid)
                {

                    TempData["Desitnation"] = vm.Trip.Destination;
                    TempData["Accomodation"] = vm.Trip.Accomodation;
                    TempData["StartDate"] = vm.Trip.StartDate;
                    TempData["EndDate"] = vm.Trip.EndDate;
                    return RedirectToAction("Add", new { id = "2" });
                }
                else
                {
                    return View("Add1", vm);
                }
            }else if (vm.PageNumber == 2)
            {
                TempData["Email"] = vm.Trip.AccomodationEmail;
                TempData["Phone"] = vm.Trip.AccomodationPhone;
                return RedirectToAction("Add", new { id = "3" });
            }
            else
            {
                Trip trip = new Trip()
                {
                    Destination = TempData["Destination"].ToString(),
                    Accomodation = TempData["Destination"].ToString(),
                    StartDate = (System.DateTime)TempData["StartDate"],
                    EndDate = (System.DateTime)TempData["EndDate"],
                    AccomodationEmail = TempData["Email"].ToString(),
                    AccomodationPhone = TempData["Phone"].ToString(),
                    Activity1 = vm.Trip.Activity1,
                    Activity2 = vm.Trip.Activity2,
                    Activity3 = vm.Trip.Activity3,

                };

                _context.Trips.Add(trip);
                _context.SaveChanges();
            }
            return View("Index", "Home");
        }
    }
}
