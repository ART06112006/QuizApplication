using Microsoft.Extensions.DependencyInjection;
using QuizApplication.Infrastructure;
using QuizApplication.Models;
using QuizApplication.Services;
using QuizApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Commands
{
    public class LoadQuizCommand : BaseCommand
    {
        private readonly QuizViewModel _viewModel;
        public LoadQuizCommand(QuizViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override async void Execute(object? parameter)
        {
            string name = parameter as string;

            if (name != null)
            {
                var service = (QuizService)AppServiceProvider.ServiceProvider.GetService<QuizService>();
                _viewModel.MyQuiz = await service.GetQuizAsync(name);
                var questions = _viewModel.MyQuiz.Questions;
                _viewModel.Questions = new ObservableCollection<Question>(questions);
                _viewModel.UpdateUI(_viewModel.MyQuiz);
            }
        }
    }
}
