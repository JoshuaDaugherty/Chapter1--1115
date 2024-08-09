using Chapter3finalredone.Models.DomainModels;
using Microsoft.AspNetCore.Identity;

namespace Chapter3finalredone.Models.Configuration
{
    public class ConfigureIdentity
    {
        public static async Task CreateAdminUserAsync(IServiceProvider provider)
        {
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = provider.GetRequiredService<UserManager<ApplicationUser>>();

            string username = "admin";
            string password = "Sesame!";
            string rolename = "Admin";

            if(await roleManager.FindByNameAsync(rolename) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(rolename));
            }

            if(await userManager.FindByNameAsync(username) == null)
            {
                ApplicationUser user = new ApplicationUser { UserName = username };
                var result = await userManager.CreateAsync(user,password);
                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, rolename);   
                }
            }
        }
    }
}
