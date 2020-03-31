using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;
using Vue2Spa.Models;
using Microsoft.AspNetCore.Authorization;

namespace Vue2Spa.Controllers.api
{
    [Authorize(Roles = "Bidder,Administrator")]
    [Route("/portal/api/[controller]")]
    [ApiController]
    public class BiddersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BiddersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Bidders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bidder>>> GetBidders()
        {
            return await _context.Bidders.ToListAsync();
        }

        // GET: api/Bidders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bidder>> GetBidder(Guid id)
        {
            var bidder = await _context.Bidders.FindAsync(id);

            if (bidder == null)
            {
                return NotFound();
            }

            return bidder;
        }

        // PUT: api/Bidders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBidder(Guid id, Bidder bidder)
        {
            if (id != bidder.Id)
            {
                return BadRequest();
            }

            _context.Entry(bidder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BidderExists(id))
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

        // POST: api/Bidders
        [HttpPost]
        public async Task<ActionResult<Bidder>> PostBidder(Bidder bidder)
        {
            _context.Bidders.Add(bidder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBidder", new { id = bidder.Id }, bidder);
        }

        // DELETE: api/Bidders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bidder>> DeleteBidder(Guid id)
        {
            var bidder = await _context.Bidders.FindAsync(id);
            if (bidder == null)
            {
                return NotFound();
            }

            _context.Bidders.Remove(bidder);
            await _context.SaveChangesAsync();

            return bidder;
        }

        private bool BidderExists(Guid id)
        {
            return _context.Bidders.Any(e => e.Id == id);
        }
    }
}
