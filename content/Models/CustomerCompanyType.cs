using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Models
{
    public class CustomerCompanyType
    { 
        public string CustomerId { get; set; }
        public Guid CompanyTypeId { get; set; }

        //-----------------------------
        //Relationships
        public Customer Customer { get; set; }
        public CompanyType CompanyType { get; set; }
        
    }
}
