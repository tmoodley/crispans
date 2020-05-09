using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;
using Vue2Spa.Areas.Portal.Models;
using Microsoft.AspNetCore.Authorization;

namespace Vue2Spa.Areas.Portal.Controllers.API
{
    [Authorize]
    [Route("/portal/api/[controller]")]
    [ApiController]
    public class PurchaseOrderCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PurchaseOrderCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseOrderCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseOrderCategory>>> GetPurchaseOrderCategory()
        {
            return await _context.PurchaseOrderCategory.ToListAsync();
        }

        // GET: api/PurchaseOrderCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseOrderCategory>> GetPurchaseOrderCategory(Guid id)
        {
            var purchaseOrderCategory = await _context.PurchaseOrderCategory.FindAsync(id);

            if (purchaseOrderCategory == null)
            {
                return NotFound();
            }

            return purchaseOrderCategory;
        }

        // PUT: api/PurchaseOrderCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseOrderCategory(Guid id, PurchaseOrderCategory purchaseOrderCategory)
        {
            if (id != purchaseOrderCategory.PurchaseOrderId)
            {
                return BadRequest();
            }

            _context.Entry(purchaseOrderCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseOrderCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PurchaseOrderCategories
        [HttpPost]
        public async Task<ActionResult<PurchaseOrderCategory>> PostPurchaseOrderCategory(PurchaseOrderCategory purchaseOrderCategory)
        {
            _context.PurchaseOrderCategory.Add(purchaseOrderCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PurchaseOrderCategoryExists(purchaseOrderCategory.PurchaseOrderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPurchaseOrderCategory", new { id = purchaseOrderCategory.PurchaseOrderId }, purchaseOrderCategory);
        }

        // DELETE: api/PurchaseOrderCategories/5
        [HttpDelete()]
        public async Task<ActionResult<PurchaseOrderCategory>> DeleteProductCategory([FromQuery] Guid PurchaseOrderId, [FromQuery] Guid CategoryId)
        {
            var ProductCategory = await _context.PurchaseOrderCategory.Where(x => x.PurchaseOrderId == PurchaseOrderId && x.CategoryId == CategoryId).FirstOrDefaultAsync().ConfigureAwait(false);
            if (ProductCategory == null)
            {
                return NotFound();
            }

            _context.PurchaseOrderCategory.Remove(ProductCategory);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return ProductCategory;
        }

        private bool PurchaseOrderCategoryExists(Guid id)
        {
            return _context.PurchaseOrderCategory.Any(e => e.PurchaseOrderId == id);
        }
    }
}
