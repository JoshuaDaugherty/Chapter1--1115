using System.ComponentModel.DataAnnotations;
namespace Chapter3finalredone.Models
{
    public class User
    {
        public int UserId { get; set; }
        
        [Required(ErrorMessage ="Please enter a user name")]
        public string UserName { get; set; } = string.Empty;
        
        
        [Required(ErrorMessage = "Please enter an Email")]
        public string Email { get; set; } = string.Empty;
        
        
        [Required(ErrorMessage = "Please enter a Reason")]
        public string Reason { get; set; } = string.Empty;

        public string Slug => UserName?.Replace(' ', '-').ToLower() + '-' +Email?.ToString();
    }
}
