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
                var service = AppServiceProvider.ServiceProvider.GetService<QuizService>();
                _viewModel.MyQuiz = await service.GetQuizAsync(name);

                if (_viewModel.MyQuiz.IsFinished)
                {
                    var questions = _viewModel.MyQuiz.Questions.ToList();
                    for(int i=0; i < questions.Count; i++)
                    {
                        questions[i].UserAnswer = null;
                    }

                    _viewModel.MyQuiz.Questions = questions;

                    await service.UpdateQuizAsync(_viewModel.MyQuiz);
                    _viewModel.Questions = new ObservableCollection<Question>(questions);
                    _viewModel.MyQuiz.IsFinished = false;
                    _viewModel.MyQuiz.TotalScore = 0;
                    _viewModel.counter = 0;
                    _viewModel.UpdateUI(_viewModel.MyQuiz);
                    return;
                }

                MessageBoxResult messageBoxResult = MessageBox.Show("Do you want to continue this Quiz ?", "", MessageBoxButton.YesNo, MessageBoxImage.Information);

                if (messageBoxResult == MessageBoxResult.Yes && !_viewModel.MyQuiz.IsFinished)
                {
                    var questions = _viewModel.MyQuiz.Questions.Where(x => x.UserAnswer == null).ToList();
                    _viewModel.Questions =new ObservableCollection<Question>(questions);
                    _viewModel.counter = 0;
                    _viewModel.UpdateUI(_viewModel.MyQuiz);
                }
                else
                {
                    var questions = _viewModel.MyQuiz.Questions.ToList();

                    for (int i = 0; i < questions.Count; i++)
                    {
                        questions[i].UserAnswer = null;
                    }

                    _viewModel.MyQuiz.Questions = questions;

                    await service.UpdateQuizAsync(_viewModel.MyQuiz);
                    _viewModel.Questions = new ObservableCollection<Question>(questions);
                    _viewModel.MyQuiz.IsFinished = false;
                    _viewModel.MyQuiz.TotalScore = 0;
                    _viewModel.counter = 0;
                    _viewModel.UpdateUI(_viewModel.MyQuiz);
                }
            }
        }
    }
}
