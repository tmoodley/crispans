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
    public class CustomerCertificationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerCertificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerCertifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerCertification>>> GetCustomerCertification()
        {
            return await _context.CustomerCertification.ToListAsync();
        }

        // GET: api/CustomerCertifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerCertification>> GetCustomerCertification(string id)
        {
            var customerCertification = await _context.CustomerCertification.FindAsync(id);

            if (customerCertification == null)
            {
                return NotFound();
            }

            return customerCertification;
        }

        // PUT: api/CustomerCertifications/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerCertification(string id, CustomerCertification customerCertification)
        {
            if (id != customerCertification.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customerCertification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerCertificationExists(id))
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

        // POST: api/CustomerCertifications
        [HttpPost]
        public async Task<ActionResult<CustomerCertification>> PostCustomerCertification(CustomerCertification customerCertification)
        {
            _context.CustomerCertification.Add(customerCertification);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerCertificationExists(customerCertification.CustomerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerCertification", new { id = customerCertification.CustomerId }, customerCertification);
        }

        // DELETE: api/CustomerCertifications/5
        [HttpDelete()]
        public async Task<ActionResult<CustomerCertification>> DeleteCustomerCertification([FromQuery] string customerId, [FromQuery] Guid certificationId)
        {
            var customerCategory = await _context.CustomerCertification.Where(x => x.CustomerId == customerId && x.CertificationId == certificationId).FirstOrDefaultAsync().ConfigureAwait(false);
            if (customerCategory == null)
            {
                return NotFound();
            }

            _context.CustomerCertification.Remove(customerCategory);
            await _context.SaveChangesAsync();

            return customerCategory;
        }

        private bool CustomerCertificationExists(string id)
        {
            return _context.CustomerCertification.Any(e => e.CustomerId == id);
        }
    }
}
