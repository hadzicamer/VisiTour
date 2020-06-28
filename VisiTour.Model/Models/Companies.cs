using System;
using System.Collections.Generic;
using System.Text;

namespace VisiTour.Model
{
    public class Companies
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Headquarter { get; set; }
        public string FoundingYear { get; set; }
        public string Country { get; set; }
        public byte[] photo { get; set; }
    }
}
