using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VisiTour.Model.Requests
{
    public class CompaniesUpsertRequest
    {
        [Required(AllowEmptyStrings =false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Headquarter { get; set; }
        public string FoundingYear { get; set; }
        public string Country { get; set; }
        public byte[] Photo { get; set; }

    }
}
