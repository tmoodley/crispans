using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;
using Vue2Spa.Models;
using Vue2Spa.Areas.Bidder.Models.DTO;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using HelpingHands.Services;
using HelpingHands.Models;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Vue2Spa.Areas.Bidder.Controllers
{
    [Area("Bidder")]
    public class BiddersController : Controller
    {
        private readonly UserManager<HelpingHands.Models.ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IEmailAttachmentSender _emailAttachmentSender;
       
        private readonly ApplicationDbContext _context;

        public BiddersController(ApplicationDbContext context,
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

        // GET: Bidder/Bidders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bidders.ToListAsync());
        }

        // GET: Bidder/Bidders/Details/5
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

        // GET: Bidder/Bidders/Create
        public IActionResult Create()
        {
            return View();
        }


        

        // POST: Bidder/Bidders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Website,Address1,City,State,PostalCode,TermsOfService,LegalCompanyName,ContactPerson,TaxRegistrationHST,TaxRegistrationGST,TaxRegistrationFEIN,CellPhone,WorkPhone,EmailAddress")]  Vue2Spa.Models.Bidder bidder)
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

        // GET: Bidder/Bidders/Edit/5
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

        // POST: Bidder/Bidders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Website,Address1,City,State,PostalCode,TermsOfService,LegalCompanyName,ContactPerson,TaxRegistrationHST,TaxRegistrationGST,TaxRegistrationFEIN,CellPhone,WorkPhone,EmailAddress")]  Vue2Spa.Models.Bidder bidder)
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

        // GET: Bidder/Bidders/Delete/5
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

        // POST: Bidder/Bidders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bidder = await _context.Bidders.FindAsync(id);
            _context.Bidders.Remove(bidder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BidderExists(Guid id)
        {
            return _context.Bidders.Any(e => e.Id == id);
        }
    }
}
