using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHands.Models.DTO
{
    public class CustomerDto
    {
        [Display(Name = "Partner Id")]
        public string PartnerId { get; set; }
        [Display(Name = "Primary Source Member Id")]
        public string PrimarySourceMemberId { get; set; }
        public string Username { get; set; } 
        public string Gender { get; set; } 
        [Required]
        [Display(Name = "Address")]
        public string Address1 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [Display(Name = "Postal Code")]
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
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string GivenName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string FamilyName { get; set; }
        public string Nickname { get; set; }
        [Display(Name = "Company")]
        public string CompanyName { get; set; }
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public string ReferenceId { get; set; }
        public string Note { get; set; }
        public DateTime PaidUntil { get; set; }
        public List<InvoiceDto> Invoices { get; set; }
    }
}
