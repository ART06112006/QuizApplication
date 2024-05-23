using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Models
{
    public class MainQuestion
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string Difficulty { get; set; }
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
        public IEnumerable<string> IncorrectAnswers { get; set; }
        public string Type { get; set; }
    }
}
