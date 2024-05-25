using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Repositories.IRepositories
{
    public interface ISelectListRepository<T> where T : class
    {
        Task<IEnumerable<string>> SelectListByConditionAsync(Expression<Func<T, string>> predicate);
    }
}
