using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;
using Vue2Spa.Areas.Portal.Models;
using DataTables.AspNet.Core;
using DataTables.AspNet.AspNetCore;
using Vue2Spa.Areas.Portal.Models.DTO;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Vue2Spa.Models.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Vue2Spa.Controllers
{
    public class TendersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TendersController(ApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Tenders
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.Jobs.Include(j => j.Customers);
            return View();
        }

        // GET: Tenders/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            

            var job = await _context.Jobs
                .Include(j => j.Customers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (job == null)
            {
                return NotFound();
            }


            if (_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name) != null)
            {
                ViewData["Bidder"] = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            }else
            {
                ViewData["Bidder"] = "";
            }

            //ViewData["Bidder"] = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return View(job);
        }

        // GET: Tenders/Create
        [Authorize]
        // GET: PurchaseOrders/Create
        public async Task<IActionResult> Create()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.Name);

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.EmailAddress == userId).ConfigureAwait(false);
            ViewBag.CustomerId = customer.Id;
            ViewBag.Email = userId;
            return View("Create");
        }

        // POST: Tenders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tax,TaxPickup,TaxShipping,DateAvailable,DateAvailableUtc,DateClosing,DateClosingUtc,DateClosingSecondary,Name,Number,Classification,Status,PickupLocation,Summary,Description,OpeningProcess,Length,Width,Height,Diameter,MinTolerance,Quantity,Price,PricePickup,PriceShipping,Procedure,ShowUnofficial,ShowSubmitted,ShowPlanTakers,ShowTeamMembers,ShowTeamMembersContact,HasReferenceTable,HasSubContractorTable,PreQualSubContractorsOnly,NumReferencesRequired,HasSummaryTable,SummaryTableName,IsSubTotalOnSummary,SelectedTablesForSummary,BidFormsHeadingText,TermsAndConditionsHeadingText,ReferenceHeadingText,SubContractorHeadingText,QuestionHeadingText,SummaryTableHeadingText,SummaryTableFooterText,QuestionDeadline,IsCloseQuestionsAfterDeadline,IncludeOtherDocument,AllowBidDocumentPreview,BondHeadingText,Title,BondTitle,BondTitle2,TermsAndConditionsChevronLabel,InstructionPageText,ProvideInstructionsPage,EstimatedValue,TotalContractAmount,ShowPurchasingRepsOnPublic,AllowFullBidDetailsUrl,AllowMultipleSubmissions,ShowOnWebsite,Evaluations,BidNotApproved,DateAwarded,LeadAgency,ParticipatingAgencies,NumberOfAgencies,EstimatedAnnualValue,ActualContractValue,ActualAnnualValue,PostCloseBidException,UnsealManually,PlannedIssueDate,IsAttendanceTrackingOn,IsCloseRegistrationAfterMeetingDate,Deleted,CreationTime,Created,CreatedBy,LastUpdated,LastUpdatedBy,CustomerId,isNda,TermsDocumentId,NdaDocumentId,ContractDocumentId,CadFileDocumentId")] Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", job.CustomerId);
            return View(job);
        }

        [Authorize]
        public async Task<IActionResult> Manage(Guid? id)
        {
            return View();
        }

        public IActionResult RegisterToBid ()
        {
            //ViewData["TenderId"] = jobid
            string bidder = TempData["bidder"].ToString();

            //ViewData["TenderId"] = TempData["jobid"];
            //ViewData["Bidder"] = TempData["bidder"];

            if (string.IsNullOrEmpty(bidder))
            {
                TempData["jobId"] = TempData["jobid"];
                return RedirectToAction("Register", "Bidders");
            }

            return RedirectToAction("Bid","Tenders");
        }


        public IActionResult Bid()//string jobid,string bidder
        {
            ViewData["TenderId"] = TempData["jobid"];
            ViewData["Bidder"] = TempData["bidder"];
            ViewData["Source"] = TempData["source"];

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Bid (JobBidDto biddto)
        {
            if (ModelState.IsValid)
            {

                var bidder = _context.Bidders.Where(a => a.EmailAddress == biddto.BidderId).FirstOrDefault();

                if(bidder == null)
                {
                    ViewData["Error"] = "Couldnt match Bidder record";
                    return View();
                }

                JobBid bid = new JobBid()
                {
                    JobId = biddto.JobId,
                    BidderId = bidder.Id,
                    Created = DateTime.Now,
                    CreatedBy = "",
                    Status = "draft",
                    Deleted = false

                };

                var exisistingBid = _context.JobBids.Where(a => (a.JobId == biddto.JobId) && (a.BidderId == bidder.Id)).FirstOrDefault();

                if (exisistingBid != null)
                {

                    ViewData["Error"] = "You have already bid for this Job";

                    return View();

                }


                _context.Add(bid);
               await _context.SaveChangesAsync();

                return View();



            }

            return View();
        }

        // GET: Tenders/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", job.CustomerId);
            return View(job);
        }

        // POST: Tenders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Tax,TaxPickup,TaxShipping,DateAvailable,DateAvailableUtc,DateClosing,DateClosingUtc,DateClosingSecondary,Name,Number,Classification,Status,PickupLocation,Summary,Description,OpeningProcess,Length,Width,Height,Diameter,MinTolerance,Quantity,Price,PricePickup,PriceShipping,Procedure,ShowUnofficial,ShowSubmitted,ShowPlanTakers,ShowTeamMembers,ShowTeamMembersContact,HasReferenceTable,HasSubContractorTable,PreQualSubContractorsOnly,NumReferencesRequired,HasSummaryTable,SummaryTableName,IsSubTotalOnSummary,SelectedTablesForSummary,BidFormsHeadingText,TermsAndConditionsHeadingText,ReferenceHeadingText,SubContractorHeadingText,QuestionHeadingText,SummaryTableHeadingText,SummaryTableFooterText,QuestionDeadline,IsCloseQuestionsAfterDeadline,IncludeOtherDocument,AllowBidDocumentPreview,BondHeadingText,Title,BondTitle,BondTitle2,TermsAndConditionsChevronLabel,InstructionPageText,ProvideInstructionsPage,EstimatedValue,TotalContractAmount,ShowPurchasingRepsOnPublic,AllowFullBidDetailsUrl,AllowMultipleSubmissions,ShowOnWebsite,Evaluations,BidNotApproved,DateAwarded,LeadAgency,ParticipatingAgencies,NumberOfAgencies,EstimatedAnnualValue,ActualContractValue,ActualAnnualValue,PostCloseBidException,UnsealManually,PlannedIssueDate,IsAttendanceTrackingOn,IsCloseRegistrationAfterMeetingDate,Deleted,CreationTime,Created,CreatedBy,LastUpdated,LastUpdatedBy,CustomerId,isNda,TermsDocumentId,NdaDocumentId,ContractDocumentId,CadFileDocumentId")] Job job)
        {
            if (id != job.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", job.CustomerId);
            return View(job);
        }

        // GET: Tenders/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .Include(j => j.Customers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        public IActionResult SubmitQuestion(string id)
        {
            return RedirectToAction("Create", "JobQuestions", new { id = id });
        }

        public IActionResult PageData(IDataTablesRequest request)
        {
            // Nothing important here. Just creates some mock data.

            _context.Database.SetCommandTimeout(300);
            var tenders = _context.Jobs.Where(x => x.Status == "start").Select( a=> new JobDto {
                Id = a.Id,
                Name = a.Name,
                DateClosing = a.DateClosing,
                Status = a.Status,
                Number = a.Number,
            }).ToList();

            

            var output = tenders;
            var data = output;

            // Global filtering.
            // Filter is being manually applied due to in-memmory (IEnumerable) data.
            // If you want something rather easier, check IEnumerableExtensions Sample.
            var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                ? data
               :
               data.Where(_item =>
               _item.Name.ToLower().Contains(request.Search.Value.ToLower()) 

               );

            // Paging filtered data.
            // Paging is rather manual due to in-memmory (IEnumerable) data.
            var dataPage = filteredData.Skip(request.Start).Take(request.Length);

            // Response creation. To create your response you need to reference your request, to avoid
            // request/response tampering and to ensure response will be correctly created.
            var response = DataTablesResponse.Create(request, data.Count(), filteredData.Count(), dataPage);

            // Easier way is to return a new 'DataTablesJsonResult', which will automatically convert your
            // response to a json-compatible content, so DataTables can read it when received.
            return new DataTablesJsonResult(response, true);
        }

        // POST: Tenders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var job = await _context.Jobs.FindAsync(id);
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobExists(string id)
        {
            return _context.Jobs.Any(e => e.Id == id);
        }
    }
}
