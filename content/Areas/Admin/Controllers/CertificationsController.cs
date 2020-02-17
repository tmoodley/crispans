using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;
using Vue2Spa.Models;
using Microsoft.AspNetCore.Authorization;

namespace Vue2Spa.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    public class CertificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CertificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Certifications
        public async Task<IActionResult> Index()
        {
            return View(await _context.Certifications.ToListAsync());
        }

        // GET: Admin/Certifications/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certification = await _context.Certifications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certification == null)
            {
                return NotFound();
            }

            return View(certification);
        }

        // GET: Admin/Certifications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Certifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DisplayOrder")] Certification certification)
        {
            if (ModelState.IsValid)
            {
                certification.Id = Guid.NewGuid();
                _context.Add(certification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(certification);
        }

        // GET: Admin/Certifications/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certification = await _context.Certifications.FindAsync(id);
            if (certification == null)
            {
                return NotFound();
            }
            return View(certification);
        }

        // POST: Admin/Certifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,DisplayOrder")] Certification certification)
        {
            if (id != certification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificationExists(certification.Id))
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
            return View(certification);
        }

        // GET: Admin/Certifications/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certification = await _context.Certifications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certification == null)
            {
                return NotFound();
            }

            return View(certification);
        }

        // POST: Admin/Certifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var certification = await _context.Certifications.FindAsync(id);
            _context.Certifications.Remove(certification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertificationExists(Guid id)
        {
            return _context.Certifications.Any(e => e.Id == id);
        }
    }
}
