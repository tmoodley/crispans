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
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;

        public ContactsController(ApplicationDbContext context, IEmailSender emailSender)
        {
            _emailSender = emailSender;
            _context = context;
        }

        [Authorize(Roles = "Administrator")]
        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacts.ToListAsync());
        }

        // GET: Contacts/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost] 
        public async Task<IActionResult> Create([Bind("Id,Name,EmailAddress,Subject,Note")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.Id = Guid.NewGuid();
                _context.Add(contact);
                await _context.SaveChangesAsync();

                await _emailSender.SendEmailAsync(
                   "4lifehelpinghands@gmail.com",
                   "New Contact",
                   "There is a new contact " + contact.EmailAddress + "<br /> Name:" + contact.Name + "<br /> Subject:" + contact.Subject + "<br /> Message:" + contact.Note);

                await _emailSender.SendEmailAsync(
                   contact.EmailAddress,
                   "Thank you for contacting us",
                   "Thank you for contacting us, one of our customer service reps will be contacting you soon.");

                return RedirectToAction("ThankYouForContactingUs"); 
            }
            return View(contact);
        }

        public IActionResult ThankYouForContactingUs()
        {
            return View();
        }

        // GET: Contacts/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,EmailAddress,Subject,Note")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
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
            return View(contact);
        }

        // GET: Contacts/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(Guid id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
