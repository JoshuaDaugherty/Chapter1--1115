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
			return RedirectToAction("Index", "user");
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
			ViewBag.Action = "Edit User";
			var user = context.Users.Find(id);
			return View(user);
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
				return RedirectToAction("Index", "user");
				
			}
			else
			{
				ViewBag.Action = (user.UserId == 0) ? "Add" : "Edit";
				return View(user);
			}
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
