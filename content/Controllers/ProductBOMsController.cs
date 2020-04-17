using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;
using Vue2Spa.Models;

namespace Vue2Spa.Controllers
{
    public class ProductBOMsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductBOMsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductBOMs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductBOM.Include(p => p.Products);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductBOMs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productBOM = await _context.ProductBOM
                .Include(p => p.Products)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productBOM == null)
            {
                return NotFound();
            }

            return View(productBOM);
        }

        // GET: ProductBOMs/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: ProductBOMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Line,BOMQty,ProductId,BOMType,Created,CreatedBy,Updated,UpdatedBy")] ProductBOM productBOM)
        {
            if (ModelState.IsValid)
            {
                productBOM.Id = Guid.NewGuid();
                _context.Add(productBOM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productBOM.ProductId);
            return View(productBOM);
        }

        // GET: ProductBOMs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productBOM = await _context.ProductBOM.FindAsync(id);
            if (productBOM == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productBOM.ProductId);
            return View(productBOM);
        }

        // POST: ProductBOMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,Line,BOMQty,ProductId,BOMType,Created,CreatedBy,Updated,UpdatedBy")] ProductBOM productBOM)
        {
            if (id != productBOM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productBOM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductBOMExists(productBOM.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productBOM.ProductId);
            return View(productBOM);
        }

        // GET: ProductBOMs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productBOM = await _context.ProductBOM
                .Include(p => p.Products)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productBOM == null)
            {
                return NotFound();
            }

            return View(productBOM);
        }

        // POST: ProductBOMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var productBOM = await _context.ProductBOM.FindAsync(id);
            _context.ProductBOM.Remove(productBOM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductBOMExists(Guid id)
        {
            return _context.ProductBOM.Any(e => e.Id == id);
        }
    }
}
