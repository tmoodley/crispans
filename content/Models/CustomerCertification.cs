using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Models
{
    public class CustomerCertification
    { 
        public string CustomerId { get; set; }
        public Guid CertificationId { get; set; }

        //-----------------------------
        //Relationships
        public Customer Customer { get; set; }
        public Certification Certification { get; set; }
        
    }
}
