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

namespace Vue2Spa.Areas.Portal.Controllers.API
{
    [Authorize(Roles = "Partner,Administrator")]
    [Route("/portal/api/[controller]")]
    [ApiController]
    public class IndustriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IndustriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Industries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Industry>>> GetIndustries()
        {
            return await _context.Industries.ToListAsync();
        }

        // GET: api/Industries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Industry>> GetIndustry(Guid id)
        {
            var industry = await _context.Industries.FindAsync(id);

            if (industry == null)
            {
                return NotFound();
            }

            return industry;
        }

        // PUT: api/Industries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIndustry(Guid id, Industry industry)
        {
            if (id != industry.Id)
            {
                return BadRequest();
            }

            _context.Entry(industry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndustryExists(id))
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

        // POST: api/Industries
        [HttpPost]
        public async Task<ActionResult<Industry>> PostIndustry(Industry industry)
        {
            _context.Industries.Add(industry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIndustry", new { id = industry.Id }, industry);
        }

        // DELETE: api/Industries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Industry>> DeleteIndustry(Guid id)
        {
            var industry = await _context.Industries.FindAsync(id);
            if (industry == null)
            {
                return NotFound();
            }

            _context.Industries.Remove(industry);
            await _context.SaveChangesAsync();

            return industry;
        }

        private bool IndustryExists(Guid id)
        {
            return _context.Industries.Any(e => e.Id == id);
        }
    }
}
