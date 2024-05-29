using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.Configuration;
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
using System.Configuration;
using System.IO;
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

            var configuration = LoadConfiguration();
            services.AddSingleton<Microsoft.Extensions.Configuration.IConfiguration>(configuration);

            //Urls
            services.AddSingleton(new UrlsConfig()
            {
                CategoriesUrl = configuration["Urls:CategoriesUrl"],
                QuestionsUrl = configuration["Urls:QuestionsUrl"]
            });

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

            //Commands
            services.AddTransient<StartNewQuizCommand>();
            services.AddTransient<ChangeQuizSettingsWindowCommand>();
            services.AddTransient<ChooseAnswerCommand>();
            services.AddTransient<RemoveQuizCommand>();
            services.AddTransient<LoadQuizCommand>();
            services.AddTransient<SaveQuizCommand>();

            ServiceProvider = services.BuildServiceProvider();
        }

        private static Microsoft.Extensions.Configuration.IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }

        private static void ConfigureAutoMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<APIQuestion, Question>()
                    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                    .ForMember(dest => dest.Tags, opt => opt.MapFrom<TagsResolver>())
                    .ForMember(dest => dest.Difficulty, opt => opt.MapFrom(src => src.Difficulty))
                    .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Question.Text))
                    .ForMember(dest => dest.CorrectAnswer, opt => opt.MapFrom(src => src.CorrectAnswer))
                    .ForMember(dest => dest.IncorrectAnswers, opt => opt.MapFrom<IncorrectAnswersResolver>())
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static async Task<AppDbContext> GetAppDbContextAsync()
        {
            return await Task.Run(() => { return new AppDbContext(); });
        }
    }

    public class UrlsConfig
    {
        public string CategoriesUrl { get; set; }
        public string QuestionsUrl { get; set; }
    }

    public class TagsResolver : IValueResolver<APIQuestion, Question, ICollection<Tag>>
    {
        public ICollection<Tag> Resolve(APIQuestion source, Question destination, ICollection<Tag> destMember, ResolutionContext context)
        {
            return source.Tags?.Select(tag => new Tag { Text = tag }).ToList() ?? new List<Tag>();
        }
    }

    public class IncorrectAnswersResolver : IValueResolver<APIQuestion, Question, ICollection<Answer>>
    {
        public ICollection<Answer> Resolve(APIQuestion source, Question destination, ICollection<Answer> destMember, ResolutionContext context)
        {
            return source.IncorrectAnswers?.Select(answer => new Answer { Text = answer }).ToList() ?? new List<Answer>();
        }
    }
}
