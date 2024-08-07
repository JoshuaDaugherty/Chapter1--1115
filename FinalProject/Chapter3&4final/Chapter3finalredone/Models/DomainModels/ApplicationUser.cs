using Microsoft.AspNetCore.Identity;

namespace Chapter3finalredone.Models.DomainModels
{
	public class ApplicationUser : IdentityUser
	{
		public ICollection<User>? Users { get; set; }
	}
}
