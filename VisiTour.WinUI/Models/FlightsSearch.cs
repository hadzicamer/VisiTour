using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisiTour.WinUI.Models
{
    public class FlightsSearch
    {
        public string selectedFlightFrom { get; set; }
        public string selectedFlightTo { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string selectedClass { get; set; }
    }
}
