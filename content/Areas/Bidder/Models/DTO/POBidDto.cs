using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Models.DTO
{
    public class POBidDto
    {
        public Guid PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }

        public string BidderId { get; set; }
        //public Vue2Spa.Models.Bidder Bidder { get; set; }

        public string Status { get; set; }

        public bool Deleted { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastUpdated { get; set; }

        public string LastUpdatedBy { get; set; }

        public List<POBidLineItemDto> LineItems { get; set; }



    }

    public class POBidLineItemDto
    {
        public string PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }

        public Guid BidderId { get; set; }
        public Vue2Spa.Models.Bidder Bidder { get; set; }

        public PurchaseOrderItem PurchaseOrderItem { get; set; }
        public Guid PurchaseOrderItemId { get; set; }

        public bool Bid { get; set; }

        public string Item { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
    }
}
