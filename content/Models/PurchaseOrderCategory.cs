using HelpingHands.Models;
using System;
using Vue2Spa.Models;

namespace Vue2Spa.Areas.Portal.Models
{
    public class PurchaseOrderCategory
    { 
        public Guid PurchaseOrderId { get; set; }
        public Guid CategoryId { get; set; }

        //-----------------------------
        //Relationships
        public PurchaseOrder PurchaseOrder { get; set; }
        public Category Category { get; set; }
        
    }
}
