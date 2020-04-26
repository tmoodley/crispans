using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;
using Vue2Spa.Areas.Portal.Models;

namespace Vue2Spa.Areas.Portal.Controllers
{
    [Area("Portal")]
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Portal/Jobs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Jobs.Include(j => j.Customers);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Portal/Jobs/Details/5
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

            return View(job);
        }

        // GET: Portal/Jobs/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            return View();
        }

        // POST: Portal/Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tax,TaxPickup,TaxShipping,DateAvailable,DateAvailableUtc,DateClosing,DateClosingUtc,DateClosingSecondary,Name,Number,Classification,Status,PickupLocation,Summary,Description,OpeningProcess,Price,PricePickup,PriceShipping,Procedure,ShowUnofficial,ShowSubmitted,ShowPlanTakers,ShowTeamMembers,ShowTeamMembersContact,HasReferenceTable,HasSubContractorTable,PreQualSubContractorsOnly,NumReferencesRequired,HasSummaryTable,SummaryTableName,IsSubTotalOnSummary,SelectedTablesForSummary,BidFormsHeadingText,TermsAndConditionsHeadingText,ReferenceHeadingText,SubContractorHeadingText,QuestionHeadingText,SummaryTableHeadingText,SummaryTableFooterText,QuestionDeadline,IsCloseQuestionsAfterDeadline,IncludeOtherDocument,AllowBidDocumentPreview,BondHeadingText,BondTitle,BondTitle2,TermsAndConditionsChevronLabel,InstructionPageText,ProvideInstructionsPage,EstimatedValue,TotalContractAmount,ShowPurchasingRepsOnPublic,AllowFullBidDetailsUrl,AllowMultipleSubmissions,ShowOnWebsite,Evaluations,BidNotApproved,DateAwarded,LeadAgency,ParticipatingAgencies,NumberOfAgencies,EstimatedAnnualValue,ActualContractValue,ActualAnnualValue,PostCloseBidException,UnsealManually,PlannedIssueDate,IsAttendanceTrackingOn,IsCloseRegistrationAfterMeetingDate,Deleted,CreationTime,Created,CreatedBy,LastUpdated,LastUpdatedBy,CustomerId")] Job job)
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

        // GET: Portal/Jobs/Edit/5
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

        // POST: Portal/Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Tax,TaxPickup,TaxShipping,DateAvailable,DateAvailableUtc,DateClosing,DateClosingUtc,DateClosingSecondary,Name,Number,Classification,Status,PickupLocation,Summary,Description,OpeningProcess,Price,PricePickup,PriceShipping,Procedure,ShowUnofficial,ShowSubmitted,ShowPlanTakers,ShowTeamMembers,ShowTeamMembersContact,HasReferenceTable,HasSubContractorTable,PreQualSubContractorsOnly,NumReferencesRequired,HasSummaryTable,SummaryTableName,IsSubTotalOnSummary,SelectedTablesForSummary,BidFormsHeadingText,TermsAndConditionsHeadingText,ReferenceHeadingText,SubContractorHeadingText,QuestionHeadingText,SummaryTableHeadingText,SummaryTableFooterText,QuestionDeadline,IsCloseQuestionsAfterDeadline,IncludeOtherDocument,AllowBidDocumentPreview,BondHeadingText,BondTitle,BondTitle2,TermsAndConditionsChevronLabel,InstructionPageText,ProvideInstructionsPage,EstimatedValue,TotalContractAmount,ShowPurchasingRepsOnPublic,AllowFullBidDetailsUrl,AllowMultipleSubmissions,ShowOnWebsite,Evaluations,BidNotApproved,DateAwarded,LeadAgency,ParticipatingAgencies,NumberOfAgencies,EstimatedAnnualValue,ActualContractValue,ActualAnnualValue,PostCloseBidException,UnsealManually,PlannedIssueDate,IsAttendanceTrackingOn,IsCloseRegistrationAfterMeetingDate,Deleted,CreationTime,Created,CreatedBy,LastUpdated,LastUpdatedBy,CustomerId")] Job job)
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

        // GET: Portal/Jobs/Delete/5
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

        // POST: Portal/Jobs/Delete/5
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
