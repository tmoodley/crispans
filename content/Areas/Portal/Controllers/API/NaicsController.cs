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
    public class NaicsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NaicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Naics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Naics>>> GetNaics()
        {
            return await _context.Naics.ToListAsync();
        }

        // GET: api/Naics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Naics>> GetNaics(Guid id)
        {
            var naics = await _context.Naics.FindAsync(id);

            if (naics == null)
            {
                return NotFound();
            }

            return naics;
        }

        // PUT: api/Naics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNaics(Guid id, Naics naics)
        {
            if (id != naics.Id)
            {
                return BadRequest();
            }

            _context.Entry(naics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NaicsExists(id))
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

        // POST: api/Naics
        [HttpPost]
        public async Task<ActionResult<Naics>> PostNaics(Naics naics)
        {
            _context.Naics.Add(naics);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNaics", new { id = naics.Id }, naics);
        }

        // DELETE: api/Naics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Naics>> DeleteNaics(Guid id)
        {
            var naics = await _context.Naics.FindAsync(id);
            if (naics == null)
            {
                return NotFound();
            }

            _context.Naics.Remove(naics);
            await _context.SaveChangesAsync();

            return naics;
        }

        private bool NaicsExists(Guid id)
        {
            return _context.Naics.Any(e => e.Id == id);
        }
    }
}
