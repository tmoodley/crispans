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
    public class CustomerIndustriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerIndustriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerIndustries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerIndustry>>> GetCustomerIndustry()
        {
            return await _context.CustomerIndustry.ToListAsync();
        }

        // GET: api/CustomerIndustries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerIndustry>> GetCustomerIndustry(string id)
        {
            var customerIndustry = await _context.CustomerIndustry.FindAsync(id);

            if (customerIndustry == null)
            {
                return NotFound();
            }

            return customerIndustry;
        }

        // PUT: api/CustomerIndustries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerIndustry(string id, CustomerIndustry customerIndustry)
        {
            if (id != customerIndustry.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customerIndustry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerIndustryExists(id))
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

        // POST: api/CustomerIndustries
        [HttpPost]
        public async Task<ActionResult<CustomerIndustry>> PostCustomerIndustry(CustomerIndustry customerIndustry)
        {
            _context.CustomerIndustry.Add(customerIndustry);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerIndustryExists(customerIndustry.CustomerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerIndustry", new { id = customerIndustry.CustomerId }, customerIndustry);
        }

        // DELETE: api/CustomerIndustries/5 

        [HttpDelete()]
        public async Task<ActionResult<CustomerIndustry>> DeleteCustomerIndustry([FromQuery] string customerId, [FromQuery] Guid industryId)
        {
            var customerCategory = await _context.CustomerIndustry.Where(x => x.CustomerId == customerId && x.IndustryId == industryId).FirstOrDefaultAsync().ConfigureAwait(false);
            if (customerCategory == null)
            {
                return NotFound();
            }

            _context.CustomerIndustry.Remove(customerCategory);
            await _context.SaveChangesAsync();

            return customerCategory;
        }

        private bool CustomerIndustryExists(string id)
        {
            return _context.CustomerIndustry.Any(e => e.CustomerId == id);
        }
    }
}
