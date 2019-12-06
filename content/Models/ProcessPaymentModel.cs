using Microsoft.Extensions.Configuration;
using Square.Connect.Api;
using Square.Connect.Client;
using Square.Connect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHands.Models
{
    public class ProcessPaymentModel
    { 
        readonly Configuration configuration;
        public string ResultMessage
        {
            get;
            set;
        } 
        public ProcessPaymentModel(IConfiguration configuration)
        {
            // Set 'basePath' to switch between sandbox env and production env
            // sandbox: https://connect.squareupsandbox.com
            // production: https://connect.squareup.com
            string basePath = configuration["AppSettings:Environment"] == "sandbox" ?
                "https://connect.squareupsandbox.com" : "https://connect.squareup.com";
            this.configuration = new Configuration(new ApiClient(basePath));
            this.configuration.AccessToken = configuration["AppSettings:AccessToken"];
        } 
    }
}
