using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsFinished { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Question> AnsweredQuestions => Questions?.Where(q => !string.IsNullOrEmpty(q.UserAnswer)).ToList();
        public int TotalScore { get; set; }    //result of answeared questions in percents
        public DateTime UpdateDate { get; set; }
    }
}
