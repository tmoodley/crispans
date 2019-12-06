using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHands.Models
{
    public class Contact
    {
        public Guid Id { get; set; } 
        [Display(Name = "Name")]
        public string Name  { get; set; }      
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress {get; set; } 
        public string Subject {get; set; }
        public string Note { get; set; }
    }
}
