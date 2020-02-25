using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vue2Spa.Areas.Portal.Models;

namespace Vue2Spa.Models
{
    public class Industry
    {
        public Guid Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public ICollection<CustomerIndustry> CustomerIndustries { get; set; }
        public ICollection<JobIndustry> JobIndustries { get; set; }
    }
}
