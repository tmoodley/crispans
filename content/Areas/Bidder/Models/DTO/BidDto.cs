using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vue2Spa.Areas.Portal.Models;
using Vue2Spa.Models.DTO;

namespace Vue2Spa.Areas.Bidder.Models.DTO
{
    public class BidDto
    {

        public Guid PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }

        public string JobId { get; set; }
        public Job Job { get; set; }

        public string Source { get; set; }


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

    public enum BidSourceType
    {
        PurchaseOrder,
        Tender
    }
}
