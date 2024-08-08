using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Chapter3finalredone.Models.DomainModels
{
	public class ApplicationUser : IdentityUser
	{
        [NotMapped]
        public IList<string> RoleNames { get; set; }

        public ICollection<User>? Users { get; set; }
	}
}
