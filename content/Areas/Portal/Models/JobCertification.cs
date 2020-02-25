using System;
using Vue2Spa.Models;

namespace Vue2Spa.Areas.Portal.Models
{
    public class JobCertification
    { 
        public string JobId { get; set; }
        public Guid CertificationId { get; set; }

        //-----------------------------
        //Relationships
        public Job Job { get; set; }
        public Certification Certification { get; set; }
        
    }
}
