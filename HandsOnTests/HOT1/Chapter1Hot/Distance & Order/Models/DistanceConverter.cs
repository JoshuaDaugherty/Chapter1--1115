using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Distance___Order.Models
{
    public class DistanceConverter
    {
        public decimal DistanceInInches { get; set; }
        public decimal DistanceInCentimeters { get; set; }

        
        public void CalcDistance()
        {
            const decimal CM_PER_IN = 2.54m;

            DistanceInCentimeters = CM_PER_IN * DistanceInInches;
        }
    }
}
