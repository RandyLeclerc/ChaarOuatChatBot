using Business.Extensions;
using Common.BTO;
using DAL.Context;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class QuestionsLogic
    {
        private DatabaseContext context = new DatabaseContext();

        //Create
        public QuestionsBTO Create(QuestionsBTO bto)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
 
            var response = unitOfWork.QuestionsRepo.Create(bto.QuestionsBTOToQuestions());
            unitOfWork.Save();
            return response.QuestionsToQuestionsBTO();
        }

        //Read
        public QuestionsBTO Retrieve(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);

            var response = unitOfWork.QuestionsRepo.Retrieve(id).QuestionsToQuestionsBTO();

            return (response == null) ? null : response;
        }

        //ReadAll
        public List<QuestionsBTO> RetrieveAll()
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
            List<QuestionsBTO> Listbto = new List<QuestionsBTO>();

            foreach (var item in unitOfWork.QuestionsRepo.RetrieveAll())
            {
                QuestionsBTO btoToAdd = this.Retrieve(item.Id);
                Listbto.Add(btoToAdd);
            }

            return Listbto;
        }

        //Update
        public void Update(QuestionsBTO existingQuestions)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
            unitOfWork.QuestionsRepo.Update(existingQuestions.QuestionsBTOToQuestions());
            unitOfWork.Save();
        }

        //Delete
        public void Delete(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
            unitOfWork.QuestionsRepo.Delete(id);
            unitOfWork.Save();
        }
    }
}
