using System;
using System.Collections.Generic;

namespace VisiTour.WebAPI.Database
{
    public partial class Countries
    {
        public Countries()
        {
            Flights = new HashSet<Flights>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Flights> Flights { get; set; }
    }
}
