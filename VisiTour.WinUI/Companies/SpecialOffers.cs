//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VisiTour.WinUI.Companies
{
    using System;
    using System.Collections.Generic;
    
    public partial class SpecialOffers
    {
        public int OfferID { get; set; }
        public Nullable<System.DateTime> DateFrom { get; set; }
        public Nullable<System.DateTime> DateTo { get; set; }
        public Nullable<int> FlightClassID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<int> CityFromID { get; set; }
        public Nullable<int> CityToID { get; set; }
        public Nullable<decimal> Price { get; set; }
        public byte[] Photo { get; set; }
    
        public virtual Cities Cities { get; set; }
        public virtual Cities Cities1 { get; set; }
        public virtual Companies Companies { get; set; }
    }
}
