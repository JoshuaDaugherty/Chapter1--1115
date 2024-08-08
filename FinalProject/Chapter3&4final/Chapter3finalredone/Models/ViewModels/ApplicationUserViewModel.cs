using Chapter3finalredone.Models.DomainModels;
using Microsoft.AspNetCore.Identity;

namespace Chapter3finalredone.Models.ViewModels
{
	public class ApplicationUserViewModel
	{
		public IEnumerable<ApplicationUser> ApplicationUsers { get; set; } = null!;
		public IEnumerable<IdentityRole> Roles { get; set; } = null!;
	}
}
