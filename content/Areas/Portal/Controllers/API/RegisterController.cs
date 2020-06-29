using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;
using HelpingHands.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using HelpingHands.Services;
using Square.Connect.Client;
using Microsoft.Extensions.Configuration;
using AutoMapper;

namespace Vue2Spa.Areas.Portal.Controllers.API
{
    [Route("/portal/api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
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

        public RegisterController(ApplicationDbContext context,
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
            var url = _configuration["AppSettings:Environment"] == "sandbox" ?
               "https://connect.squareupsandbox.com" : "https://connect.squareup.com";
            this.configuration = new Configuration(new ApiClient(url));
            this.configuration.AccessToken = _configuration["AppSettings:Environment"] == "sandbox" ?
                _configuration["AppSettings:SandboxAccessToken"] : _configuration["AppSettings:AccessToken"];
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.Include(x => x.CustomerCategories).ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(string id)
        {
            var customer = await _context.Customers
                .Include(x => x.CustomerCategories)
                .Include(x => x.CustomerCertifications)
                .Include(x => x.CustomerCapabilities)
                .Include(x => x.CustomerCompanyTypes)
                .Include(x => x.CustomerFileTypes)
                .Include(x => x.CustomerIndustries)
                .Include(x => x.CustomerMachines)
                .Include(x => x.CustomerMaterials)
                .Include(x => x.CustomerNaics)
                .Where(x => x.EmailAddress == id).FirstOrDefaultAsync().ConfigureAwait(false);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [AllowAnonymous]
        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> PutCustomer(string id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return customer;
        }

        public class CreateCustomer {
            public string email { get; set; }
            public string password { get; set; }
            public string givenName { get; set; }
            public string familyName { get; set; }
        }
        [AllowAnonymous]
        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CreateCustomer customer)
        {
            Customer _customer = new Customer
            {
                EmailAddress = customer.email,
                GivenName = customer.givenName,
                FamilyName = customer.familyName
            };
            _context.Customers.Add(_customer);
            await _context.SaveChangesAsync();

            //auto register user 
            var user = new HelpingHands.Models.ApplicationUser
            {
                Email = _customer.EmailAddress,
                UserName = _customer.EmailAddress
            };

            var identityResult = await _userManager.CreateAsync(user).ConfigureAwait(false);
            await _userManager.AddPasswordAsync(user, customer.password).ConfigureAwait(false);

            //add partner role
            var RoleManager = _roleManager;
            var UserManager = _userManager;

            IdentityResult roleResult;

            //Adding Partner Role
            var roleCheck = await RoleManager.RoleExistsAsync("Partner").ConfigureAwait(false);
            if (!roleCheck)
            {
                //create the roles and seed them to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Partner")).ConfigureAwait(false);
            }

            //Assign Admin role to the main User here we have given our newly registered 
            //login id for Admin management
            ApplicationUser _user = await UserManager.FindByEmailAsync(_customer.EmailAddress).ConfigureAwait(false);

            await UserManager.AddToRoleAsync(_user, "Partner").ConfigureAwait(false);

            //send email
            await _emailSender.SendEmailAsync(
                "ty.moodley@gmail.com",
                "New Subscriber",
                "There is a new contact " + _customer.EmailAddress + "<br /> Name:" + _customer.FamilyName + " " + _customer.FamilyName + "<br /> Subscription Plan:" + _customer.SubscriptionPlan);

            await _emailAttachmentSender.SendEmailAttachmentAsync(
                _customer.EmailAddress,
                "Thank you for joining Capacitym",
                "Congratulations!<br />You are eligible for services on the 1st of the month. but in the meantime look out for your welcome kit. If you haven't registered already, please register now by clicking on the link below. <br />  <a href='https://capacitym.com/portal/dashboard/'>Login</a>", true);


            return CreatedAtAction("GetCustomer", new { id = _customer.Id }, _customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(string id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        private bool CustomerExists(string id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
