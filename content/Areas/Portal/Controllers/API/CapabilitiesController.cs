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
    public class CapabilitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CapabilitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        // GET: api/Capabilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Capability>>> GetCapabilities()
        {
            return await _context.Capabilities.ToListAsync();
        }

        // GET: api/Capabilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Capability>> GetCapability(Guid id)
        {
            var capability = await _context.Capabilities.FindAsync(id);

            if (capability == null)
            {
                return NotFound();
            }

            return capability;
        }

        // PUT: api/Capabilities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCapability(Guid id, Capability capability)
        {
            if (id != capability.Id)
            {
                return BadRequest();
            }

            _context.Entry(capability).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CapabilityExists(id))
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

        // POST: api/Capabilities
        [HttpPost]
        public async Task<ActionResult<Capability>> PostCapability(Capability capability)
        {
            _context.Capabilities.Add(capability);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCapability", new { id = capability.Id }, capability);
        }

        // DELETE: api/Capabilities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Capability>> DeleteCapability(Guid id)
        {
            var capability = await _context.Capabilities.FindAsync(id);
            if (capability == null)
            {
                return NotFound();
            }

            _context.Capabilities.Remove(capability);
            await _context.SaveChangesAsync();

            return capability;
        }

        private bool CapabilityExists(Guid id)
        {
            return _context.Capabilities.Any(e => e.Id == id);
        }
    }
}
