using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using QuizApplication.Commands;
using QuizApplication.Context;
using QuizApplication.Models;
using QuizApplication.Repositories;
using QuizApplication.Services;
using QuizApplication.ViewModels;
using QuizApplication.Views;
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

            //Views
            services.AddTransient<QuizWindow>();
            services.AddTransient<QuizSettingsWindow>();

            //ViewModels
            services.AddTransient<QuizViewModel>();
            services.AddTransient<QuizSettingsViewModel>();

            //AutoMapper
            services.AddAutoMapper(typeof(AppServiceProvider));
            ConfigureAutoMapper(services);

            //Services
            services.AddSingleton<APIQuestionService>();
            services.AddSingleton<QuizService>();

            //Repositories
            services.AddSingleton<QuizRepository>();

<<<<<<< Updated upstream
            //Views
            services.AddTransient<QuizWindow>();
            services.AddTransient<QuizSettingsWindow>();

            //ViewModels
            services.AddTransient<QuizViewModel>();
=======
            //Commands
            services.AddTransient<StartNewQuizCommand>();
>>>>>>> Stashed changes

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

        public static async Task<AppDbContext> GetAppDbContextAsync()
        {
            return await Task.Run(() => { return new AppDbContext(); });
        }
    }
}
