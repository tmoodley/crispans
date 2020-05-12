using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vue2Spa.Areas.Portal.Models;
using Vue2Spa.Models;

namespace Vue2Spa.Areas.Portal.Models
{
    public class JobCapability
    {
        public string JobId { get; set; }
        public Guid CapabilityId { get; set; }

        //-----------------------------
        //Relationships
        public Job Job { get; set; }
        public Capability Capability { get; set; }
        
    }
}
