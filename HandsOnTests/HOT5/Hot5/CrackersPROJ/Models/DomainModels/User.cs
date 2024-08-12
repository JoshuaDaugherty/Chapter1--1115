using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace CrackersPROJ.Models.DomainModels
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        [NotMapped]
        public IList<string> RoleNames { get; set; }
    }
}

