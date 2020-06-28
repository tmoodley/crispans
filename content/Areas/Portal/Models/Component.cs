using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Areas.Portal.Models
{
    public class Component
    {
        public Guid Id { get; set; } 
        [Display(Name = "Name")]
        public string Name  { get; set; }       
        public string Subject {get; set; }
        public string Note { get; set; }
        public ICollection<Job> Jobs { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
