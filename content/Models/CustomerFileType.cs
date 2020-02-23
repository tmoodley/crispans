using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Models
{
    public class CustomerFileType
    { 
        public string CustomerId { get; set; }
        public Guid FileTypeId { get; set; }

        //-----------------------------
        //Relationships
        public Customer Customer { get; set; }
        public FileType FileType { get; set; }
        
    }
}
