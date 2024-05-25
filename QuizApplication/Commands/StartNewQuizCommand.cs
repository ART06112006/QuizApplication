using QuizApplication.Infrastructure;
using QuizApplication.Services;
using QuizApplication.ViewModels;
using QuizApplication.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Commands
{
    public class StartNewQuizCommand : BaseCommand
    {
        public override async void Execute(object? parameter)
        {
            var viewModel = parameter as QuizSettingsViewModel;
            var quizViewModel = parameter as QuizViewModel;

            if (viewModel != null)
            {
                var apiQuestionService = (APIQuestionService)(AppServiceProvider.ServiceProvider.GetService(typeof(APIQuestionService)));
                var quiz = await apiQuestionService.GetQuizAsync(viewModel.QuizName, int.Parse(viewModel.QuestionLimit), viewModel.Difficulty, viewModel.Categories);

                if (quiz != null)
                {
                    var quizService = (QuizService)(AppServiceProvider.ServiceProvider.GetService(typeof(QuizService)));
                    await quizService.AddQuizAsync(quiz);

                    //Update UI TODO
                    
                }
            }
        }
    }
}
