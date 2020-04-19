using HelpingHands.Models;
using System;
using Vue2Spa.Models;

namespace Vue2Spa.Areas.Portal.Models
{
    public class ProductCategory
    { 
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }

        //-----------------------------
        //Relationships
        public Product Product { get; set; }
        public Category Category { get; set; }
        
    }
}
