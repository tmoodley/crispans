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
    public class JobMaterialsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobMaterialsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/JobMaterials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobMaterial>>> GetJobMaterial()
        {
            return await _context.JobMaterial.ToListAsync();
        }

        // GET: api/JobMaterials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobMaterial>> GetJobMaterial(string id)
        {
            var jobMaterial = await _context.JobMaterial.FindAsync(id);

            if (jobMaterial == null)
            {
                return NotFound();
            }

            return jobMaterial;
        }

        // PUT: api/JobMaterials/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobMaterial(string id, JobMaterial jobMaterial)
        {
            if (id != jobMaterial.JobId)
            {
                return BadRequest();
            }

            _context.Entry(jobMaterial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobMaterialExists(id))
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

        // POST: api/JobMaterials
        [HttpPost]
        public async Task<ActionResult<JobMaterial>> PostJobMaterial(JobMaterial jobMaterial)
        {
            _context.JobMaterial.Add(jobMaterial);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobMaterialExists(jobMaterial.JobId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJobMaterial", new { id = jobMaterial.JobId }, jobMaterial);
        }

        // DELETE: api/JobMaterials/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobMaterial>> DeleteJobMaterial(string id)
        {
            var jobMaterial = await _context.JobMaterial.FindAsync(id);
            if (jobMaterial == null)
            {
                return NotFound();
            }

            _context.JobMaterial.Remove(jobMaterial);
            await _context.SaveChangesAsync();

            return jobMaterial;
        }

        private bool JobMaterialExists(string id)
        {
            return _context.JobMaterial.Any(e => e.JobId == id);
        }
    }
}
