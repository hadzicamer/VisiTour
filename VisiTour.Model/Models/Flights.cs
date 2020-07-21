using System;
using System.Collections.Generic;
using System.Text;

namespace VisiTour.Model
{
    public class Flights
    {
        public int FlightId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? Price { get; set; }
        public virtual Cities CityFrom { get; set; }
        public virtual Cities CityTo { get; set; }
        public Companies Company { get; set; }
        public FlightClasses FlightClass { get; set; }
        public FlightSeats FlightSeat { get; set; }
    }
}
