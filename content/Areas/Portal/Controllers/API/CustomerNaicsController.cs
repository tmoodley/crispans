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
    public class CustomerNaicsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerNaicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerNaics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerNaics>>> GetCustomerNaics()
        {
            return await _context.CustomerNaics.ToListAsync();
        }

        // GET: api/CustomerNaics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerNaics>> GetCustomerNaics(string id)
        {
            var customerNaics = await _context.CustomerNaics.FindAsync(id);

            if (customerNaics == null)
            {
                return NotFound();
            }

            return customerNaics;
        }

        // PUT: api/CustomerNaics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerNaics(string id, CustomerNaics customerNaics)
        {
            if (id != customerNaics.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customerNaics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerNaicsExists(id))
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

        // POST: api/CustomerNaics
        [HttpPost]
        public async Task<ActionResult<CustomerNaics>> PostCustomerNaics(CustomerNaics customerNaics)
        {
            _context.CustomerNaics.Add(customerNaics);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerNaicsExists(customerNaics.CustomerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerNaics", new { id = customerNaics.CustomerId }, customerNaics);
        }

        // DELETE: api/CustomerNaics/5 

        [HttpDelete()]
        public async Task<ActionResult<CustomerNaics>> DeleteCustomerNaics([FromQuery] string customerId, [FromQuery] Guid naicsId)
        {
            var customerCategory = await _context.CustomerNaics.Where(x => x.CustomerId == customerId && x.NaicsId == naicsId).FirstOrDefaultAsync().ConfigureAwait(false);
            if (customerCategory == null)
            {
                return NotFound();
            }

            _context.CustomerNaics.Remove(customerCategory);
            await _context.SaveChangesAsync();

            return customerCategory;
        }

        private bool CustomerNaicsExists(string id)
        {
            return _context.CustomerNaics.Any(e => e.CustomerId == id);
        }
    }
}
