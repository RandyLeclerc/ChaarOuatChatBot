using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=OuatDB")
        {

        }

        public virtual DbSet<Questions> Questions { get; set; }
        //public virtual DbSet<QuestionsWithoutAnswers> QuestionsWithoutAnswers { get; set; }

    }
}
