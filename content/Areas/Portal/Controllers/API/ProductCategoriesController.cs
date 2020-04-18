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
    public class ProductCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategory()
        {
            return await _context.ProductCategory.ToListAsync();
        }

        // GET: api/CustomerCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProductCategory>>> GetProductCategory(Guid id)
        {
            var ProductCategory = await _context.ProductCategory.Where(x => x.ProductId == id).ToListAsync().ConfigureAwait(false);

            if (ProductCategory == null)
            {
                return NotFound();
            }

            return ProductCategory;
        }

        // PUT: api/CustomerCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCategory(Guid id, ProductCategory ProductCategory)
        {
            if (id != ProductCategory.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(ProductCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoryExists(id))
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
        public async Task<ActionResult<ProductCategory>> PostProductCategory(ProductCategory ProductCategory)
        {
            _context.ProductCategory.Add(ProductCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductCategoryExists(ProductCategory.ProductId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductCategory", new { id = ProductCategory.ProductId }, ProductCategory);
        }

        // DELETE: api/CustomerCategories/5
        [HttpDelete()]
        public async Task<ActionResult<ProductCategory>> DeleteProductCategory([FromQuery] Guid ProductId, [FromQuery] Guid categoryId)
        {
            var ProductCategory = await _context.ProductCategory.Where(x => x.ProductId == ProductId && x.CategoryId == categoryId).FirstOrDefaultAsync().ConfigureAwait(false);
            if (ProductCategory == null)
            {
                return NotFound();
            }

            _context.ProductCategory.Remove(ProductCategory);
            await _context.SaveChangesAsync();

            return ProductCategory;
        }

        private bool ProductCategoryExists(Guid id)
        {
            return _context.ProductCategory.Any(e => e.ProductId == id);
        }
    }
}
