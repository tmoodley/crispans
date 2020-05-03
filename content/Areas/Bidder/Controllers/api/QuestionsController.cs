using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;
using Vue2Spa.Models;
using Vue2Spa.Areas.Portal.Models;

namespace Vue2Spa.Areas.Bidder.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Questions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestion(string src, string bidderid,string recid)
        {
            //var questions =
            List<Question> res = new List<Question>();

            if (src=="Tenders")
            {
                var jobQuestions =   _context.JobQuestions.Include(a=>a.Question).ThenInclude(b=>b.Answers).Where(a => (a.JobId == recid) && (a.BidderId == Guid.Parse(bidderid))).ToList();
                //var jobQuestion = await res.FirstOrDefault();
                
                foreach(var jobQuestion in jobQuestions)
                {
                    res.Add(jobQuestion.Question);
                }
            }
            else
            {
                var poQuestions = _context.POQuestion.Include(a => a.Question).ThenInclude(b => b.Answers).Where(a => (a.PurchaseOrderId == Guid.Parse(recid)) && (a.BidderId == Guid.Parse(bidderid))).ToList();
                //var jobQuestion = await res.FirstOrDefault();

                foreach (var poQuestion in poQuestions)
                {
                    res.Add(poQuestion.Question);
                }
            }

            return res;
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(Guid id)
        {
            var question = await _context.Question.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }

        // PUT: api/Questions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(Guid id, Question question)
        {
            if (id != question.Id)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
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

        // POST: api/Questions
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion([FromBody]QuestionPostClass param)
        {

            param.question.CreationTime = DateTime.Now;

            if (param.src == "Tenders")
            {

               

                JobQuestion jq = new JobQuestion()
                {
                    BidderId = Guid.Parse(param.bidder),
                    JobId = param.recid,
                    Question = param.question
                };

                _context.Add(jq);
                await _context.SaveChangesAsync();
            }
            else
            {
                POQuestion poq = new POQuestion()
                {
                    BidderId = Guid.Parse(param.bidder),
                    PurchaseOrderId = Guid.Parse(param.recid),
                    Question = param.question
                };

                _context.Add(poq);
                await _context.SaveChangesAsync();
            }
            //_context.Question.Add(question);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestion", new { id = param.question.Id }, param.question);
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Question>> DeleteQuestion(Guid id)
        {
            var question = await _context.Question.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Question.Remove(question);
            await _context.SaveChangesAsync();

            return question;
        }

        private bool QuestionExists(Guid id)
        {
            return _context.Question.Any(e => e.Id == id);
        }
    }

    public class QuestionPostClass
    {
        public string src { get; set; }
        public string recid { get; set; }
        public string bidder { get; set; }
        public Question question { get; set; }
    }
}
