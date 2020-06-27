using System;
using System.Collections.Generic;

namespace VisiTour.WebAPI.Database
{
    public partial class Cities
    {
        public Cities()
        {
            Flights = new HashSet<Flights>();
            SpecialOffers = new HashSet<SpecialOffers>();
        }

        public int CityId { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }

        public virtual ICollection<Flights> Flights { get; set; }
        public virtual ICollection<SpecialOffers> SpecialOffers { get; set; }
    }
}
