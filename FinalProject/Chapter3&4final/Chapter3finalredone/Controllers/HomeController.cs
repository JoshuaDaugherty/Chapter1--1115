using System.Diagnostics;
using Chapter3finalredone.Models;
using Chapter3finalredone.Models.DataLayer;
using Chapter3finalredone.Models.DomainModels;
using Chapter3finalredone.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Chapter3finalredone.Controllers
{
	public class HomeController : Controller
	{

		


		public IActionResult Index(int id)
		{
			

			

			return View();
		}

		
	}
}
