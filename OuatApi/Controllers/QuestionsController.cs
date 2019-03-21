using Business;
using Common.BTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OuatApi.Controllers
{

    public class QuestionsController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            QuestionsLogic questions = new QuestionsLogic();
            return Ok(questions.RetrieveAll());
        }

        public IHttpActionResult GetById(int id)
        {

            QuestionsLogic questions = new QuestionsLogic();
            return Ok(questions.Retrieve(id));

        }

        public IHttpActionResult Post(QuestionsBTO questionBto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            QuestionsLogic questions = new QuestionsLogic();

            var model = questions.Create(questionBto);

            return CreatedAtRoute("DefaultApi", new { id = model.id }, model);
        }

        public IHttpActionResult Put(QuestionsBTO questionBto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            QuestionsLogic questions = new QuestionsLogic();
            var existingQuestions = questions.Retrieve(questionBto.id);

            if (existingQuestions != null)
            {
                questions.Update(questionBto);
            }
            else return NotFound();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            {
                if (id <= 0)
                    return BadRequest("Not a valid user id");

                QuestionsLogic questions = new QuestionsLogic();
                questions.Delete(id);

                return Ok("This question was deleted");
            }
        }
    }
}
