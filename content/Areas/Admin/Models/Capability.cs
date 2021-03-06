using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vue2Spa.Areas.Portal.Models;

namespace Vue2Spa.Models
{
    public class Capability
    {
        public Guid Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public ICollection<CustomerCapability> CustomerCapabilities { get; set; }
        public ICollection<JobCapability> JobCapabilities { get; set; }
    }
}
