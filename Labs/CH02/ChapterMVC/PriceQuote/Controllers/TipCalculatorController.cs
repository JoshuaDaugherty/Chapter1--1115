using Microsoft.AspNetCore.Mvc;

using PriceQuotePROJ.Models;

namespace PriceQuotePROJ.Controllers
{
	public class TipCalculatorController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			TipCalculatorModel tip = new TipCalculatorModel();
            //tip.Percent25Tip = 0;
			return View(tip);
		}

		[HttpPost]
		public IActionResult Index(TipCalculatorModel a1)
		{
			a1.CalcTip();
			return View(a1);
		}
	}
}
