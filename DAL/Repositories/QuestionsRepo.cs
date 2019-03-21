using Common.Interfaces;
using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class QuestionsRepo : IRepository<Questions>
    {
        private DatabaseContext dbContext;
        public QuestionsRepo(DatabaseContext db)
        {
            dbContext = db;
        }


        public Questions Create(Questions obj)
        {
            dbContext.Questions.Add(obj);
            //dbContext.SaveChanges();
            return obj;
        }

        public void Delete(int id)
        {
            Questions questions = Retrieve(id);
            dbContext.Questions.Remove(questions);
            //dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            Questions category = Retrieve(id);
            dbContext.Questions.Remove(category);
            //dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public Questions Retrieve(int id)
        {
            return dbContext.Questions.FirstOrDefault(u => u.Id == id);
        }

  

        public Questions Retrieve(string id)
        {
            throw new NotImplementedException();
        }

        public List<Questions> RetrieveAll()
        {
            return dbContext.Questions.ToList();
        }

        public void Update(Questions obj)
        {
            Questions questions = Retrieve(obj.Id);
            questions.Description = obj.Description;
            questions.Answer = obj.Answer;
            questions.Status = obj.Status;
            //questions.NumberOfNegativeReviews = obj.NumberOfNegativeReviews;
            //questions.NumberOfPositiveReviews = obj.NumberOfPositiveReviews;
            
            //category.ParentId = obj.ParentId;
            //dbContext.SaveChanges();
        }
    }
}
