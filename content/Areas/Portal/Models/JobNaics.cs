using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vue2Spa.Areas.Portal.Models;
using Vue2Spa.Models;

namespace Vue2Spa.Areas.Portal.Models
{
    public class JobNaics
    { 
        public string JobId { get; set; }
        public Guid NaicsId { get; set; }

        //-----------------------------
        //Relationships
        public Job Job { get; set; }
        public Naics Naics { get; set; }
        
    }
}
