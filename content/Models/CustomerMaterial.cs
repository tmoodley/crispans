using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Models
{
    public class CustomerMaterial
    { 
        public string CustomerId { get; set; }
        public Guid MaterialId { get; set; }

        //-----------------------------
        //Relationships
        public Customer Customer { get; set; }
        public Material Material { get; set; }
        
    }
}
