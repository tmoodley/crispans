using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;
using Vue2Spa.Areas.Portal.Models;
using Microsoft.AspNetCore.Authorization;

namespace Vue2Spa.Areas.Portal.Controllers.API
{
    [Authorize(Roles = "Partner, Supplier, Broker, Buyer")]
    [Route("/portal/api/[controller]")]
    [ApiController]
    public class JobMachinesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobMachinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/JobMachines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobMachine>>> GetJobMachine()
        {
            return await _context.JobMachine.ToListAsync();
        }

        // GET: api/JobMachines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobMachine>> GetJobMachine(string id)
        {
            var jobMachine = await _context.JobMachine.FindAsync(id);

            if (jobMachine == null)
            {
                return NotFound();
            }

            return jobMachine;
        }

        // PUT: api/JobMachines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobMachine(string id, JobMachine jobMachine)
        {
            if (id != jobMachine.JobId)
            {
                return BadRequest();
            }

            _context.Entry(jobMachine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobMachineExists(id))
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

        // POST: api/JobMachines
        [HttpPost]
        public async Task<ActionResult<JobMachine>> PostJobMachine(JobMachine jobMachine)
        {
            _context.JobMachine.Add(jobMachine);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobMachineExists(jobMachine.JobId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJobMachine", new { id = jobMachine.JobId }, jobMachine);
        }

        // DELETE: api/JobMachines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobMachine>> DeleteJobMachine(string id)
        {
            var jobMachine = await _context.JobMachine.FindAsync(id);
            if (jobMachine == null)
            {
                return NotFound();
            }

            _context.JobMachine.Remove(jobMachine);
            await _context.SaveChangesAsync();

            return jobMachine;
        }

        private bool JobMachineExists(string id)
        {
            return _context.JobMachine.Any(e => e.JobId == id);
        }
    }
}
