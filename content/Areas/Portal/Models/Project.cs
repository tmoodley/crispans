using HelpingHands.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Areas.Portal.Models
{
    public class Project
    {
        public Guid Id { get; set; } 
        [Display(Name = "Name")]
        public string Name  { get; set; }       
        public string Subject {get; set; }
        public string Note { get; set; }
        public string CustomerId { get; set; }
        public Customer Customers { get; set; }
        public DateTime Created { get; set; }
        public ICollection<Component> Components { get; set; }
    }
}
