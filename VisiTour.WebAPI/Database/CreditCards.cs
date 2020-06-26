using System;
using System.Collections.Generic;

namespace VisiTour.WebAPI.Database
{
    public partial class CreditCards
    {
        public CreditCards()
        {
            Payments = new HashSet<Payments>();
        }

        public int CreditCardId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Payments> Payments { get; set; }
    }
}
