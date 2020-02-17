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

namespace Vue2Spa.Controllers.Admin
{
    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    public class CapabilitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CapabilitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Capabilities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Capabilities.ToListAsync());
        }

        // GET: Capabilities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capability = await _context.Capabilities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (capability == null)
            {
                return NotFound();
            }

            return View(capability);
        }

        // GET: Capabilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Capabilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DisplayOrder")] Capability capability)
        {
            if (ModelState.IsValid)
            {
                capability.Id = Guid.NewGuid();
                _context.Add(capability);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(capability);
        }

        // GET: Capabilities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capability = await _context.Capabilities.FindAsync(id);
            if (capability == null)
            {
                return NotFound();
            }
            return View(capability);
        }

        // POST: Capabilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,DisplayOrder")] Capability capability)
        {
            if (id != capability.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(capability);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CapabilityExists(capability.Id))
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
            return View(capability);
        }

        // GET: Capabilities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capability = await _context.Capabilities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (capability == null)
            {
                return NotFound();
            }

            return View(capability);
        }

        // POST: Capabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var capability = await _context.Capabilities.FindAsync(id);
            _context.Capabilities.Remove(capability);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CapabilityExists(Guid id)
        {
            return _context.Capabilities.Any(e => e.Id == id);
        }
    }
}
