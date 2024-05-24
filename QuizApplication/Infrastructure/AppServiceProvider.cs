using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Infrastructure
{
    public static class AppServiceProvider
    {
        public static ServiceProvider ServiceProvider { get; private set; }
        public static void Initialize()
        {
            var services = new ServiceCollection();

            

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
