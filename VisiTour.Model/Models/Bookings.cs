using System;
using System.Collections.Generic;
using System.Text;

namespace VisiTour.Model
{
    public class Bookings
    {
        public int BookingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? CountryId { get; set; }
        public int? TitleId { get; set; }
        public int? FlightId { get; set; }

        public virtual Flights Flight { get; set; }

        public virtual Countries Country { get; set; }
        public virtual Title Title { get; set; }
    }
}
