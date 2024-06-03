using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    public class GraphController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
