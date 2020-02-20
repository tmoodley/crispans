using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vue2Spa.Models;

namespace HelpingHands.Models
{
    public class Customer
    {
        [Display(Name = "Partner Id")]
        public string PartnerId { get; set;} 
        [Display(Name = "Primary Source Member Id")]
        public string PrimarySourceMemberId { get; set; } 
        [Required]
        [Display(Name = "Number of Employees")]
        public int NumberOfEmployees { get; set; }
        public string Username { get; set; }
        [BindProperty, Required]
        public string Gender { get; set; }
        public string[] Genders = new[] { "Male", "Female", "Unspecified" };
        [Required]
        [Display(Name = "Address")]
        public string Address1 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [Display(Name= "Postal Code")]
        public string PostalCode { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Phone]
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }
        [Phone]
        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }
        [Required]
        [Display(Name = "Subscription Plan")]
        public string SubscriptionPlan { get; set; }
        public string Id {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string GivenName {get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string FamilyName {get; set;}
        public string Nickname {get; set; }
        [Required]
        [Display(Name = "Company")]
        public string CompanyName {get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress {get; set; }
        [Required]
        public DateTime Birthday {get; set;}
        public string ReferenceId {get; set;}
        public string Note {get; set;} 
        public List<Invoice> Invoices { get; set; }
        public bool isActive { get; set; }

        public virtual ICollection<Capability> Capabilities { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Certification> Certifications { get; set; }
        public virtual ICollection<CompanyType> CompanyTypes { get; set; }
        public virtual ICollection<FileType> FileTypes { get; set; }
        public virtual ICollection<Industry> Industries { get; set; }
        public virtual ICollection<Machine> Machines { get; set; }
        public virtual ICollection<Material> Materials { get; set; }
        public virtual ICollection<Naics> Naics { get; set; }
    }
}
