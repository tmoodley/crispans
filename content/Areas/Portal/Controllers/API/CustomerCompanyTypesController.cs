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
    public class CustomerCompanyTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerCompanyTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerCompanyTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerCompanyType>>> GetCustomerCompanyType()
        {
            return await _context.CustomerCompanyType.ToListAsync();
        }

        // GET: api/CustomerCompanyTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerCompanyType>> GetCustomerCompanyType(string id)
        {
            var customerCompanyType = await _context.CustomerCompanyType.FindAsync(id);

            if (customerCompanyType == null)
            {
                return NotFound();
            }

            return customerCompanyType;
        }

        // PUT: api/CustomerCompanyTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerCompanyType(string id, CustomerCompanyType customerCompanyType)
        {
            if (id != customerCompanyType.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customerCompanyType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerCompanyTypeExists(id))
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

        // POST: api/CustomerCompanyTypes
        [HttpPost]
        public async Task<ActionResult<CustomerCompanyType>> PostCustomerCompanyType(CustomerCompanyType customerCompanyType)
        {
            _context.CustomerCompanyType.Add(customerCompanyType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerCompanyTypeExists(customerCompanyType.CustomerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerCompanyType", new { id = customerCompanyType.CustomerId }, customerCompanyType);
        } 

        [HttpDelete()]
        public async Task<ActionResult<CustomerCompanyType>> DeleteCustomerCompanyType([FromQuery] string customerId, [FromQuery] Guid companyTypeId)
        {
            var customerCategory = await _context.CustomerCompanyType.Where(x => x.CustomerId == customerId && x.CompanyTypeId == companyTypeId).FirstOrDefaultAsync().ConfigureAwait(false);
            if (customerCategory == null)
            {
                return NotFound();
            }

            _context.CustomerCompanyType.Remove(customerCategory);
            await _context.SaveChangesAsync();

            return customerCategory;
        }

        private bool CustomerCompanyTypeExists(string id)
        {
            return _context.CustomerCompanyType.Any(e => e.CustomerId == id);
        }
    }
}
