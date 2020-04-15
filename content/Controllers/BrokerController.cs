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
using Microsoft.AspNetCore.Identity;

namespace Vue2Spa.Controllers
{
    public class BrokerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly IEmailAttachmentSender _emailAttachmentSender;

        readonly Configuration configuration;
        readonly IConfiguration _configuration;

        private readonly UserManager<HelpingHands.Models.ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public BrokerController(ApplicationDbContext context,
                                            IMapper mapper,
                                            IConfiguration configuration1,
                                            IEmailSender emailSender,
                                            IEmailAttachmentSender emailAttachmentSender,
                                            UserManager<HelpingHands.Models.ApplicationUser> userManager,
                                            SignInManager<HelpingHands.Models.ApplicationUser> signInManager,
                                            RoleManager<IdentityRole> roleManager)
        {
            _emailSender = emailSender;
            _emailAttachmentSender = emailAttachmentSender;
            _context = context;
            _mapper = mapper;
            _configuration = configuration1;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }

        // GET: Supplier/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HelpingHands.Models.Customer customer)
        {
            if (ModelState.IsValid)
            {
                //Make sure email is not null 
                if (string.IsNullOrEmpty(customer.EmailAddress))
                {
                    ViewBag.Error = "Valid Email is Required.";
                    return View();
                }

                var _customer = await _context.Customers.FirstOrDefaultAsync(m => m.EmailAddress == customer.EmailAddress).ConfigureAwait(false);
                if (_customer != null)
                {
                    ViewBag.Error = "Email already exists";
                    return View();
                }

                CreateCustomerRequest body = new CreateCustomerRequest(); // CreateCustomerRequest | An object containing the fields to POST for the request.  See the corresponding object definition for field details.
                string userId = this.User.FindFirstValue(ClaimTypes.Name);
                if (userId != null)
                {
                    customer.EmailAddress = userId;
                }

                try
                {
                    _context.Add(customer);
                    await _context.SaveChangesAsync().ConfigureAwait(false);

                    //auto register user 
                    var user = new HelpingHands.Models.ApplicationUser
                    {
                        Email = customer.EmailAddress,
                        UserName = customer.EmailAddress
                    };

                    var identityResult = await _userManager.CreateAsync(user).ConfigureAwait(false);
                    await _userManager.AddPasswordAsync(user, "Password123456").ConfigureAwait(false);

                    //add partner role
                    var RoleManager = _roleManager;
                    var UserManager = _userManager;

                    IdentityResult roleResult;

                    //Adding Partner Role
                    var roleCheck = await RoleManager.RoleExistsAsync("Broker").ConfigureAwait(false);
                    if (!roleCheck)
                    {
                        //create the roles and seed them to the database
                        roleResult = await RoleManager.CreateAsync(new IdentityRole("Broker")).ConfigureAwait(false);
                    }

                    //Assign Admin role to the main User here we have given our newly registered 
                    //login id for Admin management
                    ApplicationUser _user = await UserManager.FindByEmailAsync(customer.EmailAddress).ConfigureAwait(false);

                    await UserManager.AddToRoleAsync(_user, "Broker").ConfigureAwait(false);

                    //send email
                    await _emailSender.SendEmailAsync(
                        "ty.moodley@gmail.com",
                        "New Broker",
                        "There is a new contact " + customer.EmailAddress + "<br /> Name:" + customer.FamilyName + " " + customer.FamilyName + "<br /> Subscription Plan:" + customer.SubscriptionPlan).ConfigureAwait(false);

                    await _emailAttachmentSender.SendEmailAttachmentAsync(
                        customer.EmailAddress,
                        "Thank you for joining Capacitym",
                        "Congratulations!<br />You are eligible for services on the 1st of the month. but in the meantime look out for your welcome kit. If you haven't registered already, please register now by clicking on the link below. <br />  <a href='https://capacitym.com/Identity/Account/Login'>Login</a> - using default password 'Password123456' and your email " + customer.EmailAddress + " for maintenance of your account.", true).ConfigureAwait(false);


                }
                catch (Exception e)
                {
                    Debug.Print("Exception when calling CustomersApi.CreateCustomer: " + e.Message);
                }
            }
            var result2 = await _signInManager.PasswordSignInAsync(customer.EmailAddress, "Password123456", true, lockoutOnFailure: true).ConfigureAwait(false);
            return RedirectToAction("Create", "PurchaseOrders");
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Supplier/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
