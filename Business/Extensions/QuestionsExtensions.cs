using Common.BTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
    public static class QuestionsExtensions
    {
        public static Questions QuestionsBTOToQuestions(this QuestionsBTO bto)
        {
            return new Questions
            {
                Id = bto.id,
                Description = bto.question,
                Status = bto.status,
                Answer = bto.answer
            };
        }

        public static QuestionsBTO QuestionsToQuestionsBTO(this Questions question)
        {
            return new QuestionsBTO
            {
               id =  question.Id,
               question = question.Description,
               answer = question.Answer,
               status = question.Status
            };
        }
    }
}
