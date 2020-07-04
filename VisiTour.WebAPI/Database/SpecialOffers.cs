using System;
using System.Collections.Generic;

namespace VisiTour.WebAPI.Database
{
    public partial class SpecialOffers
    {

        public int OfferId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? FlightClassId { get; set; }
        public int? CompanyId { get; set; }
        public int? CityFromId { get; set; }
        public int? CityToId { get; set; }

        public virtual Cities CityFrom { get; set; }
        public virtual Cities CityTo { get; set; }
        public virtual Companies Company { get; set; }
        public virtual FlightClasses FlightClass { get; set; }
    }
}
