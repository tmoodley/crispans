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
    public class ComponentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComponentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Components
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Component>>> GetComponents(Guid id)
        {
            _context.Database.SetCommandTimeout(300);
            return await _context.Components.Where(x => x.ProjectId == id)
              
                .ToListAsync().ConfigureAwait(false);//
        }

        // GET: api/Components/5
        [HttpGet]
        public async Task<ActionResult<Component>> GetComponent(Guid id)
        {
            var Component = await _context.Components 
                .FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);

            if (Component == null)
            {
                return NotFound();
            }

            return Component;
        }

        // PUT: api/Components/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponent(Guid id, Component Component)
        {
            if (id == null)
            {
                return BadRequest();
            }

            _context.Entry(Component).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentExists(id))
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

        // POST: api/Components
        [HttpPost]
        public async Task<ActionResult<Component>> PostComponent(Component Component)
        {
            _context.Components.Add(Component);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComponent", new { id = Component.Id }, Component);
        }

        // DELETE: api/Components/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Component>> DeleteComponent(string id)
        {
            var Component = await _context.Components.FindAsync(id);
            if (Component == null)
            {
                return NotFound();
            }

            _context.Components.Remove(Component);
            await _context.SaveChangesAsync();

            return Component;
        }

        private bool ComponentExists(Guid id)
        {
            return _context.Components.Any(e => e.Id == id);
        }
    }
}
