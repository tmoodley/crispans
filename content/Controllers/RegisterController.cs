using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;
using HelpingHands.Models;
using Square.Connect.Client;
using Square.Connect.Api;
using Square.Connect.Model;
using System.Diagnostics;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.UI.Services;
using HelpingHands.Services;
using Microsoft.AspNetCore.Http;

namespace HelpingHands.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender; 
        private readonly IEmailAttachmentSender _emailAttachmentSender;
        readonly Configuration configuration;
        readonly IConfiguration _configuration;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public RegisterController(ApplicationDbContext context, IMapper mapper, IConfiguration configuration1, IEmailSender emailSender, IEmailAttachmentSender emailAttachmentSender)
        {
            _emailSender = emailSender;
            _emailAttachmentSender = emailAttachmentSender;
            _context = context;
            _mapper = mapper;
            _configuration = configuration1;
             var url = _configuration["AppSettings:Environment"] == "sandbox" ?
                "https://connect.squareupsandbox.com" : "https://connect.squareup.com";
            this.configuration = new Configuration(new ApiClient(url)); 
            this.configuration.AccessToken = _configuration["AppSettings:Environment"] == "sandbox" ?
                _configuration["AppSettings:SandboxAccessToken"] : _configuration["AppSettings:AccessToken"];  
        }

        // GET: Customers
        public async Task<IActionResult> Index(string partnerId, string subscription = "Monthly")
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("PartnerId")))
            {
                if(string.IsNullOrEmpty(partnerId))
                { 
                    HttpContext.Session.SetString("PartnerId", "281921");
                }
                else
                {
                    HttpContext.Session.SetString("PartnerId", partnerId);
                }
            }

            string userId = this.User.FindFirstValue(ClaimTypes.Name);

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.EmailAddress == userId);
            if (customer != null)
            {
                return RedirectToAction("Index", "Dependents");
            }

            ViewBag.subscription = subscription;
            ViewBag.PrimarySourceId = GeneratePrimaryId();
            var _partnerId = HttpContext.Session.GetString("PartnerId");
            ViewBag.PartnerId = _partnerId;
            return View();
        }
          
        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Subscribe(Models.Customer customer)
        {
            if (ModelState.IsValid)
            {
                //save to square 
                 
                var _customer = await _context.Customers.FirstOrDefaultAsync(m => m.EmailAddress == customer.EmailAddress);
                if (_customer != null)
                {
                    ViewBag.Error = "Email already exists";
                    ViewBag.subscription = "Monthly";
                    ViewBag.Gender = customer.Gender;
                    ViewBag.PrimarySourceId = GeneratePrimaryId();
                    var _partnerId = HttpContext.Session.GetString("PartnerId");
                    ViewBag.PartnerId = _partnerId;
                    return View();
                }

                var apiInstance = new CustomersApi(this.configuration);
                CreateCustomerRequest body = new CreateCustomerRequest(); // CreateCustomerRequest | An object containing the fields to POST for the request.  See the corresponding object definition for field details.
                string userId = this.User.FindFirstValue(ClaimTypes.Name);
                if (userId != null)
                {
                    customer.EmailAddress = userId;
                }
                var model = _mapper.Map<Square.Connect.Model.CreateCustomerRequest>(customer);

                try
                {
                    // CreateCustomer
                    CreateCustomerResponse result = apiInstance.CreateCustomer(model);
                    customer.ReferenceId = result.Customer.Id;
                    _context.Add(customer);
                    await _context.SaveChangesAsync();
                    Debug.WriteLine(result);

                    //send email
                    await _emailSender.SendEmailAsync(
                        "4lifehelpinghands@gmail.com",
                        "New Subscriber",
                        "There is a new contact " + customer.EmailAddress + "<br /> Name:" + customer.FamilyName + " " + customer.FamilyName + "<br /> Subscription Plan:" + customer.SubscriptionPlan);

                    await _emailAttachmentSender.SendEmailAttachmentAsync(
                        customer.EmailAddress,
                        "Thank you for joining Life Helping Hands",
                        "Congratulations!<br />You are eligible for services on the 1st of the month. but in the meantime look out for your welcome kit and download the Tela-Doc application. If you haven't registered already, please register now by clicking on the link below. <br />  <a href='https://lifehelpinghands.org/Identity/Account/Register'>Register</a> now for maintenance of your account.", true);

                }
                catch (Exception e)
                {
                    Debug.Print("Exception when calling CustomersApi.CreateCustomer: " + e.Message);
                }
                return RedirectToAction("ProcessCard", "Checkout", new { id = customer.Id });
            }
            return RedirectToAction("ProcessCard", "Checkout", new { id = customer.Id });
        }

        public string GeneratePrimaryId()
        {
            var s = GenerateId();

            //CHECK IF IT EXISTS IN DB
            while (_context.Customers.Any(m => m.PrimarySourceMemberId == s))
            {
                s = GenerateId();
            } 

            return s;
        }

        private static string GenerateId()
        {
            Random r = new Random();
            var x = r.Next(0, 10000000);
            string s = x.ToString("0000000");

            return s;
        }
    }
}
