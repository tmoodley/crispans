using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;
using Vue2Spa.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using HelpingHands.Models;
using HelpingHands.Services;
using System.Diagnostics;
using Vue2Spa.Models.DTO;
using AutoMapper;

namespace Vue2Spa.Controllers
{
    public class BiddersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<HelpingHands.Models.ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IEmailAttachmentSender _emailAttachmentSender;
        private readonly IMapper _mapper;

        public BiddersController(ApplicationDbContext context,
            IEmailSender emailSender,
                                            IEmailAttachmentSender emailAttachmentSender,
                                            UserManager<HelpingHands.Models.ApplicationUser> userManager,
                                            SignInManager<HelpingHands.Models.ApplicationUser> signInManager,
                                            RoleManager<IdentityRole> roleManager,
                                            IMapper mapper
                                            )
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _emailAttachmentSender = emailAttachmentSender;
            _mapper = mapper;
        }

        // GET: Bidders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bidders.ToListAsync());
        }

        // GET: Bidders/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidder = await _context.Bidders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bidder == null)
            {
                return NotFound();
            }

            return View(bidder);
        }

        // GET: Bidders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bidders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Website,Address1,City,State,PostalCode,TermsOfService,LegalCompanyName,ContactPerson,TaxRegistrationHST,TaxRegistrationGST,TaxRegistrationFEIN,CellPhone,WorkPhone,EmailAddress")] Bidder bidder)
        {
            if (ModelState.IsValid)
            {
                bidder.Id = Guid.NewGuid();
                _context.Add(bidder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bidder);
        }

        // GET: Bidders/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidder = await _context.Bidders.FindAsync(id);
            if (bidder == null)
            {
                return NotFound();
            }
            return View(bidder);
        }

        // POST: Bidders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Website,Address1,City,State,PostalCode,TermsOfService,LegalCompanyName,ContactPerson,TaxRegistrationHST,TaxRegistrationGST,TaxRegistrationFEIN,CellPhone,WorkPhone,EmailAddress")] Bidder bidder)
        {
            if (id != bidder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bidder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidderExists(bidder.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bidder);
        }

        // GET: Bidders/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidder = await _context.Bidders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bidder == null)
            {
                return NotFound();
            }

            return View(bidder);
        }

        // POST: Bidders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bidder = await _context.Bidders.FindAsync(id);
            _context.Bidders.Remove(bidder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Register()
        {
            ViewData["JobId"] = TempData["jobId"];
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register( BidderRegisterDto bidder)
        {

            if (ModelState.IsValid)
            {
                
                if (string.IsNullOrEmpty(bidder.EmailAddress))
                {
                    ViewBag.Error = "Valid Email is Required.";

                    return View();
                }

                if (!bidder.EmailAddress.Equals(bidder.RetypedEmailAddress))
                {
                    ViewBag.Error = "Emails do not match.";
                    return View();

                }

                if (!bidder.Password.Equals(bidder.RetypedPassword))
                {
                    ViewBag.Error = "Passwords do not match.";
                    return View();

                }



                var _bidder = await _context.Bidders.FirstOrDefaultAsync(m => m.EmailAddress == bidder.EmailAddress);
                if (_bidder != null)
                {
                    ViewBag.Error = "Email already exists";

                    return View();
                }

                try
                {
                    Bidder profileDetails = new Bidder()
                    {
                        ContactPerson = bidder.ContactPerson,
                        LegalCompanyName = bidder.LegalCompanyName,
                        EmailAddress = bidder.EmailAddress,
                        PostalCode = "",
                        Address1 = "",City = "",State=""
                    };

                    _context.Add(profileDetails);
                    await _context.SaveChangesAsync();


                    var user = new HelpingHands.Models.ApplicationUser
                    {
                        Email = bidder.EmailAddress,
                        UserName = bidder.EmailAddress
                    };



                    IdentityResult identityResult = null;
                    // add partner role
                    var RoleManager = _roleManager;
                    var UserManager = _userManager;

                    ApplicationUser _user = await UserManager.FindByEmailAsync(bidder.EmailAddress).ConfigureAwait(false);

                    if(_user == null)
                    {
                        identityResult = await _userManager.CreateAsync(user).ConfigureAwait(false);
                        await _userManager.AddPasswordAsync(user, bidder.Password).ConfigureAwait(false);
                    }

                    
                    

                    

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
                    bool userInRoleAlready = await _userManager.IsInRoleAsync(user, "Bidder");

                    if (!userInRoleAlready)
                    {
                        await UserManager.AddToRoleAsync(_user, "Bidder").ConfigureAwait(false);
                    }
                    

                    //send email
                    await _emailSender.SendEmailAsync(
                        "ty.moodley@gmail.com",
                        "New Bidder",
                        "There is a new contact " + bidder.EmailAddress + "<br /> Name:" + bidder.ContactPerson + "<br />");

                    await _emailAttachmentSender.SendEmailAttachmentAsync(
                        bidder.EmailAddress,
                        "Thank you for joining Capacitym",
                        "Congratulations!<br />You are eligible for services on the 1st of the month. but in the meantime look out for your welcome kit. If you haven't registered already, please register now by clicking on the link below. <br />  <a href='https://capacitym.com/Identity/Account/Login'>Login</a> - using default password 'Password123456' and your email " + bidder.EmailAddress + " for maintenance of your account.", true);


                    // register for  this bid


                    

                    return RedirectToAction("Bid","Tenders",new { id = bidder.JobId, bidder = bidder.EmailAddress });

                }
                catch (Exception ex)
                {
                    Debug.Print("Exception when Registering new Bidder to the system");
                }


            }

            return View(nameof(Index));
        }



        private bool BidderExists(Guid id)
        {
            return _context.Bidders.Any(e => e.Id == id);
        }
    }
}
