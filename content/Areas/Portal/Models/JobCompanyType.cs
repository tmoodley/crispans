using System;
using Vue2Spa.Models;

namespace Vue2Spa.Areas.Portal.Models
{
    public class JobCompanyType
    { 
        public string JobId { get; set; }
        public Guid CompanyTypeId { get; set; }

        //-----------------------------
        //Relationships
        public Job Job { get; set; }
        public CompanyType CompanyType { get; set; }        
    }
}
