using System;
using System.Collections.Generic;
using System.Text;

namespace VisiTour.Model.Requests
{
    public class FlightsSearchRequest
    {
        public string FlightFrom { get; set; }
        public string FlightTo { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string selectedClass { get; set; }

    }
}
