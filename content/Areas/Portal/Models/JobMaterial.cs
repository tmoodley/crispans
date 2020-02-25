using System;
using Vue2Spa.Models;

namespace Vue2Spa.Areas.Portal.Models
{
    public class JobMaterial
    { 
        public string JobId { get; set; }
        public Guid MaterialId { get; set; }

        //-----------------------------
        //Relationships
        public Job Job { get; set; }
        public Material Material { get; set; }
        
    }
}
