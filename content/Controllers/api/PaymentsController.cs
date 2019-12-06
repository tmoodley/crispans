using System;
using System.Linq;
using System.Threading.Tasks;
using HelpingHands.Data;
using HelpingHands.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Square.Connect.Api;
using Square.Connect.Client;
using Square.Connect.Model;
using Vue2Spa.Models;
using Vue2Spa.Providers;

namespace Vue2Spa.Controllers
{
    [Route("api/[controller]")]
    public class PaymentsController : Controller
    {

        readonly Configuration configuration;
        readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        public PaymentsController(IConfiguration configuration1, ApplicationDbContext context)
        {
            _context = context;
            _configuration = configuration1;
            var url = _configuration["AppSettings:Environment"] == "sandbox" ?
               "https://connect.squareupsandbox.com" : "https://connect.squareup.com";
            this.configuration = new Configuration(new ApiClient(url));
            this.configuration.AccessToken = _configuration["AppSettings:Environment"] == "sandbox" ?
                _configuration["AppSettings:SandboxAccessToken"] : _configuration["AppSettings:AccessToken"];
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Process(string id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            var model = new ProcessPaymentModel(this._configuration);
            PaymentsApi paymentsApi = new PaymentsApi(configuration: this.configuration);
            var customersApi = new CustomersApi(configuration: this.configuration);

            // get customer 
            var _customer = customersApi.RetrieveCustomer(customer.ReferenceId);

            //if customer card exists then delete
            if (_customer.Customer.Cards != null)
            {
                var card = _customer.Customer.Cards.FirstOrDefault();
                
                // Every payment you process with the SDK must have a unique idempotency key.
                // If you're unsure whether a particular payment succeeded, you can reattempt
                // it with the same idempotency key without worrying about double charging
                // the buyer.
                string uuid = NewIdempotencyKey();

                //// Monetary amounts are specified in the smallest unit of the applicable currency.
                //// This amount is in cents. It's also hard-coded for $1.00,
                //// which isn't very useful.
                long cost = 99;
                if (customer.SubscriptionPlan == "Monthly")
                {
                    cost = (long)9.90;
                }
                Money amount = new Money(cost, "USD");

                //// To learn more about splitting payments with additional recipients,
                //// see the Payments API documentation on our [developer site]
                //// (https://developer.squareup.com/docs/payments-api/overview). 
                CreatePaymentRequest createPaymentRequest = new CreatePaymentRequest(AmountMoney: amount, IdempotencyKey: uuid, SourceId: card.Id, CustomerId: customer.ReferenceId);

                try
                {
                    var response = paymentsApi.CreatePayment(createPaymentRequest);

                    //Add Invoice
                    var invoice = new Invoice()
                    {
                        PaymentDate = new DateTime(),
                        CustomerId = id,
                        SubscriptionPlan = customer.SubscriptionPlan,
                        Amount = cost,
                        Email = customer.EmailAddress
                    };
                    await _context.Invoices.AddAsync(invoice);
                    await _context.SaveChangesAsync();
                    return Ok("Payment complete! " + response.ToJson());
                }
                catch (ApiException e)
                {
                    return BadRequest(e.Message);
                }
            }
            return NotFound();
        }

        private static string NewIdempotencyKey()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
