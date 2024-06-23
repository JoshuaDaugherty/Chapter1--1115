using Microsoft.AspNetCore.Mvc;

namespace MyWebsite.Areas.Help.Controllers
{
    public class HomeController : Controller
    {
        [Area("Help")]
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
