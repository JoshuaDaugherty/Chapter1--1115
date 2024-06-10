using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalesOrder.Models;

namespace SalesOrder.Controllers
{
    public class HomeController : Controller
    {
       
        private SalesOrdersDB context {  get; set; }

        public HomeController(SalesOrdersDB ctx)
        {
            this.context = ctx;
        }
       

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sale()
        {
            return View();
        }


    }
}
