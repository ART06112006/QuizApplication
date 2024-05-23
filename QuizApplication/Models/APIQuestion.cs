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
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class RootQuestion
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("difficulty")]
        public string Difficulty { get; set; }

        [JsonProperty("regions")]
        public List<string> Regions { get; set; }

        [JsonProperty("isNiche")]
        public bool IsNiche { get; set; }

        [JsonProperty("question")]
        public Question Question { get; set; }

        [JsonProperty("correctAnswer")]
        public string CorrectAnswer { get; set; }

        [JsonProperty("incorrectAnswers")]
        public List<string> IncorrectAnswers { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
