using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Models
{
    public class CustomerNaics
    { 
        public string CustomerId { get; set; }
        public Guid NaicsId { get; set; }

        //-----------------------------
        //Relationships
        public Customer Customer { get; set; }
        public Naics Naics { get; set; }
        
    }
}
