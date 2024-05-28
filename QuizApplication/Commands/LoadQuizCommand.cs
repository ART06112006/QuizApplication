using Microsoft.Extensions.DependencyInjection;
using QuizApplication.Infrastructure;
using QuizApplication.Services;
using QuizApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Commands
{
    public class LoadQuizCommand : BaseCommand
    {
        public override async void Execute(object? parameter)
        {
            string name = parameter as string;
            var viewModel = AppServiceProvider.ServiceProvider.GetService<QuizViewModel>();

            if (name != null)
            {
                var service = (QuizService)AppServiceProvider.ServiceProvider.GetService<QuizService>();
                viewModel.MyQuiz = await service.GetQuizAsync(name);
                viewModel.UpdateUI(viewModel.MyQuiz);
            }
        }
    }
}
