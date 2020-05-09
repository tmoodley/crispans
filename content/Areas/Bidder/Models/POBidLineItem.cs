using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Areas.Bidder.Models
{
    public class POBidLineItem
    {
        public string PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }

        public Guid BidderId { get; set; }
        public Vue2Spa.Models.Bidder Bidder { get; set; }

        public PurchaseOrderItem PurchaseOrderItem { get; set; }
        public Guid PurchaseOrderItemId { get; set; }


        public string Item { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }


    }
}
