using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;
using Vue2Spa.Areas.Bidder.Models;
using System.Security.Claims;
using Vue2Spa.Areas.Bidder.Models.DTO;

namespace Vue2Spa.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyPOBidsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public MyPOBidsController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: api/MyPOBids
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyBidsDto>>> GetPOBids()
        {
            //var nameIdentifier = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;


            var currentBidderEmail = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            var currentBidder = await _context.Bidders.Where(a => a.EmailAddress == currentBidderEmail).FirstOrDefaultAsync().ConfigureAwait(true);

            Guid currentBidderId = currentBidder.Id;

            var mybids = _context.JobBids.Include(a => a.Job).Where(a => a.BidderId == currentBidderId).ToList();
            var myPoBids = _context.POBids.Include(a => a.PurchaseOrder).Where(a => a.BidderId == currentBidderId).ToList();

            var jobBids = mybids.Select(a => new MyBidsDto()
            {
                Id = a.JobId,
                Number = a.Job.Number,
                Name = a.Job.Name,
                BidStatus = a.Status,
                JobStatus = a.Job.Status,
                Source = "Tender",
                BidderId = currentBidderId
            }).ToList();


            var poBids = myPoBids.Select(a => new MyBidsDto()
            {
                Id = a.PurchaseOrderId.ToString(),
                Number = a.PurchaseOrder.PurchaseOrderNumber,
                Name = a.PurchaseOrder.Notes,
                BidStatus = a.Status,
                JobStatus = a.PurchaseOrder.Status,
                Source = "Purchase Order",
                BidderId = currentBidderId
            }).ToList();


            List<MyBidsDto> result = new List<MyBidsDto>();
            result.AddRange(jobBids);
            result.AddRange(poBids);



            return result;




        }

        // GET: api/MyPOBids/5
        [HttpGet("{id}")]
        public async Task<ActionResult<POBid>> GetPOBid(Guid id)
        {
            var pOBid = await _context.POBids.FindAsync(id);

            if (pOBid == null)
            {
                return NotFound();
            }

            return pOBid;
        }

        // PUT: api/MyPOBids/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPOBid(Guid id, POBid pOBid)
        {
            if (id != pOBid.PurchaseOrderId)
            {
                return BadRequest();
            }

            _context.Entry(pOBid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!POBidExists(id))
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

        // POST: api/MyPOBids
        [HttpPost]
        public async Task<ActionResult<POBid>> PostPOBid(POBid pOBid)
        {
            _context.POBids.Add(pOBid);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (POBidExists(pOBid.PurchaseOrderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPOBid", new { id = pOBid.PurchaseOrderId }, pOBid);
        }

        // DELETE: api/MyPOBids/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<POBid>> DeletePOBid(Guid id)
        {
            var pOBid = await _context.POBids.FindAsync(id);
            if (pOBid == null)
            {
                return NotFound();
            }

            _context.POBids.Remove(pOBid);
            await _context.SaveChangesAsync();

            return pOBid;
        }

        private bool POBidExists(Guid id)
        {
            return _context.POBids.Any(e => e.PurchaseOrderId == id);
        }
    }
}
