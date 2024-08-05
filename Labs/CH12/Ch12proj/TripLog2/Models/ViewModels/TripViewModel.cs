using TripLog2.Models.DomainModels;

namespace TripLog2.Models.ViewModels
{
    public class TripViewModel
    {
        public Trip Trip { get; set; } = new Trip();
        public int PageNumber { get; set; }
        public int[] Selectedactivities { get; set; } = Array.Empty<int>();

        public IEnumerable<Destination> Destinations { get; set; } = new List<Destination>();
        public IEnumerable<Accomodation> Accomodations { get; set; } = new List<Accomodation>();
        public IEnumerable<Activity> Activiies { get; set; } = new List<Activity>();

    }
}
