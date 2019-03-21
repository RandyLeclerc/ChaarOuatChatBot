using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Questions 
    {
        public int Id { get; set; }
        //public int NumberOfPositiveReviews { get; set; }
        public string Description { get; set; }
        public string Answer { get; set; }
        public string Status { get; set; }
        //public int NumberOfNegativeReviews { get; set; }

        //public ICollection<QuestionsWithoutAnswers> QuestionsWithoutAnswers { get; set; }


        //Answer
        //Traité

    }
}
