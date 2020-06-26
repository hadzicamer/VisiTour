using System;
using System.Collections.Generic;

namespace VisiTour.WebAPI.Database
{
    public partial class Bookings
    {
        public int BookingId { get; set; }
        public string Details { get; set; }
        public int? CustomerId { get; set; }
        public int? StatusId { get; set; }
        public int? PaymentId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Payments Payment { get; set; }
        public virtual FlightStatus Status { get; set; }
    }
}
