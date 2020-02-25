using System;
using Vue2Spa.Models;

namespace Vue2Spa.Areas.Portal.Models
{
    public class JobCategory
    { 
        public string JobId { get; set; }
        public Guid CategoryId { get; set; }

        //-----------------------------
        //Relationships
        public Job Job { get; set; }
        public Category Category { get; set; }
        
    }
}
