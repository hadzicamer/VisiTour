using System;
using System.Collections.Generic;
using System.Text;

namespace VisiTour.Model.Requests
{
   public class BookingInsertRequest
    {
        public int FlightId { get; set; }
        public int CustomerId { get; set; }

    }
}
