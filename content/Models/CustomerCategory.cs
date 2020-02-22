using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Models
{
    public class CustomerCategory
    { 
        public string CustomerId { get; set; }
        public Guid CategoryId { get; set; }

        //-----------------------------
        //Relationships
        public Customer Customer { get; set; }
        public Category Category { get; set; }
        
    }
}
