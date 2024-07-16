using System.Reflection;
using Azure.Identity;
//using Chapter3finalredone.Data.Services;
using Chapter3finalredone.Models;
using Chapter3finalredone.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Chapter3finalredone.Controllers
{
	public class UsersController : Controller
	{
		


		private readonly UserContext _context;

		public UsersController(UserContext ctx)
		{
			_context = ctx;
			
		}

		[HttpGet]

		public IActionResult Delete(int id)
		{
			var user = _context.Users.Find(id);
				return View(user);
		}

		[HttpPost]
		public IActionResult Delete(User user)
		{
			_context.Users.Remove(user);
			_context.SaveChanges();
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
            var user = _context.Users.Find(id);
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
					_context.Users.Add(user);
				}
				else
				{
					_context.Users.Update(user);
				}
				_context.SaveChanges();
                TempData["AlertMessage"] = "User Added/Updated Successfully";
                return RedirectToAction("Index", "Users");
				
			}
			
				return View(user);
			
		}

		public async Task<IActionResult> Index(int? pageNumber, string searchString)
		{
			//var applicationDbContext = _UserService.GetAll();
			int pageSize = 3;
			var users = _context.Users.OrderBy(m => m.UserName).AsNoTracking();

            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.UserName.Contains(searchString));
            }

            return View(await PaginatedList<User>.CreateAsync(users, pageNumber ?? 1, pageSize));
        }



		public IActionResult ViewUserLogs()
		{
			var users = _context.Users.ToList();	
			UserWorkoutLogsViewModel userWorkoutLogsViewModel = new UserWorkoutLogsViewModel();

			foreach (var user in users)
			{
				userWorkoutLogsViewModel.users.Add(new Models.User
				{
					UserId = user.UserId,
					UserName = user.UserName,
					Email = user.Email,
					Reason = user.Reason,
				});
			}


			return View(userWorkoutLogsViewModel);
		}

		public IActionResult Details(int id)
		{
			var user = _context.Users.Find(id);
			var workouts = _context.Workouts.Where(w => w.UserId == id).ToList();
			UserWorkoutViewModel userWorkoutViewModel = new UserWorkoutViewModel
			{
				User = new User
				{
					UserId = user.UserId,
					UserName = user.UserName,
					Email = user.Email,
					Reason = user.Reason,
				}

			};
			userWorkoutViewModel.Workouts.AddRange(workouts);
			return View(userWorkoutViewModel);
		}
	}


}
