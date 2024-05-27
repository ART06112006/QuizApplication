using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public List<string> Tags { get; set; }
        public string Difficulty { get; set; }
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> IncorrectAnswers { get; set; }
        public string Type { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public string UserAnswer { get; set; }
    }
}
