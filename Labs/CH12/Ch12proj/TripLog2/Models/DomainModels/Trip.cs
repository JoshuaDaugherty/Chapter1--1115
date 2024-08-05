using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TripLog2.Models.DomainModels
{
    public class Trip
    {
        public Trip() => Activities = new HashSet<Activity>();

        public int TripId { get; set; }

        public int DestiantionId { get; set; } //fk

        [ValidateNever]
        public Destination Destination { get; set; } = null!; //nav

        [Required(ErrorMessage = "Please enter an Accomodation")]
      
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Please enter a start date")]
        public DateTime? EndDate { get; set; }

        public int AccomodationId { get; set; }//fk

        [ValidateNever]
        public Accomodation Accomodation { get; set; } = null!;//nav



        //skip nav

        public ICollection<Activity> Activities { get; set; }
    }
}
