using System;
using System.Collections.Generic;
using System.Text;

namespace VisiTour.Model.Requests
{
    public class FlightsUpsertRequest
    {
        public string FlightFrom { get; set; }
        public string FlightTo { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal? Price { get; set; }
    }
}
