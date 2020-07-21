using System;
using System.Collections.Generic;

namespace VisiTour.WebAPI.Database
{
    public partial class Payments
    {
        public int PaymentId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public int? CreditCardId { get; set; }

        public virtual CreditCards CreditCard { get; set; }
    }
}
