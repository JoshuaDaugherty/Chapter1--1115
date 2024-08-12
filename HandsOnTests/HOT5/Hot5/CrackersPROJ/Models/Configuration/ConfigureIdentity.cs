using CrackersPROJ.Models.DomainModels;
using Microsoft.AspNetCore.Identity;

namespace CrackersPROJ.Models.Configuration
{
	public class ConfigureIdentity
	{
		public static async Task CreateAdminUserAsync(IServiceProvider provider)
		{
			var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
			var userManager = provider.GetRequiredService<UserManager<User>>();

			string username = "admin";
			string password = "Admin123";
			string rolename = "Admin";

			if (await roleManager.FindByNameAsync(rolename) == null)
			{
				await roleManager.CreateAsync(new IdentityRole(rolename));
			}

			if (await userManager.FindByNameAsync(username) == null)
			{
				User user = new User { UserName = username };
				var result = await userManager.CreateAsync(user, password);
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(user, rolename);
				}
			}
		}
	}
}
