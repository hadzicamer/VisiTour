using System;
using System.Collections.Generic;
using System.Text;

namespace VisiTour.Model
{
    public class Flights
    {
        public int FlightId { get; set; }
        public string FlightFrom { get; set; }
        public string FlightTo { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal? Price { get; set; }

        public Cities City { get; set; }
        public Companies Company { get; set; }
        public Countries Country { get; set; }
        public Customers Customer { get; set; }
        public FlightClasses FlightClass { get; set; }
        public FlightSeats FlightSeat { get; set; }
    }
}
