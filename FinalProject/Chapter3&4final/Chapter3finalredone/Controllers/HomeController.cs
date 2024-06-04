using System.Diagnostics;
using Chapter3finalredone.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chapter3finalredone.Controllers
{
	public class HomeController : Controller
	{
		

		public IActionResult Index()
		{
			return View();
		}

		
	}
}
