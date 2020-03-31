using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;
using Vue2Spa.Areas.Portal.Models;
using Vue2Spa.Areas.Portal.Models.DTO;
using Vue2Spa.Models;

namespace Vue2Spa.Controllers
{
    public class JobQuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobQuestions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.JobQuestions.Include(j => j.Job).Include(j => j.Question);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: JobQuestions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobQuestion = await _context.JobQuestions
                .Include(j => j.Job)
                .Include(j => j.Question)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (jobQuestion == null)
            {
                return NotFound();
            }

            return View(jobQuestion);
        }

        // GET: JobQuestions/Create
        public IActionResult Create(string id)
        {
            ViewData["JobId"] = id;
            //ViewData["QuestionId"] = new SelectList(_context.Set<Question>(), "Id", "Id");

            var job = _context.Jobs.Where(a => a.Id == id).FirstOrDefault();
            ViewData["Number"] = job.Number;
            ViewData["Name"] = job.Name; 

            return View();
        }

        // POST: JobQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobId,QuestionTitle,QuestionBody")] JobQuestionCreateDto jobQuestionCreateDto)
        {
            if (ModelState.IsValid)
            {

                var question = new Question()
                {
                    Title = jobQuestionCreateDto.QuestionTitle,
                    Body = jobQuestionCreateDto.QuestionBody
                };
                _context.Add(question);


                await _context.SaveChangesAsync();


                var jobQuestion = new JobQuestion()
                {
                    JobId = jobQuestionCreateDto.JobId,
                    QuestionId = question.Id
                };

                _context.Add(jobQuestion);


                await _context.SaveChangesAsync();

                return RedirectToAction("Details","Tenders", new { id = jobQuestionCreateDto.JobId });
            }
            //ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id", jobQuestion.JobId);
            //ViewData["QuestionId"] = new SelectList(_context.Set<Question>(), "Id", "Id", jobQuestion.QuestionId);
            return View();
        }

        // GET: JobQuestions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobQuestion = await _context.JobQuestions.FindAsync(id);
            if (jobQuestion == null)
            {
                return NotFound();
            }
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id", jobQuestion.JobId);
            //ViewData["QuestionId"] = new SelectList(_context.Set<Question>(), "Id", "Id", jobQuestion.QuestionId);
            return View(jobQuestion);
        }

        // POST: JobQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("JobId,QuestionId")] JobQuestion jobQuestion)
        {
            if (id != jobQuestion.JobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobQuestionExists(jobQuestion.JobId))
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
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id", jobQuestion.JobId);
            //ViewData["QuestionId"] = new SelectList(_context.Set<Question>(), "Id", "Id", jobQuestion.QuestionId);
            return View(jobQuestion);
        }

        // GET: JobQuestions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobQuestion = await _context.JobQuestions
                .Include(j => j.Job)
                .Include(j => j.Question)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (jobQuestion == null)
            {
                return NotFound();
            }

            return View(jobQuestion);
        }

        // POST: JobQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var jobQuestion = await _context.JobQuestions.FindAsync(id);
            _context.JobQuestions.Remove(jobQuestion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobQuestionExists(string id)
        {
            return _context.JobQuestions.Any(e => e.JobId == id);
        }
    }
}
