using System;
using System.Collections.Generic;
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
    }
}
