using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vue2Spa.Areas.Portal.Models;

namespace Vue2Spa.Models
{
    public class Machine
    {
        public Guid Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public ICollection<CustomerMachine> CustomerMachines { get; set; }
        public ICollection<JobMachine> JobMachines { get; set; }
    }
}
