using QuizApplication.Models;
using QuizApplication.Repositories;
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

        public Action<string> ExceptionMessage;

        public QuizService(QuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<List<string>> GetQuizNamesAsync()
        {
            try
            {
                return new List<string>(await _quizRepository.SelectListByConditionAsync(x => x.Name));
            }
            catch (Exception ex)
            {
                ExceptionMessage?.Invoke(ex.Message);
                return null;
            }
        }

        public async Task<Quiz> GetQuizAsync(string name)
        {
            try
            {
                return await _quizRepository.GetItemByConditionAsync(x => x.Name == name);
            }
            catch (Exception ex)
            {
                ExceptionMessage?.Invoke(ex.Message);
                return null;
            }
        }

        public async Task AddQuizAsync(Quiz quiz)
        {
            try
            {
                await _quizRepository.AddAsync(quiz);
            }
            catch (Exception ex)
            {
                ExceptionMessage?.Invoke(ex.Message);
            }
        }

        public async Task RemoveQuizAsync(string name)
        {
            try
            {
                await _quizRepository.RemoveAsync(name);
            }
            catch (Exception ex)
            {
                ExceptionMessage?.Invoke(ex.Message);
            }
        }

        public async Task UpdateQuizAsync(Quiz quiz)
        {
            try
            {
                await _quizRepository.UpdateAsync(quiz);
            }
            catch (Exception ex)
            {
                ExceptionMessage?.Invoke(ex.Message);
            }
        }
    }
}
