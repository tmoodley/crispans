using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;
using Vue2Spa.Areas.Bidder.Models;
using Microsoft.AspNetCore.Authorization;

namespace Vue2Spa.Areas.Portal.Controllers.API
{
    [Route("/portal/api/[controller]")]
    //[Authorize(Roles = "Partner,Administrator")]
    [Area("Portal")]
    [ApiController]
    public class POBidsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public POBidsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/POBids
        [HttpGet]
        public async Task<ActionResult<IEnumerable<POBid>>> GetPOBids()
        {
            return await _context.POBids.ToListAsync();
        }

        // GET: api/POBids/5
        [HttpGet("{poid}/{bidderid}")]
        public async Task<ActionResult<POBid>> GetPOBid(Guid poid,Guid bidderid)
        {
            var pOBid = await _context.POBids.Include(a=>a.PurchaseOrder).ThenInclude(b=>b.PurchaseOrderQuestions).ThenInclude(c=>c.Question) .Where(a=>((a.PurchaseOrderId == poid)&&(a.BidderId == bidderid)))
                .FirstOrDefaultAsync().ConfigureAwait(false);

            if (pOBid == null)
            {
                return NotFound();
            }

            return pOBid;
        }

        // PUT: api/POBids/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPOBid(Guid id, POBid pOBid)
        {
            if (id != pOBid.PurchaseOrderId)
            {
                return BadRequest();
            }

            _context.Entry(pOBid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!POBidExists(id))
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

        // POST: api/POBids
        [HttpPost]
        public async Task<ActionResult<POBid>> PostPOBid(POBid pOBid)
        {
            _context.POBids.Add(pOBid);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (POBidExists(pOBid.PurchaseOrderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPOBid", new { id = pOBid.PurchaseOrderId }, pOBid);
        }

        // DELETE: api/POBids/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<POBid>> DeletePOBid(Guid id)
        {
            var pOBid = await _context.POBids.FindAsync(id);
            if (pOBid == null)
            {
                return NotFound();
            }

            _context.POBids.Remove(pOBid);
            await _context.SaveChangesAsync();

            return pOBid;
        }

        private bool POBidExists(Guid id)
        {
            return _context.POBids.Any(e => e.PurchaseOrderId == id);
        }
    }
}
