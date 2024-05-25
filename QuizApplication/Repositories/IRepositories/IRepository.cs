using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Repositories.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetItemByConditionAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task RemoveAsync(string name);
        Task UpdateAsync(T newEntity);
    }
}
