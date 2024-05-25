using Microsoft.EntityFrameworkCore;
using QuizApplication.Context;
using QuizApplication.Infrastructure;
using QuizApplication.Models;
using QuizApplication.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Repositories
{
    public class QuizRepository : IRepository<Quiz>, ISelectListRepository<Quiz>
    {
        public async Task<IEnumerable<string>> SelectListByConditionAsync(Expression<Func<Quiz, string>> predicate)
        {
            try
            {
                using (var _appDbContext = await AppServiceProvider.GetAppDbContextAsync())
                {
                    return await _appDbContext.Quizes.Select(predicate).ToListAsync();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Quiz> GetItemByConditionAsync(Expression<Func<Quiz, bool>> predicate)
        {
            try
            {
                using (var _appDbContext = await AppServiceProvider.GetAppDbContextAsync())
                {
                    return await _appDbContext.Quizes.Where(predicate).FirstOrDefaultAsync();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task AddAsync(Quiz quiz)
        {
            try
            {
                using (var _appDbContext = await AppServiceProvider.GetAppDbContextAsync())
                {
                    await _appDbContext.Quizes.AddAsync(quiz);
                    await _appDbContext.SaveChangesAsync();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task RemoveAsync(string name)
        {
            try
            {
                using (var _appDbContext = await AppServiceProvider.GetAppDbContextAsync())
                {
                    var foundQuiz = await _appDbContext.Quizes.Where(x => x.Name == name).FirstOrDefaultAsync();
                    if (foundQuiz != null)
                    {
                        _appDbContext.Quizes.Remove(foundQuiz);
                        await _appDbContext.SaveChangesAsync();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateAsync(Quiz newQuiz)
        {
            try
            {
                using (var _appDbContext = await AppServiceProvider.GetAppDbContextAsync())
                {
                    _appDbContext.Quizes.Update(newQuiz);
                    await _appDbContext.SaveChangesAsync();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
