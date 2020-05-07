using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;
using HelpingHands.Models;

namespace Vue2Spa.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PurchaseOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseOrder>>> GetPurchaseOrder()
        {
            return await _context.PurchaseOrder.ToListAsync();
        }

        // GET: api/PurchaseOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseOrder>> GetPurchaseOrder(Guid id)
        {
            var purchaseOrder = await _context.PurchaseOrder.Include(x => x.PurchaseOrderItems).Include(a=>a.Bids).ThenInclude(s=>s.Bidder).Include(a=>a.PurchaseOrderQuestions).ThenInclude(a=>a.Question).ThenInclude(a=>a.Answers).FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);

            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return purchaseOrder;
        }

        // PUT: api/PurchaseOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseOrder(Guid id, PurchaseOrder purchaseOrder)
        {
            if (id != purchaseOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(purchaseOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseOrderExists(id))
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

        // POST: api/PurchaseOrders
        [HttpPost]
        public async Task<ActionResult<PurchaseOrder>> PostPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            _context.PurchaseOrder.Add(purchaseOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchaseOrder", new { id = purchaseOrder.Id }, purchaseOrder);
        }

        // DELETE: api/PurchaseOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PurchaseOrder>> DeletePurchaseOrder(Guid id)
        {
            var purchaseOrder = await _context.PurchaseOrder.FindAsync(id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            _context.PurchaseOrder.Remove(purchaseOrder);
            await _context.SaveChangesAsync();

            return purchaseOrder;
        }

        private bool PurchaseOrderExists(Guid id)
        {
            return _context.PurchaseOrder.Any(e => e.Id == id);
        }
    }
}
