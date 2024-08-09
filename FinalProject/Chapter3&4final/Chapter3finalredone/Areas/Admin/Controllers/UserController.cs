using Chapter3finalredone.Models.DomainModels;
using Chapter3finalredone.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Chapter3finalredone.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	[Authorize]
	[Area("Admin")]
	public class UserController : Controller
	{
		private UserManager<ApplicationUser> userManager;
		private RoleManager<IdentityRole> roleManager;

		public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
		}

		public async Task<IActionResult> Index()
		{
			List<ApplicationUser> users = new List<ApplicationUser>();

			foreach(ApplicationUser user in userManager.Users)
			{
				user.RoleNames = await userManager.GetRolesAsync(user);
				users.Add(user);
			}

			ApplicationUserViewModel model = new ApplicationUserViewModel
			{
				ApplicationUsers = users,
				Roles = roleManager.Roles
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> CreateAdminRole()
		{
			await roleManager.CreateAsync(new IdentityRole("Admin"));
			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> DeleteRole(string id)
		{
			IdentityRole role = await roleManager.FindByIdAsync(id);
			await roleManager.DeleteAsync(role);
			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> AddToAdmin(string id)
		{
			IdentityRole adminRole = await roleManager.FindByNameAsync("Admin");
			if(adminRole == null)
			{
				TempData["message"] = "Admin role doesn't exist,Click create Admin Role to create role";
			}
			else
			{
				ApplicationUser user = await userManager.FindByIdAsync(id);
				await userManager.AddToRoleAsync(user, adminRole.Name);
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> RemoveFromAdmin(string id)
		{
			ApplicationUser user = await userManager.FindByIdAsync(id);
			await userManager.RemoveFromRoleAsync(user, "Admin");
			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> Delete(string id)
		{
			ApplicationUser user = await userManager.FindByIdAsync(id);
			if(user != null)
			{
				IdentityResult result = await userManager.DeleteAsync(user);
				if(!result.Succeeded)
				{
					string errorMessage = "";
					foreach(IdentityError error in result.Errors)
					{
						errorMessage += error.Description + " | ";
					}
					TempData["message"] = errorMessage;
				}
				
			}
			return RedirectToAction("Index");
		}
	}
}
