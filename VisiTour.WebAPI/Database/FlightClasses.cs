using System;
using System.Collections.Generic;

namespace VisiTour.WebAPI.Database
{
    public partial class FlightClasses
    {
        public FlightClasses()
        {
            Companies = new HashSet<Companies>();
            Flights = new HashSet<Flights>();
            SpecialOffers = new HashSet<SpecialOffers>();
        }

        public int FlightClassId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Companies> Companies { get; set; }
        public virtual ICollection<Flights> Flights { get; set; }
        public virtual ICollection<SpecialOffers> SpecialOffers { get; set; }
    }
}
