using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ContactPROJ.Models
{
    public class Contact
    {
        //Primary Key for table
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Please enter a first name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a last name")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a Phone number")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a Email")]
        public string Email { get; set; } = null!;

        //fk for contact
        [Required(ErrorMessage ="Please select a Category")]
        public int CategoryId { get; set; }

        //Navigate
        [ValidateNever]
        public Category Category { get; set; } = null!;

        public DateTime DateAdded { get; set; }

        //Read OnlyProperty the returns the full name of the contact
        public string Slug => FirstName?.Replace(' ', '-').ToLower() + '-' + LastName?.Replace(" ", "-").ToLower();


    }
}
