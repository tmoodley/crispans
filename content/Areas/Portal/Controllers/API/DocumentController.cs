using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HelpingHands.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vue2Spa.Models;

namespace Vue2Spa.Areas.Portal.Controllers.API
{
    [Authorize(Roles = "Partner,Administrator")]
    [Route("/portal/api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private IHostingEnvironment _host;
        private readonly ApplicationDbContext _context;

        public DocumentController(IHostingEnvironment _host, ApplicationDbContext context)
        {
            _context = context;
            this._host = _host;
        }
        [HttpPost] 
        public async Task<IActionResult> Upload(IFormFile file, [FromForm]Guid CustomerId)
        {
            try
            {
                var document = new Document()
                {
                    Name = file.FileName,
                    Extension = Path.GetExtension(file.FileName),
                    CustomerId = CustomerId
                };
                _context.Documents.Add(document);
                await _context.SaveChangesAsync();


                //// To do: Validation
                //// To do: check file-content
                var folderName = "uploads";
                string webRootPath = _host.WebRootPath;
                string fileLandingPath = Path.Combine(webRootPath, folderName);

                StreamReader stream = new StreamReader(file.OpenReadStream());

                if (!Directory.Exists(fileLandingPath))
                {
                    Directory.CreateDirectory(fileLandingPath);
                }

                string filePath = string.Format("{0}\\{1}", fileLandingPath,
                       Path.GetFileNameWithoutExtension(document.Id.ToString()));

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                 
                return Ok(new { id = document.Id }); 
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = "Error", message = ex.Message });
            }
        }
    }
}
