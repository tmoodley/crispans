using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Models.DTO
{
    public class BidderRegisterDto
    {
        [Display(Name="Company Name")]
        public string LegalCompanyName { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Display(Name = "Retype Email Address")]
        public string RetypedEmailAddress { get; set; }

        public string Password { get; set; }
        [Display(Name = "Retype Password")]
        public string RetypedPassword { get; set; }


        public string JobId { get; set; }
    }
}
