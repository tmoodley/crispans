using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vue2Spa.Areas.Portal.Models;

namespace Vue2Spa.Models
{
    public class CompanyType
    {
        public Guid Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public ICollection<CustomerCompanyType> CustomerCompanyTypes { get; set; }
        public ICollection<JobCompanyType> JobCompanyTypes { get; set; }
        public ICollection<PartnerCompanyType> PartnerCompanyTypes { get; set; }
    }
}
