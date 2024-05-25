using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using QuizApplication.Models;
using QuizApplication.Services;
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

            services.AddAutoMapper(typeof(AppServiceProvider));
            ConfigureAutoMapper(services);

            services.AddSingleton<APIQuestionService>();

            ServiceProvider = services.BuildServiceProvider();
        }

        private static void ConfigureAutoMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<APIQuestion, Question>();

            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
