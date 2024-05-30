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
using System.Windows;

namespace QuizApplication.Commands
{
    public class RemoveQuizCommand : BaseCommand
    {

        private readonly QuizViewModel _viewModel;
        public RemoveQuizCommand(QuizViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override async void Execute(object? parameter)
        {
            var title = parameter as string;
            var service = (QuizService)AppServiceProvider.ServiceProvider.GetService<QuizService>();

            MessageBoxResult messageBoxResult = MessageBox.Show("Do you want to remove this Quiz ?", "", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if(messageBoxResult == MessageBoxResult.Yes)
            {
                if (_viewModel.MyQuiz.IsFinished)
                {
                    await service.RemoveQuizAsync(title);
                    _viewModel.MyQuiz = new Quiz();
                    _viewModel.CurrentQuestion = null;
                    _viewModel.CurrentQuestion = new Question();
                    _viewModel.Questions = null;
                    _viewModel.Answers = new List<string>();
                    _viewModel.Answers = null;
                    _viewModel.LoadInfo(service);
                }
                else
                {
                    MessageBox.Show("You can`t delete quiz");
                }
            }
        }
    }
}
