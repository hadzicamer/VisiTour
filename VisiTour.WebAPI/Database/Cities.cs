using System;
using System.Collections.Generic;

namespace VisiTour.WebAPI.Database
{
    public partial class Cities
    {
        public Cities()
        {
            FlightsCityFrom = new HashSet<Flights>();
            FlightsCityTo = new HashSet<Flights>();
            SpecialOffersCityFrom = new HashSet<SpecialOffers>();
            SpecialOffersCityTo = new HashSet<SpecialOffers>();
        }

        public int CityId { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }

        public virtual ICollection<Flights> FlightsCityFrom { get; set; }
        public virtual ICollection<Flights> FlightsCityTo { get; set; }
        public virtual ICollection<SpecialOffers> SpecialOffersCityFrom { get; set; }
        public virtual ICollection<SpecialOffers> SpecialOffersCityTo { get; set; }
    }
}
