using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHands.Models
{
    public class Dependent
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string GivenName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string FamilyName { get; set; }
        public string Nickname { get; set; } 
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
        [Required]
        public DateTime Birthday { get; set; }

        public string CustomerId { get; set; }
        public Customer Customers { get; set; }
    }
}
