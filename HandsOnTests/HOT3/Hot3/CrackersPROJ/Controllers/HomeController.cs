using System.Diagnostics;
using CrackersPROJ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrackersPROJ.Controllers
{
    public class HomeController : Controller
    {
         CrackerContext _ctx;
        public HomeController(CrackerContext ctx) 
        {
            _ctx = ctx;
        }


        
        public IActionResult Index()
        {
            var crackers = _ctx.Crackers.OrderBy(c => c.Name).ToList();
            return View(crackers);
        }




    }
}
