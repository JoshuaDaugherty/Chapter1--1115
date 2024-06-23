using Microsoft.AspNetCore.Mvc;

namespace MyWebsite.Areas.Help.Controllers
{
    public class TutorialController : Controller
    {
        [Area("Help")]
        public IActionResult Page1()
        {
            return View();
        }

		[Area("Help")]
		public IActionResult Page2()
		{
			return View();
		}

		[Area("Help")]
		public IActionResult Page3()
		{
			return View();
		}
	}
}
