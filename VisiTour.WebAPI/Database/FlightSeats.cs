using System;
using System.Collections.Generic;

namespace VisiTour.WebAPI.Database
{
    public partial class FlightSeats
    {
        public FlightSeats()
        {
            Flights = new HashSet<Flights>();
        }

        public int FlightSeatId { get; set; }
        public string SeatNumber { get; set; }

        public virtual ICollection<Flights> Flights { get; set; }
    }
}
