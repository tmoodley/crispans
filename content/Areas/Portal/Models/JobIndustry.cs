using System;
using Vue2Spa.Models;

namespace Vue2Spa.Areas.Portal.Models
{
    public class JobIndustry
    { 
        public string JobId { get; set; }
        public Guid IndustryId { get; set; }

        //-----------------------------
        //Relationships
        public Job Job { get; set; }
        public Industry Industry { get; set; }
        
    }
}
