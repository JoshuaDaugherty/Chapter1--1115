using System.ComponentModel.DataAnnotations;

namespace Appointment.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter a User Name.")]
        [StringLength(100)]
        [Display(Name = "User Name")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a phone number.")]
        [StringLength(100)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
