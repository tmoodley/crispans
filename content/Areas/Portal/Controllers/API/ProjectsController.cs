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
    public class ProjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects(string id)
        {
            _context.Database.SetCommandTimeout(300);
            return await _context.Projects.Where(x => x.CustomerId == id)
              
                .ToListAsync().ConfigureAwait(false);//
        }

        // GET: api/Projects/5
        [HttpGet]
        public async Task<ActionResult<Project>> GetProject(Guid id)
        {
            var Project = await _context.Projects 
                .FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);

            if (Project == null)
            {
                return NotFound();
            }

            return Project;
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(Guid id, Project Project)
        {
            if (id == null)
            {
                return BadRequest();
            }

            _context.Entry(Project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST: api/Projects
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project Project)
        {
            _context.Projects.Add(Project);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = Project.Id }, Project);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(string id)
        {
            var Project = await _context.Projects.FindAsync(id);
            if (Project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(Project);
            await _context.SaveChangesAsync();

            return Project;
        }

        private bool ProjectExists(Guid id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
