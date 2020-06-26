﻿using System;
using System.Collections.Generic;

namespace VisiTour.WebAPI.Database
{
    public partial class SpecialOffers
    {
        public int OfferId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? CityId { get; set; }
        public int? FlightClassId { get; set; }
        public int? CompanyId { get; set; }

        public virtual Cities City { get; set; }
        public virtual Companies Company { get; set; }
        public virtual FlightClasses FlightClass { get; set; }
    }
}
