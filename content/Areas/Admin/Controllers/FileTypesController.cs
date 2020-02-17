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
    public class FileTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FileTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/FileTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FileTypes.ToListAsync());
        }

        // GET: Admin/FileTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileType = await _context.FileTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fileType == null)
            {
                return NotFound();
            }

            return View(fileType);
        }

        // GET: Admin/FileTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/FileTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DisplayOrder")] FileType fileType)
        {
            if (ModelState.IsValid)
            {
                fileType.Id = Guid.NewGuid();
                _context.Add(fileType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fileType);
        }

        // GET: Admin/FileTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileType = await _context.FileTypes.FindAsync(id);
            if (fileType == null)
            {
                return NotFound();
            }
            return View(fileType);
        }

        // POST: Admin/FileTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,DisplayOrder")] FileType fileType)
        {
            if (id != fileType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fileType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FileTypeExists(fileType.Id))
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
            return View(fileType);
        }

        // GET: Admin/FileTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileType = await _context.FileTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fileType == null)
            {
                return NotFound();
            }

            return View(fileType);
        }

        // POST: Admin/FileTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fileType = await _context.FileTypes.FindAsync(id);
            _context.FileTypes.Remove(fileType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FileTypeExists(Guid id)
        {
            return _context.FileTypes.Any(e => e.Id == id);
        }
    }
}
