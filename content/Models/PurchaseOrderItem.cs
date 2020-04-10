using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHands.Models
{
    public class PurchaseOrderItem
    {
        public Guid Id { get; set; }
        public string PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
    }
}
