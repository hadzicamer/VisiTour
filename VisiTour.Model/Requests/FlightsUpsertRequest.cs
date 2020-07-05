using System;
using System.Collections.Generic;
using System.Text;

namespace VisiTour.Model.Requests
{
    public class FlightsUpsertRequest
    {
    
        public int FlightId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal? Price { get; set; }
        public int? FlightClassId { get; set; }
        public int? CompanyId { get; set; }
        public int? FlightSeatId { get; set; }
        public int? CityFromId { get; set; }
        public int? CityToId { get; set; }

    }
}
