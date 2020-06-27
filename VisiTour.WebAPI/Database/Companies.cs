using System;
using System.Collections.Generic;

namespace VisiTour.WebAPI.Database
{
    public partial class Companies
    {
        public Companies()
        {
            Flights = new HashSet<Flights>();
            SpecialOffers = new HashSet<SpecialOffers>();
        }

        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Headquarter { get; set; }
        public string FoundingYear { get; set; }
        public int? FlightClassId { get; set; }
        public byte[] Photo { get; set; }

        public virtual FlightClasses FlightClass { get; set; }
        public virtual ICollection<Flights> Flights { get; set; }
        public virtual ICollection<SpecialOffers> SpecialOffers { get; set; }
    }
}
