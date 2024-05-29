using Microsoft.Extensions.DependencyInjection;
using QuizApplication.Infrastructure;
using QuizApplication.Services;
using QuizApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuizApplication.Commands
{
    public class SaveQuizCommand : BaseCommand
    {
        public override async void Execute(object? parameter)
        {
            var viewModel = parameter as QuizViewModel;

            if(viewModel.MyQuiz != null)
            {
                var service = AppServiceProvider.ServiceProvider.GetService<QuizService>();
                await service.UpdateQuizAsync(viewModel.MyQuiz);
                MessageBox.Show("Quiz Saved");
            }
        }
    }
}
