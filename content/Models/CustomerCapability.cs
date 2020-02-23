using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Models
{
    public class CustomerCapability
    { 
        public string CustomerId { get; set; }
        public Guid CapabilityId { get; set; }

        //-----------------------------
        //Relationships
        public Customer Customer { get; set; }
        public Capability Capability { get; set; }
        
    }
}
