using System;
using System.Collections.Generic;

namespace VisiTour.WebAPI.Database
{
    public partial class FlightStatus
    {
        public FlightStatus()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int StatusId { get; set; }
        public string StatusDescription { get; set; }

        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}
