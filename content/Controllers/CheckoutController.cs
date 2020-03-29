using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HelpingHands.Data;
using HelpingHands.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Square.Connect.Api;
using Square.Connect.Client;
using Square.Connect.Model;

namespace HelpingHands.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;
        readonly Configuration configuration;
        readonly IConfiguration _configuration;
        public CheckoutController(IConfiguration configuration1, ApplicationDbContext context)
        {
            _context = context;
            _configuration = configuration1;
            var url = _configuration["AppSettings:Environment"] == "sandbox" ?
               "https://connect.squareupsandbox.com" : "https://connect.squareup.com";
            this.configuration = new Configuration(new ApiClient(url)); 
            this.configuration.AccessToken = _configuration["AppSettings:Environment"] == "sandbox" ?
                _configuration["AppSettings:SandboxAccessToken"] : _configuration["AppSettings:AccessToken"];
        }
          
        // GET: Card/Create
        public async Task<ActionResult> ProcessCard(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Check Out";
            var model = new PaymentModel(this._configuration);
            ViewBag.CustomerId = customer.ReferenceId;
            if(customer.SubscriptionPlan == "Monthly")
            {
                ViewBag.Amount = "19.99";
            }
            if (customer.SubscriptionPlan == "Yearly") 
            {
                ViewBag.Amount = "99.00";
            }
            if (customer.SubscriptionPlan == "Free")
            {
                ViewBag.Amount = "0";
            } 
            ViewBag.ApplicationId = _configuration["AppSettings:Environment"] == "sandbox" ?
                _configuration["AppSettings:SandboxApplicationId"] : _configuration["AppSettings:ApplicationId"]; 
            ViewBag.LocationId = _configuration["AppSettings:Environment"] == "sandbox" ?
                _configuration["AppSettings:SandboxLocationId"] : _configuration["AppSettings:LocationId"]; 
            ViewBag.PaymentFormUrl = _configuration["AppSettings:Environment"] == "sandbox" ?
                "https://js.squareupsandbox.com/v2/paymentform" : "https://js.squareup.com/v2/paymentform";
            return View(model);
        } 

        [HttpPost]
        // GET: Card/Edit/5
        public async Task<ActionResult> ProcessPayment([FromForm]string nonce, [FromForm]string customerId)
        {
            ViewData["Title"] = "Payment Processed";
            var model = new ProcessPaymentModel(this._configuration);
            PaymentsApi paymentsApi = new PaymentsApi(configuration: this.configuration);
            var customersApi = new CustomersApi(configuration: this.configuration);
            // Every payment you process with the SDK must have a unique idempotency key.
            // If you're unsure whether a particular payment succeeded, you can reattempt
            // it with the same idempotency key without worrying about double charging
            // the buyer.
            //string uuid = NewIdempotencyKey();

            //// Monetary amounts are specified in the smallest unit of the applicable currency.
            //// This amount is in cents. It's also hard-coded for $1.00,
            //// which isn't very useful.
            //Money amount = new Money(100, "CAD");

            //// To learn more about splitting payments with additional recipients,
            //// see the Payments API documentation on our [developer site]
            //// (https://developer.squareup.com/docs/payments-api/overview). 
            //CreatePaymentRequest createPaymentRequest = new CreatePaymentRequest(AmountMoney: amount, IdempotencyKey: uuid, SourceId: nonce, CustomerId: customerId);

            //try
            //{
            //    var response = paymentsApi.CreatePayment(createPaymentRequest);
            //    ViewBag.ResultMessage = "Payment complete! " + response.ToJson();
            //}
            //catch (ApiException e)
            //{
            //    ViewBag.ResultMessage = e.Message;
            //}

            var body = new CreateCustomerCardRequest(CardNonce: nonce); // CreateCustomerCardRequest | An object containing the fields to POST for the request.  See the corresponding object definition for field details.

            try
            {
                // CreateCustomerCard
                CreateCustomerCardResponse result = customersApi.CreateCustomerCard(customerId, body);
                ViewBag.ResultMessage = result;
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CustomersApi.CreateCustomerCard: " + e.Message);
            }

            if (customerId == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.ReferenceId == customerId);
            if (customer == null)
            {
                return NotFound();
            }

            ViewBag.GivenName = customer.GivenName;
            ViewBag.FamilyName = customer.FamilyName;
            ViewBag.SubscriptionPlan = customer.SubscriptionPlan;

            RedirectToAction("Index", "Dashboard", new { area = "Portal" });
        }

        private static string NewIdempotencyKey()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
