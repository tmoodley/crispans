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
    public class CustomerMachinesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerMachinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerMachines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerMachine>>> GetCustomerMachine()
        {
            return await _context.CustomerMachine.ToListAsync();
        }

        // GET: api/CustomerMachines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerMachine>> GetCustomerMachine(string id)
        {
            var customerMachine = await _context.CustomerMachine.FindAsync(id);

            if (customerMachine == null)
            {
                return NotFound();
            }

            return customerMachine;
        }

        // PUT: api/CustomerMachines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerMachine(string id, CustomerMachine customerMachine)
        {
            if (id != customerMachine.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customerMachine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerMachineExists(id))
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

        // POST: api/CustomerMachines
        [HttpPost]
        public async Task<ActionResult<CustomerMachine>> PostCustomerMachine(CustomerMachine customerMachine)
        {
            _context.CustomerMachine.Add(customerMachine);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerMachineExists(customerMachine.CustomerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerMachine", new { id = customerMachine.CustomerId }, customerMachine);
        }

        // DELETE: api/CustomerMachines/5 

        [HttpDelete()]
        public async Task<ActionResult<CustomerMachine>> DeleteCustomerMachine([FromQuery] string customerId, [FromQuery] Guid machineId)
        {
            var customerCategory = await _context.CustomerMachine.Where(x => x.CustomerId == customerId && x.MachineId == machineId).FirstOrDefaultAsync().ConfigureAwait(false);
            if (customerCategory == null)
            {
                return NotFound();
            }

            _context.CustomerMachine.Remove(customerCategory);
            await _context.SaveChangesAsync();

            return customerCategory;
        }

        private bool CustomerMachineExists(string id)
        {
            return _context.CustomerMachine.Any(e => e.CustomerId == id);
        }
    }
}
