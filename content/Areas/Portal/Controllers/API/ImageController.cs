using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vue2Spa.Areas.Portal.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {

        // GET: api/Image/5
        [HttpGet("{id}", Name = "Get")]

        public async Task<IActionResult> Get(string id)
        {
            var path = Path.Combine(
                         Directory.GetCurrentDirectory(),
                         "wwwroot/uploads", id);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory).ConfigureAwait(false);
            }
            memory.Position = 0; 
            return File(memory, "image/jpeg");
        } 
    }
}
