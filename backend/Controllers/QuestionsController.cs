using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private QuizDbContext context;
        public QuestionsController(QuizDbContext quizContext)
        {
            this.context = quizContext;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Question>> Get()
        {
            return context.Questions;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Question question)
        {
            context.Questions.Add(question);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return Ok(question);
            

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Question EditedQuestion)
        {

            if (id != EditedQuestion.Id)
            {
                return BadRequest();
            }
            //var oldQuestion =await  context.Questions.FirstOrDefaultAsync(Question => Question.Id == id);

            //if (oldQuestion == null)
            //    return NotFound();

            //oldQuestion.Text = EditedQuestion.Text;
            //oldQuestion.CorrectAnswer = EditedQuestion.CorrectAnswer;
            //oldQuestion.WrongAnswer1 = EditedQuestion.WrongAnswer1;
            //oldQuestion.WrongAnswer2 = EditedQuestion.WrongAnswer2;
            //oldQuestion.WrongAnswer3 = EditedQuestion.WrongAnswer3;
            //context.SaveChanges();

            context.Entry(EditedQuestion).State = EntityState.Modified;
            await context.SaveChangesAsync().ConfigureAwait(false);
            return Ok(EditedQuestion);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
