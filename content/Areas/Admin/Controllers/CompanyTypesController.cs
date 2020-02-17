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
    public class CompanyTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/CompanyTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyTypes.ToListAsync());
        }

        // GET: Admin/CompanyTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyType = await _context.CompanyTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyType == null)
            {
                return NotFound();
            }

            return View(companyType);
        }

        // GET: Admin/CompanyTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CompanyTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DisplayOrder")] CompanyType companyType)
        {
            if (ModelState.IsValid)
            {
                companyType.Id = Guid.NewGuid();
                _context.Add(companyType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyType);
        }

        // GET: Admin/CompanyTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyType = await _context.CompanyTypes.FindAsync(id);
            if (companyType == null)
            {
                return NotFound();
            }
            return View(companyType);
        }

        // POST: Admin/CompanyTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,DisplayOrder")] CompanyType companyType)
        {
            if (id != companyType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyTypeExists(companyType.Id))
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
            return View(companyType);
        }

        // GET: Admin/CompanyTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyType = await _context.CompanyTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyType == null)
            {
                return NotFound();
            }

            return View(companyType);
        }

        // POST: Admin/CompanyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var companyType = await _context.CompanyTypes.FindAsync(id);
            _context.CompanyTypes.Remove(companyType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyTypeExists(Guid id)
        {
            return _context.CompanyTypes.Any(e => e.Id == id);
        }
    }
}
