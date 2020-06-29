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
    public class CustomerMaterialsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerMaterialsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerMaterials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerMaterial>>> GetCustomerMaterial()
        {
            return await _context.CustomerMaterial.ToListAsync();
        }

        // GET: api/CustomerMaterials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerMaterial>> GetCustomerMaterial(string id)
        {
            var customerMaterial = await _context.CustomerMaterial.FindAsync(id);

            if (customerMaterial == null)
            {
                return NotFound();
            }

            return customerMaterial;
        }

        // PUT: api/CustomerMaterials/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerMaterial(string id, CustomerMaterial customerMaterial)
        {
            if (id != customerMaterial.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customerMaterial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerMaterialExists(id))
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

        [AllowAnonymous]
        // POST: api/CustomerMaterials
        [HttpPost]
        public async Task<ActionResult<CustomerMaterial>> PostCustomerMaterial(CustomerMaterial customerMaterial)
        {
            _context.CustomerMaterial.Add(customerMaterial);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerMaterialExists(customerMaterial.CustomerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerMaterial", new { id = customerMaterial.CustomerId }, customerMaterial);
        }

        // DELETE: api/CustomerMaterials/5 
        [HttpDelete()]
        public async Task<ActionResult<CustomerMaterial>> DeleteCustomerMaterial([FromQuery] string customerId, [FromQuery] Guid materialId)
        {
            var customerCategory = await _context.CustomerMaterial.Where(x => x.CustomerId == customerId && x.MaterialId == materialId).FirstOrDefaultAsync().ConfigureAwait(false);
            if (customerCategory == null)
            {
                return NotFound();
            }

            _context.CustomerMaterial.Remove(customerCategory);
            await _context.SaveChangesAsync();

            return customerCategory;
        }

        private bool CustomerMaterialExists(string id)
        {
            return _context.CustomerMaterial.Any(e => e.CustomerId == id);
        }
    }
}
