using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHands.Models
{
    public class PurchaseOrder
    {
        public Guid Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Notes { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string CustomerId { get; set; }
        public Customer Customers { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }        
        public double Amount { get; set; }
        public List<PurchaseOrderItem> PurchaseOrderItems { get; set; }
    }
}
