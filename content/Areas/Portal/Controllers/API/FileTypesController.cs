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
    public class FileTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FileTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FileTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FileType>>> GetFileTypes()
        {
            return await _context.FileTypes.ToListAsync();
        }

        // GET: api/FileTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FileType>> GetFileType(Guid id)
        {
            var fileType = await _context.FileTypes.FindAsync(id);

            if (fileType == null)
            {
                return NotFound();
            }

            return fileType;
        }

        // PUT: api/FileTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFileType(Guid id, FileType fileType)
        {
            if (id != fileType.Id)
            {
                return BadRequest();
            }

            _context.Entry(fileType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileTypeExists(id))
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

        // POST: api/FileTypes
        [HttpPost]
        public async Task<ActionResult<FileType>> PostFileType(FileType fileType)
        {
            _context.FileTypes.Add(fileType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFileType", new { id = fileType.Id }, fileType);
        }

        // DELETE: api/FileTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FileType>> DeleteFileType(Guid id)
        {
            var fileType = await _context.FileTypes.FindAsync(id);
            if (fileType == null)
            {
                return NotFound();
            }

            _context.FileTypes.Remove(fileType);
            await _context.SaveChangesAsync();

            return fileType;
        }

        private bool FileTypeExists(Guid id)
        {
            return _context.FileTypes.Any(e => e.Id == id);
        }
    }
}
