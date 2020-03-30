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
    }
}
