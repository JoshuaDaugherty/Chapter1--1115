using Azure.Identity;
using Chapter3finalredone.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chapter3finalredone.Controllers
{
	public class UsersController : Controller
	{
			

		private UserContext context { get; set; }

		public UsersController(UserContext ctx)
		{
			context = ctx;
		}

		[HttpGet]

		public IActionResult Delete(int id)
		{
			var user = context.Users.Find(id);
				return View(user);
		}

		[HttpPost]
		public IActionResult Delete(User user)
		{
			context.Users.Remove(user);
			context.SaveChanges();
			TempData["AlertMessage"] = "User Deleted Successfully";
			return RedirectToAction("Index", "Users");
		}


		[HttpGet]
		public IActionResult Add()
		{
			
			ViewBag.Action = "Add";
			return View("Edit", new User());
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
            var user = context.Users.Find(id);
            ViewBag.Action = "Edit";
			
			return View("Edit", user);
		}

		[HttpPost]
		public IActionResult Edit(User user)
		{
			if (ModelState.IsValid)
			{
				if(user.UserId == 0)
				{
					context.Users.Add(user);
				}
				else
				{
					context.Users.Update(user);
				}
				context.SaveChanges();
                TempData["AlertMessage"] = "User Added/Updated Successfully";
                return RedirectToAction("Index", "Users");
				
			}
			
				return View(user);
			
		}

		public IActionResult Index()
		{
            var user = context.Users.OrderBy(m => m.UserName).ToList();
            return View(user);
        }
	}
}
