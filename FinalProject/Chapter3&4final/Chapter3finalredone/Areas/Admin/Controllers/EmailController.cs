using Chapter3finalredone.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chapter3finalredone.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class EmailController : Controller
    {
        private readonly UserContext _context;

        public EmailController(UserContext ctx)
        {
            _context = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("[area]")]
        public IActionResult List()
        {
            var user = _context.Users.OrderBy(m => m.UserName).ToList();
            return View(user);
        }

        [HttpGet]
        public IActionResult Add(int? id)
        {
            if (id.HasValue)
            {
                var user = _context.Users.Find(id.Value);
                if (user != null)
                {
                    return View("AddEdit", user);
                }
            }
            return View("AddEdit", new User());
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            

            if (ModelState.IsValid)
            {
                if(user.UserId == 0)
                {
                    _context.Users.Add(user);
                }
                else
                {
                    _context.Users.Update(user);
                }

               
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            return View("AddEdit", user);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                return View(user);

            }
            return RedirectToAction("List");
        }


        [HttpPost]
        public IActionResult DeleteEmail(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
