using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Services
{
    public class QuizService
    {
        private readonly QuizRepository _quizRepository;

        public QuizService(QuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<List<string>> GetQuizNamesAsync()
        {
            return new List<string>(await _quizRepository.SelectListByConditionAsync(x => x.Name));
        }

        public async Task<Quiz> GetQuizAsync(string name)
        {
            return await _quizRepository.GetItemByConditionAsync(x => x.Name == name);
        }

        public async Task AddQuizAsync(Quiz quiz)
        {
            await _quizRepository.AddItemAsync(quiz);
        }

        public async Task RemoveQuizAsync(string name)
        {
            await _quizRepository.RemoveItemAsync(name);
        }

        public async Task UpdateQuizAsync(Quiz quiz)
        {
            await _quizRepository.UpdateItemAsync(quiz);
        }
    }
}
