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
    public class JobCompanyTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobCompanyTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/JobCompanyTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobCompanyType>>> GetJobCompanyType()
        {
            return await _context.JobCompanyType.ToListAsync();
        }

        // GET: api/JobCompanyTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobCompanyType>> GetJobCompanyType(string id)
        {
            var jobCompanyType = await _context.JobCompanyType.FindAsync(id);

            if (jobCompanyType == null)
            {
                return NotFound();
            }

            return jobCompanyType;
        }

        // PUT: api/JobCompanyTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobCompanyType(string id, JobCompanyType jobCompanyType)
        {
            if (id != jobCompanyType.JobId)
            {
                return BadRequest();
            }

            _context.Entry(jobCompanyType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobCompanyTypeExists(id))
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

        // POST: api/JobCompanyTypes
        [HttpPost]
        public async Task<ActionResult<JobCompanyType>> PostJobCompanyType(JobCompanyType jobCompanyType)
        {
            _context.JobCompanyType.Add(jobCompanyType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobCompanyTypeExists(jobCompanyType.JobId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJobCompanyType", new { id = jobCompanyType.JobId }, jobCompanyType);
        }

        // DELETE: api/JobCompanyTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobCompanyType>> DeleteJobCompanyType(string id)
        {
            var jobCompanyType = await _context.JobCompanyType.FindAsync(id);
            if (jobCompanyType == null)
            {
                return NotFound();
            }

            _context.JobCompanyType.Remove(jobCompanyType);
            await _context.SaveChangesAsync();

            return jobCompanyType;
        }

        private bool JobCompanyTypeExists(string id)
        {
            return _context.JobCompanyType.Any(e => e.JobId == id);
        }
    }
}
