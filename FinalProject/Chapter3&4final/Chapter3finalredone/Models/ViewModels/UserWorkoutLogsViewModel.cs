using System.Collections.Generic;
using Chapter3finalredone.Models.DomainModels;

namespace Chapter3finalredone.Models.ViewModels
{
    public class UserWorkoutLogsViewModel
    {
        public List<ApplicationUser> users { get; set; } = new List<ApplicationUser>();
    }
}
