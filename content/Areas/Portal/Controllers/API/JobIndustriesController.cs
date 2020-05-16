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
    public class JobIndustriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobIndustriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/JobIndustries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobIndustry>>> GetJobIndustry()
        {
            return await _context.JobIndustry.ToListAsync();
        }

        // GET: api/JobIndustries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobIndustry>> GetJobIndustry(string id)
        {
            var jobIndustry = await _context.JobIndustry.FindAsync(id);

            if (jobIndustry == null)
            {
                return NotFound();
            }

            return jobIndustry;
        }

        // PUT: api/JobIndustries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobIndustry(string id, JobIndustry jobIndustry)
        {
            if (id != jobIndustry.JobId)
            {
                return BadRequest();
            }

            _context.Entry(jobIndustry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobIndustryExists(id))
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

        // POST: api/JobIndustries
        [HttpPost]
        public async Task<ActionResult<JobIndustry>> PostJobIndustry(JobIndustry jobIndustry)
        {
            _context.JobIndustry.Add(jobIndustry);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobIndustryExists(jobIndustry.JobId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJobIndustry", new { id = jobIndustry.JobId }, jobIndustry);
        }

        // DELETE: api/JobIndustries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobIndustry>> DeleteJobIndustry(string id)
        {
            var jobIndustry = await _context.JobIndustry.FindAsync(id);
            if (jobIndustry == null)
            {
                return NotFound();
            }

            _context.JobIndustry.Remove(jobIndustry);
            await _context.SaveChangesAsync();

            return jobIndustry;
        }

        private bool JobIndustryExists(string id)
        {
            return _context.JobIndustry.Any(e => e.JobId == id);
        }
    }
}
