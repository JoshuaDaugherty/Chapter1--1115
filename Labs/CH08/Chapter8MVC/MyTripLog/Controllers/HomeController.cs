using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyTripLog.Models;

namespace MyTripLog.Controllers
{
	public class HomeController : Controller
	{
		private TripLogContext _context;

		public HomeController(TripLogContext context)
		{
			_context = context;
		}


		public IActionResult Index()
		{
			var trips = _context.Trips.ToList();
			return View(trips);
		}

		
	}
}
