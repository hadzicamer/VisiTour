using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace VisiTour.Model
{
    public class SpecialOffers
    {

        public int OfferId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? FlightClassId { get; set; }
        public int? CompanyId { get; set; }
        public int? CityFromId { get; set; }
        public int? CityToId { get; set; }
        public int? Price{ get; set; }


        public virtual Cities CityFrom { get; set; }
        public virtual Cities CityTo { get; set; }
        public virtual Companies Company { get; set; }
        public virtual FlightClasses FlightClass { get; set; }
    }
}
