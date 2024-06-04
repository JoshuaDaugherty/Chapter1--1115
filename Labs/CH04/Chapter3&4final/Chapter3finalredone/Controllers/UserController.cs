using Chapter3finalredone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace Chapter3finalredone.Controllers
{
    public class UserController : Controller
    {
        private UserContext context { get; set; }

        public UserController(UserContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var user = context.Users.OrderBy(m => m.UserName).ToList();
            return View(user);
        }
    }
}
