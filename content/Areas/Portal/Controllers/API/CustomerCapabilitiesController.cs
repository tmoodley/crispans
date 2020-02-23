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
    public class CustomerCapabilitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerCapabilitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerCapabilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerCapability>>> GetCustomerCapability()
        {
            return await _context.CustomerCapability.ToListAsync();
        }

        // GET: api/CustomerCapabilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerCapability>> GetCustomerCapability(string id)
        {
            var customerCapability = await _context.CustomerCapability.FindAsync(id);

            if (customerCapability == null)
            {
                return NotFound();
            }

            return customerCapability;
        }

        // PUT: api/CustomerCapabilities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerCapability(string id, CustomerCapability customerCapability)
        {
            if (id != customerCapability.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customerCapability).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerCapabilityExists(id))
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

        // POST: api/CustomerCapabilities
        [HttpPost]
        public async Task<ActionResult<CustomerCapability>> PostCustomerCapability(CustomerCapability customerCapability)
        {
            _context.CustomerCapability.Add(customerCapability);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerCapabilityExists(customerCapability.CustomerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerCapability", new { id = customerCapability.CustomerId }, customerCapability);
        }
         
        [HttpDelete()]
        public async Task<ActionResult<CustomerCapability>> DeleteCustomerCapability([FromQuery] string customerId, [FromQuery] Guid capabilityId)
        {
            var customerCategory = await _context.CustomerCapability.Where(x => x.CustomerId == customerId && x.CapabilityId == capabilityId).FirstOrDefaultAsync().ConfigureAwait(false);
            if (customerCategory == null)
            {
                return NotFound();
            }

            _context.CustomerCapability.Remove(customerCategory);
            await _context.SaveChangesAsync();

            return customerCategory;
        }
        private bool CustomerCapabilityExists(string id)
        {
            return _context.CustomerCapability.Any(e => e.CustomerId == id);
        }
    }
}
