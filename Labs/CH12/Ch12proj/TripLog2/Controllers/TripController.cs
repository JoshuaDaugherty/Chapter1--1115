using Microsoft.AspNetCore.Mvc;
using TripLog2.Models.DataAccess;
using TripLog2.Models.DomainModels;
using TripLog2.Models.ViewModels;

namespace TripLog2.Controllers
{
	public class TripController : Controller
	{

		private Repository<Trip> tripData { get; set; }
		private Repository<Destination> destinationData { get; set; }
		private Repository<Accomodation> accomodationData { get; set; }
		private Repository<Activity> activityData { get; set; }

		public TripController(TripLog2Context ctx)
		{
			tripData = new Repository<Trip>(ctx);
			destinationData = new Repository<Destination>(ctx);
			accomodationData = new Repository<Accomodation>(ctx);
			activityData = new Repository<Activity>(ctx);

		}



		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Add(string id = "")
		{
			var vm = new TripViewModel();
			if (id.ToLower() == "page1")
			{
				vm.PageNumber = 1;

				vm.Destinations = destinationData.List(new QueryOptions<Destination>
				{
					OrderBy = d => d.Name
				});

				vm.Accomodations = accomodationData.List(new QueryOptions<Accomodation>()
				{
					OrderBy = a => a.Name
				});
				return View("Add1", vm);
			}
			else if (id.ToLower() == "page2")
			{
				vm.PageNumber = 2;

				int destID = (int)TempData.Peek("DestinationId")!;

				vm.Trip.Destination = destinationData.Get(destID)!;

				vm.Activiies = activityData.List(new QueryOptions<Activity>
				{
					OrderBy = a => a.Name
				});
				return View("Add2", vm);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpPost]
		public IActionResult Add(TripViewModel vm)
		{
			if (vm.PageNumber == 1)
			{
				if (ModelState.IsValid)
				{
					TempData["DestinationId"] = vm.Trip.DestiantionId;
					TempData["AccomodationId"] = vm.Trip.AccomodationId;
					TempData["StartDate"] = vm.Trip.StartDate;
					TempData["EndDate"] = vm.Trip.EndDate;
					return RedirectToAction("Add", new { id = "Page2" });
				}
				else
				{
					//Invalid

					vm.Destinations = destinationData.List(new QueryOptions<Destination>
					{
						OrderBy = d => d.Name
					});

					vm.Accomodations = accomodationData.List(new QueryOptions<Accomodation>()
					{
						OrderBy = a => a.Name
					});
					return View("Add1", vm);
				}

			}
			else if (vm.PageNumber == 2)
			{
				vm.Trip.DestiantionId = (int)TempData["DestiantionId"]!;
				vm.Trip.AccomodationId = (int)TempData["AccomodationId"]!;
				vm.Trip.StartDate = (DateTime)TempData["StartDate"]!;
				vm.Trip.EndDate = (DateTime)TempData["EndDate"]!;

				foreach (int id in vm.Selectedactivities)
				{
					var activity = activityData.Get(id);
					if (activity != null)
					{
						vm.Trip.Activities.Add(activity);
					}
				}

				tripData.Insert(vm.Trip);
				tripData.Save();

				var dest = destinationData.Get(vm.Trip.DestiantionId);
				TempData["message"] = $"Trip to {dest?.Name} Added.";
				return RedirectToAction("Index", "Home");
			}
			return RedirectToAction("Index", "Home");

		}

		[HttpPost]
		public RedirectToActionResult Delete(int id)
		{
			Trip trip = tripData.Get(new QueryOptions<Trip>
			{
				Incudes = "Destination",
				Where = t => t.TripId == id
			}

				)!;

			if( trip != null )
			{
				tripData.Delete(trip);
				tripData.Save();
				TempData["message"] = $"Trip to {trip.Destination.Name} deleted";

			}

			return RedirectToAction("Index", "Home");
		}

		[HttpPost]
		public RedirectToActionResult Cancel()
		{
			TempData.Clear();
			return RedirectToAction("Index", "Home");
		}
	}
}
