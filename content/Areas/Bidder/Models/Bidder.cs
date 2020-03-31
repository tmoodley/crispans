using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Models
{
    public class Bidder
    {
        public Guid Id { get; set; }
        public string  Website { get; set; }
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
        public string TermsOfService { get; set; }
        public string LegalCompanyName { get; set; }
        public string ContactPerson { get; set; }

        public string TaxRegistrationHST { get; set; }
        public string TaxRegistrationGST { get; set; }
        public string TaxRegistrationFEIN { get; set; }
        [Phone]
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }
        [Phone]
        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }
        //[Required]
        //[Display(Name = "Subscription Plan")]
        //public string SubscriptionPlan { get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

    }
}
