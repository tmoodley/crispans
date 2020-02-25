using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vue2Spa.Areas.Portal.Models;
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
        public List<Job> Jobs { get; set; }
        public bool isActive { get; set; }
        public ICollection<CustomerCategory> CustomerCategories { get; set; }
        public ICollection<CustomerNaics> CustomerNaics { get; set; }
        public ICollection<CustomerCapability> CustomerCapabilities { get; set; }
        public ICollection<CustomerCertification> CustomerCertifications { get; set; }
        public ICollection<CustomerCompanyType> CustomerCompanyTypes { get; set; }
        public ICollection<CustomerFileType> CustomerFileTypes { get; set; }
        public ICollection<CustomerIndustry> CustomerIndustries { get; set; }
        public ICollection<CustomerMachine> CustomerMachines { get; set; }
        public ICollection<CustomerMaterial> CustomerMaterials { get; set; }
    }
}
