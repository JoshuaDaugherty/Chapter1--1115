using System.Security.Cryptography;
using Distance___Order.Models;
using Microsoft.AspNetCore.Mvc;

namespace Distance___Order.Controllers
{
    public class DistanceConverterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            DistanceConverter distance = new DistanceConverter();
            distance.DistanceInCentimeters = 0;
            return View(distance);
        }
        [HttpPost]
        public IActionResult Index( DistanceConverter a1)
        {
            a1.CalcDistance();
            return View(a1);
        }
    }
}
