using System.ComponentModel.DataAnnotations;
using Appointment.Models.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Appointment.Models
{
    public class Appointments
    {
        public int AppointmentsId { get; set; }

        [Required(ErrorMessage = "Please enter a Start Date.")]
        [FutureDate(ErrorMessage = "Appointment can't be set in the past.")]
        [Display(Name = "Start time.")]
        public DateTime? StartTime { get; set; }

        //FK key

        [GreaterThan(0,ErrorMessage = "Please select a customer.")]
        [Remote("CheckAppointments", "Validation", AdditionalFields ="StartTime")]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [ValidateNever]
        public Customer Customer { get; set; } = null!;

       
    }
}
