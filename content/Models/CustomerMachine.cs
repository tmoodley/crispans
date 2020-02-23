using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Models
{
    public class CustomerMachine
    { 
        public string CustomerId { get; set; }
        public Guid MachineId { get; set; }

        //-----------------------------
        //Relationships
        public Customer Customer { get; set; }
        public Machine Machine { get; set; }
        
    }
}
