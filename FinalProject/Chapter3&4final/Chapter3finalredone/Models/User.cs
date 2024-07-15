using System.ComponentModel.DataAnnotations;
namespace Chapter3finalredone.Models
{
    public class User
    {
		internal bool IsSold;

		public int UserId { get; set; }
        
        [Required(ErrorMessage = "Please enter a user name")]
        public string? UserName { get; set; }
        
        
        [Required(ErrorMessage = "Please enter an Email")]
        public string? Email { get; set; } 
        
        
        [Required(ErrorMessage = "Please enter a Reason")]
        public string? Reason { get; set; } 

        public string Slug => UserName?.Replace(' ', '-').ToLower() + '-' +Email?.ToString();
    }
}
