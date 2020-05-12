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
    public class JobNaicsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobNaicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/JobNaics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobNaics>>> GetJobNaics()
        {
            return await _context.JobNaics.ToListAsync();
        }

        // GET: api/JobNaics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobNaics>> GetJobNaics(string id)
        {
            var jobNaics = await _context.JobNaics.FindAsync(id);

            if (jobNaics == null)
            {
                return NotFound();
            }

            return jobNaics;
        }

        // PUT: api/JobNaics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobNaics(string id, JobNaics jobNaics)
        {
            if (id != jobNaics.JobId)
            {
                return BadRequest();
            }

            _context.Entry(jobNaics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobNaicsExists(id))
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

        // POST: api/JobNaics
        [HttpPost]
        public async Task<ActionResult<JobNaics>> PostJobNaics(JobNaics jobNaics)
        {
            _context.JobNaics.Add(jobNaics);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobNaicsExists(jobNaics.JobId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJobNaics", new { id = jobNaics.JobId }, jobNaics);
        }

        // DELETE: api/JobNaics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobNaics>> DeleteJobNaics(string id)
        {
            var jobNaics = await _context.JobNaics.FindAsync(id);
            if (jobNaics == null)
            {
                return NotFound();
            }

            _context.JobNaics.Remove(jobNaics);
            await _context.SaveChangesAsync();

            return jobNaics;
        }

        private bool JobNaicsExists(string id)
        {
            return _context.JobNaics.Any(e => e.JobId == id);
        }
    }
}
