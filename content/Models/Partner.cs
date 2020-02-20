using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vue2Spa.Models;

namespace HelpingHands.Models
{
    public class Partner
    {
        public Guid Id { get; set; }
        [Display(Name = "Partner Id")]
        public string PartnerId { get; set;} 
        [Display(Name = "Organization Name")]
        public string OrganizationName  { get; set; }
        [Display(Name = "Number of Employees")] 
        public int NumberOfEmployees { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }        
        public string Username { get; set; } 
        [Required]
        [Display(Name = "Address")]
        public string Address1 { get; set; } 
        public string City { get; set; } 
        public string State { get; set; } 
        [Display(Name= "Postal Code")]
        public string PostalCode { get; set; } 
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
        [Display(Name = "Subscription Plan")]
        public string SubscriptionPlan { get; set; }
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set; } 
        [Display(Name = "First Name")]
        public string GivenName {get; set; } 
        [Display(Name = "Last Name")]
        public string FamilyName {get; set;}
        public string Nickname {get; set; }
        [Display(Name = "Company")]
        public string CompanyName {get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress {get; set; }
        public DateTime Birthday {get; set;}
        public string ReferenceId {get; set;}
        public string Note {get; set; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; } 
    }
}
