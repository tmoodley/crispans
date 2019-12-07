using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHands.Models.DTO
{
    public class InvoiceDto
    {
        public Guid Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Notes { get; set; } 
        public string Email { get; set; }
        public double Amount { get; set; }
        public string SubscriptionPlan { get; set; }
    }
}
