using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Services
{
    public class APIQuestionService
    {
        public async Task<Quiz> GetQuizAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync("https://the-trivia-api.com/v2/quizzes");

                if (json != null)
                {

                }
            }
        }
    }
}
