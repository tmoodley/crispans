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
    public class CustomerFileTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerFileTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerFileTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerFileType>>> GetCustomerFileType()
        {
            return await _context.CustomerFileType.ToListAsync();
        }

        // GET: api/CustomerFileTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerFileType>> GetCustomerFileType(string id)
        {
            var customerFileType = await _context.CustomerFileType.FindAsync(id);

            if (customerFileType == null)
            {
                return NotFound();
            }

            return customerFileType;
        }

        // PUT: api/CustomerFileTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerFileType(string id, CustomerFileType customerFileType)
        {
            if (id != customerFileType.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customerFileType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerFileTypeExists(id))
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

        // POST: api/CustomerFileTypes
        [HttpPost]
        public async Task<ActionResult<CustomerFileType>> PostCustomerFileType(CustomerFileType customerFileType)
        {
            _context.CustomerFileType.Add(customerFileType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerFileTypeExists(customerFileType.CustomerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerFileType", new { id = customerFileType.CustomerId }, customerFileType);
        }

        // DELETE: api/CustomerFileTypes/5
        [HttpDelete()]
        public async Task<ActionResult<CustomerFileType>> DeleteCustomerFileType([FromQuery] string customerId, [FromQuery] Guid fileTypeId)
        {
            var customerCategory = await _context.CustomerFileType.Where(x => x.CustomerId == customerId && x.FileTypeId == fileTypeId).FirstOrDefaultAsync().ConfigureAwait(false);
            if (customerCategory == null)
            {
                return NotFound();
            }

            _context.CustomerFileType.Remove(customerCategory);
            await _context.SaveChangesAsync();

            return customerCategory;
        }

        private bool CustomerFileTypeExists(string id)
        {
            return _context.CustomerFileType.Any(e => e.CustomerId == id);
        }
    }
}
