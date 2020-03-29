using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vue2Spa.Models;

namespace Vue2Spa.Areas.Portal.Models
{
    public class PartnerCompanyType
    {
        public Guid PartnerId { get; set; }
        public Guid CompanyTypeId { get; set; }

        //-----------------------------
        //Relationships
        public Partner Partner { get; set; }
        public CompanyType CompanyType { get; set; }
    }
}
