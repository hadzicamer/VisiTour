using System;
using System.Collections.Generic;
using System.Text;

namespace VisiTour.Model
{
    public class Payments
    {

        public int PaymentId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public CreditCards CreditCard { get; set; }
    }
}
