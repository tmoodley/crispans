using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;
using HelpingHands.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authorization;

namespace HelpingHands.Controllers
{
    public class PartnersController : Controller
    {
        private readonly ApplicationDbContext _context; 
        private readonly IEmailSender _emailSender;
        public PartnersController(ApplicationDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        // GET: Partners
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Partners.ToListAsync());
        }

        // GET: Partners/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partner == null)
            {
                return NotFound();
            }

            return View(partner);
        }

        // GET: Partners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Partners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,PartnerId,OrganizationName,NumberOfEmployees,ContactPerson,Username,Address1,City,State,PostalCode,StartDate,PhoneNumber,CellPhone,WorkPhone,SubscriptionPlan,CreatedAt,UpdatedAt,GivenName,FamilyName,Nickname,CompanyName,EmailAddress,Birthday,ReferenceId,Note")] Partner partner)
        {
            if (ModelState.IsValid)
            {
                partner.Id = Guid.NewGuid();
                _context.Add(partner);
                await _context.SaveChangesAsync();

                await _emailSender.SendEmailAsync(
                 "ty.moodley@gmail.com",
                 "New Partner",
                 "There is a new contact " + partner.EmailAddress + "<br /> Name:" + partner.ContactPerson + "<br /> Message:" + partner.Note);

                await _emailSender.SendEmailAsync(
                   partner.EmailAddress,
                   "Thank you for contacting us",
                   "Thank you for contacting us, one of our customer service reps will be contacting you soon.");

                return RedirectToAction("ThankYouForContactingUs"); 
            }
            return View(partner);
        }

        public IActionResult ThankYouForContactingUs()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        // GET: Partners/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partners.FindAsync(id);
            if (partner == null)
            {
                return NotFound();
            }
            return View(partner);
        }

        [Authorize(Roles = "Administrator")]
        // POST: Partners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PartnerId,OrganizationName,NumberOfEmployees,ContactPerson,Username,Address1,City,State,PostalCode,StartDate,PhoneNumber,CellPhone,WorkPhone,SubscriptionPlan,CreatedAt,UpdatedAt,GivenName,FamilyName,Nickname,CompanyName,EmailAddress,Birthday,ReferenceId,Note")] Partner partner)
        {
            if (id != partner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnerExists(partner.Id))
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
            return View(partner);
        }

        // GET: Partners/Delete/5

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partner == null)
            {
                return NotFound();
            }

            return View(partner);
        }

        // POST: Partners/Delete/5

        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var partner = await _context.Partners.FindAsync(id);
            _context.Partners.Remove(partner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnerExists(Guid id)
        {
            return _context.Partners.Any(e => e.Id == id);
        }
    }
}
