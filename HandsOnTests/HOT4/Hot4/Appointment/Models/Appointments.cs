using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Appointment.Models
{
    public class Appointments
    {
        public int AppointmentsId { get; set; }

        [Required(ErrorMessage = "Please enter a Start Date.")]
        [Display(Name = "Start time.")]
        public DateTime StartTime { get; set; }

        //FK key

        public int CustomerId { get; set; }

        [ValidateNever]
        public Customer Customer { get; set; } = null!;
    }
}
