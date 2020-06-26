using System;
using System.Collections.Generic;

namespace VisiTour.WebAPI.Database
{
    public partial class Flights
    {
        public int FlightId { get; set; }
        public string FlightFrom { get; set; }
        public string FlightTo { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal? Price { get; set; }
        public int? CustomerId { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? FlightClassId { get; set; }
        public int? CompanyId { get; set; }
        public int? FlightSeatId { get; set; }

        public virtual Cities City { get; set; }
        public virtual Companies Company { get; set; }
        public virtual Countries Country { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual FlightClasses FlightClass { get; set; }
        public virtual FlightSeats FlightSeat { get; set; }
    }
}
