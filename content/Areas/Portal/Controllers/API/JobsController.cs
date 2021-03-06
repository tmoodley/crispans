using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vue2Spa.Areas.Portal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;
using Microsoft.AspNetCore.Authorization;

namespace Vue2Spa.Areas.Portal.Controllers.API
{
    [Authorize] 
    [Route("/portal/api/[controller]/[action]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobs(string id)
        {
            _context.Database.SetCommandTimeout(300);
            return await _context.Jobs.Where(x => x.CustomerId == id)
              
                .ToListAsync().ConfigureAwait(false);//
        }

        // GET: api/Jobs/5
        [HttpGet]
        public async Task<ActionResult<Job>> GetJob(string id)
        {
            var job = await _context.Jobs
                  .Include(x => x.JobFileTypes)
                .Include(x => x.JobCapabilities)
                .Include(x => x.JobCertifications)
                .Include(x => x.JobCompanyTypes)
                .Include(x => x.JobCategories)
                .Include(x => x.JobIndustries)
                .Include(x => x.JobMachines)
                .Include(x => x.JobMaterials)
                .Include(x => x.JobNaics)
                .Include(x => x.JobQuestions)
                .FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }

        // PUT: api/Jobs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(string id, Job job)
        {
            if (id != job.Id)
            {
                return BadRequest();
            }

            _context.Entry(job).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
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

        // POST: api/Jobs
        [HttpPost]
        public async Task<ActionResult<Job>> PostJob(Job job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJob", new { id = job.Id }, job);
        }

        // DELETE: api/Jobs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Job>> DeleteJob(string id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();

            return job;
        }

        private bool JobExists(string id)
        {
            return _context.Jobs.Any(e => e.Id == id);
        }
    }
}
