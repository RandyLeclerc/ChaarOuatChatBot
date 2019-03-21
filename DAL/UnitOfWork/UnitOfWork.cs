using DAL.Context;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork
    {
        private QuestionsRepo _questionsRepo;
        //private QuestionsWithoutAnswersRepo _questionsWithoutAnswersRepo;
        private DatabaseContext _databaseContext;

        public UnitOfWork(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public QuestionsRepo QuestionsRepo
        {
            get
            {
                if (_questionsRepo == null)
                {
                    _questionsRepo = new QuestionsRepo(_databaseContext);
                }
                return _questionsRepo;
            }
        }
        //public QuestionsWithoutAnswersRepo QuestionsWithoutAnswersRepo
        //{
        //    get
        //    {
        //        if (_questionsWithoutAnswersRepo == null)
        //        {
        //            _questionsWithoutAnswersRepo = new QuestionsWithoutAnswersRepo(_databaseContext);
        //        }
        //        return _questionsWithoutAnswersRepo;
        //    }
        //}
        public void Save()
        {
            _databaseContext.SaveChanges();
        }
    }
}
