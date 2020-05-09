using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Models
{
    public class POQuestion
    {
        public Guid QuestionId { get; set; }

        
        public Guid PurchaseOrderId { get; set; }        

        public PurchaseOrder PurchaseOrder { get; set; }
        public Question Question { get; set; }

        public Vue2Spa.Models.Bidder Bidder { get; set; }
        public Guid? BidderId { get; set; }
    }
}
