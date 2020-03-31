using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;
using Vue2Spa.Models;
using Microsoft.AspNetCore.Identity;
using HelpingHands.Models;
using HelpingHands.Services;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Vue2Spa.Areas.Bidder.Controllers.api
{
    [Route("/bidder/api/[controller]")]
    [ApiController]
    public class BiddersApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<HelpingHands.Models.ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IEmailAttachmentSender _emailAttachmentSender;

        public BiddersApiController(ApplicationDbContext context,
            IEmailSender emailSender,
                                            IEmailAttachmentSender emailAttachmentSender,
                                            UserManager<HelpingHands.Models.ApplicationUser> userManager,
                                            SignInManager<HelpingHands.Models.ApplicationUser> signInManager,
                                            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _emailAttachmentSender = emailAttachmentSender;
        }

        // GET: api/BiddersApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vue2Spa.Models.Bidder>>> GetBidders()
        {
            return await _context.Bidders.ToListAsync();
        }

        // GET: api/BiddersApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vue2Spa.Models.Bidder>> GetBidder(Guid id)
        {
            var bidder = await _context.Bidders.FindAsync(id);

            if (bidder == null)
            {
                return NotFound();
            }

            return bidder;
        }

        // PUT: api/BiddersApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBidder(Guid id, Vue2Spa.Models.Bidder bidder)
        {
            if (id != bidder.Id)
            {
                return BadRequest();
            }

            _context.Entry(bidder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BidderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BiddersApi
        [HttpPost]
        public async Task<ActionResult<Vue2Spa.Models.Bidder>> PostBidder(Vue2Spa.Models.Bidder bidder)
        {


            if (string.IsNullOrEmpty(bidder.EmailAddress))
            {
                //ViewData["Error"] = "Valid Email is Required.";

                return NoContent(); ;
            }

            var _bidder = await _context.Bidders.FirstOrDefaultAsync(m => m.EmailAddress == bidder.EmailAddress);
            if (_bidder != null)
            {
               // ViewBag.Error = "Email already exists";

                return NoContent(); ;
            }

            try
            {


                _context.Bidders.Add(bidder);
                await _context.SaveChangesAsync();


                var user = new HelpingHands.Models.ApplicationUser
                {
                    Email = bidder.EmailAddress,
                    UserName = bidder.EmailAddress
                };

                var identityResult = await _userManager.CreateAsync(user).ConfigureAwait(false);
                await _userManager.AddPasswordAsync(user, "Password123456").ConfigureAwait(false);

                //add partner role
                var RoleManager = _roleManager;
                var UserManager = _userManager;

                IdentityResult roleResult;

                //Adding Partner Role
                var roleCheck = await RoleManager.RoleExistsAsync("Bidder").ConfigureAwait(false);
                if (!roleCheck)
                {
                    //create the roles and seed them to the database
                    roleResult = await RoleManager.CreateAsync(new IdentityRole("Bidder")).ConfigureAwait(false);
                }

                //Assign Admin role to the main User here we have given our newly registered 
                //login id for Admin management
                ApplicationUser _user = await UserManager.FindByEmailAsync(bidder.EmailAddress).ConfigureAwait(false);

                await UserManager.AddToRoleAsync(_user, "Bidder").ConfigureAwait(false);

                //send email
                await _emailSender.SendEmailAsync(
                    "ty.moodley@gmail.com",
                    "New Bidder",
                    "There is a new contact " + bidder.EmailAddress + "<br /> Name:" + bidder.ContactPerson + "<br />");

                await _emailAttachmentSender.SendEmailAttachmentAsync(
                    bidder.EmailAddress,
                    "Thank you for joining Capacitym",
                    "Congratulations!<br />You are eligible for services on the 1st of the month. but in the meantime look out for your welcome kit. If you haven't registered already, please register now by clicking on the link below. <br />  <a href='https://capacitym.com/Identity/Account/Login'>Login</a> - using default password 'Password123456' and your email " + bidder.EmailAddress + " for maintenance of your account.", true);


            }
            catch (Exception ex)
            {

            }
            










            return CreatedAtAction("GetBidder", new { id = bidder.Id }, bidder);
        }

        // DELETE: api/BiddersApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vue2Spa.Models.Bidder>> DeleteBidder(Guid id)
        {
            var bidder = await _context.Bidders.FindAsync(id);
            if (bidder == null)
            {
                return NotFound();
            }

            _context.Bidders.Remove(bidder);
            await _context.SaveChangesAsync();

            return bidder;
        }

        private bool BidderExists(Guid id)
        {
            return _context.Bidders.Any(e => e.Id == id);
        }
    }
}
