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
using Vue2Spa.Areas.Portal.Models;

namespace Vue2Spa.Areas.Portal.Controllers.API
{
    [Authorize]
    [Route("/portal/api/[controller]")]
    [ApiController]
    public class JobCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobCategory>>> GetJobCategory()
        {
            return await _context.JobCategory.ToListAsync();
        }

        // GET: api/CustomerCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<JobCategory>>> GetJobCategory(string id)
        {
            var JobCategory = await _context.JobCategory.Where(x => x.JobId == id).ToListAsync();

            if (JobCategory == null)
            {
                return NotFound();
            }

            return JobCategory;
        }

        // PUT: api/CustomerCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobCategory(string id, JobCategory JobCategory)
        {
            if (id != JobCategory.JobId)
            {
                return BadRequest();
            }

            _context.Entry(JobCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobCategoryExists(id))
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
        public async Task<ActionResult<JobCategory>> PostJobCategory(JobCategory JobCategory)
        {
            _context.JobCategory.Add(JobCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobCategoryExists(JobCategory.JobId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJobCategory", new { id = JobCategory.JobId }, JobCategory);
        }

        // DELETE: api/CustomerCategories/5
        [HttpDelete()]
        public async Task<ActionResult<JobCategory>> DeleteJobCategory([FromQuery] string JobId, [FromQuery] Guid categoryId)
        {
            var JobCategory = await _context.JobCategory.Where(x => x.JobId == JobId && x.CategoryId == categoryId).FirstOrDefaultAsync().ConfigureAwait(false);
            if (JobCategory == null)
            {
                return NotFound();
            }

            _context.JobCategory.Remove(JobCategory);
            await _context.SaveChangesAsync();

            return JobCategory;
        }

        private bool JobCategoryExists(string id)
        {
            return _context.JobCategory.Any(e => e.JobId == id);
        }
    }
}
