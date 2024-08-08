using System.ComponentModel.DataAnnotations;

namespace Chapter3finalredone.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter a username")]
        [StringLength(255)]
        public string UserName { get; set; } = null!;


        [Required(ErrorMessage = "Please enter a passwork")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string PassWord { get; set; } = null!;

        [Required(ErrorMessage = "Please confirm your passwork")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassWord { get; set; } = null!;


    }
}
