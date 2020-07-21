using System;
using System.Collections.Generic;

namespace VisiTour.WebAPI.Database
{
    public partial class Bookings
    {
        public int BookingId { get; set; }
        public int? FlightId { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Flights Flight { get; set; }
    }
}
