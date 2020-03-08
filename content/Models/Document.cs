using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Models
{
    public class Document
    {
        public Guid Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        public string Extension { get; set; }
        public Guid CustomerId { get; set; }
    }
}
