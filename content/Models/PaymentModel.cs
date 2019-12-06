using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.Extensions.Configuration;
namespace HelpingHands.Models
{
    public class PaymentModel
    {
        public string PaymentFormUrl { get; set; }
        public string ApplicationId { get; set; }
        public string LocationId { get; set; }


        public PaymentModel(IConfiguration configuration)
        {
            this.ApplicationId = configuration["AppSettings:ApplicationId"];
            this.LocationId = configuration["AppSettings:LocationId"];
            this.PaymentFormUrl = configuration["AppSettings:Environment"] == "sandbox" ?
                "https://js.squareupsandbox.com/v2/paymentform" : "https://js.squareup.com/v2/paymentform";
        }
    }
}
