using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VisiTour.Model.Requests
{
    public class FlightsSearchRequest
    {
        public string selectedFlightFrom { get; set; }
        public string selectedFlightTo { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string selectedClass { get; set; }

    }
}
