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
    public class NaicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NaicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Naics
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Naics.Include(n => n.Parent);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Naics/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naics = await _context.Naics
                .Include(n => n.Parent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (naics == null)
            {
                return NotFound();
            }

            return View(naics);
        }

        // GET: Admin/Naics/Create
        public IActionResult Create()
        {
            ViewData["ParentId"] = new SelectList(_context.Naics, "Id", "Name");
            return View();
        }

        // POST: Admin/Naics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParentId,Name,DisplayOrder")] Naics naics)
        {
            if (ModelState.IsValid)
            {
                naics.Id = Guid.NewGuid();
                _context.Add(naics);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentId"] = new SelectList(_context.Naics, "Id", "Name", naics.ParentId);
            return View(naics);
        }

        // GET: Admin/Naics/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naics = await _context.Naics.FindAsync(id);
            if (naics == null)
            {
                return NotFound();
            }
            ViewData["ParentId"] = new SelectList(_context.Naics, "Id", "Name", naics.ParentId);
            return View(naics);
        }

        // POST: Admin/Naics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ParentId,Name,DisplayOrder")] Naics naics)
        {
            if (id != naics.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(naics);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NaicsExists(naics.Id))
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
            ViewData["ParentId"] = new SelectList(_context.Naics, "Id", "Name", naics.ParentId);
            return View(naics);
        }

        // GET: Admin/Naics/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naics = await _context.Naics
                .Include(n => n.Parent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (naics == null)
            {
                return NotFound();
            }

            return View(naics);
        }

        // POST: Admin/Naics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var naics = await _context.Naics.FindAsync(id);
            _context.Naics.Remove(naics);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NaicsExists(Guid id)
        {
            return _context.Naics.Any(e => e.Id == id);
        }
    }
}
