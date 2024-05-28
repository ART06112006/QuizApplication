using Microsoft.Extensions.DependencyInjection;
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
    public class ChangeQuizSettingsWindowCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            var window = (QuizSettingsWindow)(AppServiceProvider.ServiceProvider.GetService(typeof(QuizSettingsWindow)));
            window.ShowDialog();

            if (window._quizSettingsViewModel.Quiz != null)
            {
                var service = (QuizService)AppServiceProvider.ServiceProvider.GetService<QuizService>();
                var viewModel = parameter as QuizViewModel;
                viewModel.UpdateUI(window._quizSettingsViewModel.Quiz);
                viewModel.LoadInfo(service);
            }
        }
    }
}
