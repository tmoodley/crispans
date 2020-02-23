using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Models
{
    public class CustomerIndustry
    { 
        public string CustomerId { get; set; }
        public Guid IndustryId { get; set; }

        //-----------------------------
        //Relationships
        public Customer Customer { get; set; }
        public Industry Industry { get; set; }
        
    }
}
