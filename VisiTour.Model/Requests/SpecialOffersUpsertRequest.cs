using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace VisiTour.Model.Requests
{
    public class SpecialOffersUpsertRequest
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? CityId { get; set; }
        public int? FlightClassId { get; set; }
        public int? CompanyId { get; set; }
        public int? CityFromId { get; set; }
        public int? CityToId { get; set; }
        public decimal Price { get; set; } 

        public byte[] Photo { get; set; }
    }
}
