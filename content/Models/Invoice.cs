using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Models
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Notes { get; set; }
        public string CustomerId { get; set; }
        public Customer Customers { get; set; }
        public string Email { get; set; }
        public double Amount { get; set; }
        public string SubscriptionPlan { get; set; }
    }
}
