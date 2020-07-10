using System;
using System.Collections.Generic;

namespace VisiTour.WebAPI.Database
{
    public partial class Flights
    {
        public Flights()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int FlightId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? Price { get; set; }
        public int? FlightClassId { get; set; }
        public int? CompanyId { get; set; }
        public int? FlightSeatId { get; set; }
        public int? CityFromId { get; set; }
        public int? CityToId { get; set; }

        public virtual Cities CityFrom { get; set; }
        public virtual Cities CityTo { get; set; }
        public virtual Companies Company { get; set; }
        public virtual FlightClasses FlightClass { get; set; }
        public virtual FlightSeats FlightSeat { get; set; }
        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}
