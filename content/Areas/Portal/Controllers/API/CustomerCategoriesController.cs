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
    public class CustomerCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerCategory>>> GetCustomerCategory()
        {
            return await _context.CustomerCategory.ToListAsync();
        }

        // GET: api/CustomerCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<CustomerCategory>>> GetCustomerCategory(string id)
        {
            var customerCategory = await _context.CustomerCategory.Where(x => x.CustomerId == id).ToListAsync();

            if (customerCategory == null)
            {
                return NotFound();
            }

            return customerCategory;
        }

        // PUT: api/CustomerCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerCategory(string id, CustomerCategory customerCategory)
        {
            if (id != customerCategory.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customerCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerCategoryExists(id))
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

        // POST: api/CustomerCategories
        [HttpPost]
        public async Task<ActionResult<CustomerCategory>> PostCustomerCategory(CustomerCategory customerCategory)
        {
            _context.CustomerCategory.Add(customerCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerCategoryExists(customerCategory.CustomerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerCategory", new { id = customerCategory.CustomerId }, customerCategory);
        }

        // DELETE: api/CustomerCategories/5
        [HttpDelete()]
        public async Task<ActionResult<CustomerCategory>> DeleteCustomerCategory([FromQuery] string customerId, [FromQuery] Guid categoryId)
        {
            var customerCategory = await _context.CustomerCategory.Where(x => x.CustomerId == customerId && x.CategoryId == categoryId).FirstOrDefaultAsync().ConfigureAwait(false);
            if (customerCategory == null)
            {
                return NotFound();
            }

            _context.CustomerCategory.Remove(customerCategory);
            await _context.SaveChangesAsync();

            return customerCategory;
        }

        private bool CustomerCategoryExists(string id)
        {
            return _context.CustomerCategory.Any(e => e.CustomerId == id);
        }
    }
}
