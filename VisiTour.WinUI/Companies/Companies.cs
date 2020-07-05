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
    
    public partial class Companies
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Companies()
        {
            this.Flights = new HashSet<Flights>();
            this.SpecialOffers = new HashSet<SpecialOffers>();
        }
    
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string Headquarter { get; set; }
        public string FoundingYear { get; set; }
        public Nullable<int> FlightClassID { get; set; }
        public byte[] photo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flights> Flights { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SpecialOffers> SpecialOffers { get; set; }
    }
}