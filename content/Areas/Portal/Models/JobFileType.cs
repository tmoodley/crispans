using System;
using Vue2Spa.Models;

namespace Vue2Spa.Areas.Portal.Models
{
    public class JobFileType
    { 
        public string JobId { get; set; }
        public Guid FileTypeId { get; set; }

        //-----------------------------
        //Relationships
        public Job Job { get; set; }
        public FileType FileType { get; set; }
        
    }
}
