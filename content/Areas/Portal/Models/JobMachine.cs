using System;
using Vue2Spa.Models;

namespace Vue2Spa.Areas.Portal.Models
{
    public class JobMachine
    { 
        public string JobId { get; set; }
        public Guid MachineId { get; set; }

        //-----------------------------
        //Relationships
        public Job Job { get; set; }
        public Machine Machine { get; set; }
        
    }
}
