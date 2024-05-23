using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace QuizApplication.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        public static async Task<AppDbContext> AppDbContextAsync()
        {
            return await Task.Run(() => { return new AppDbContext(); });
        }
    }
}
