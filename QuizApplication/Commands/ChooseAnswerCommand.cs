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
    public class ChooseAnswerCommand : BaseCommand
    {
        //private int counter = 0;
        public override async void Execute(object? parameter)
        {
            var viewModel = parameter as QuizViewModel;
            var service = (QuizService)AppServiceProvider.ServiceProvider.GetService<QuizService>();

            if(viewModel.SelectedAnswers == null || viewModel.Questions == null)
            {
                return;
            }

            viewModel.Questions[viewModel.counter].UserAnswer = viewModel.SelectedAnswers;
            if (viewModel.Questions[viewModel.counter].CorrectAnswer == viewModel.SelectedAnswers)
            {
                viewModel.MyQuiz.TotalScore += 1;
            }

            viewModel.counter++;
            if (viewModel.counter < viewModel.Questions.Count)
            {
                
                viewModel.SwitchQuestion(viewModel.Questions[viewModel.counter]);
            }
            else
            {
                viewModel.MyQuiz.IsFinished = true;
                await service.UpdateQuizAsync(viewModel.MyQuiz);

                var result = AppServiceProvider.ServiceProvider.GetService<ResultViewModel>();
                result.Quiz = viewModel.MyQuiz;
                var questions = new ObservableCollection<Question>(viewModel.MyQuiz.Questions);
                result.CheckAnswers(questions);

                var windowRes = AppServiceProvider.ServiceProvider.GetService<ResultWindow>();
                windowRes.DataContext = result;
                windowRes.Show();
                viewModel.MyQuiz = new Quiz();
                viewModel.CurrentQuestion = null;
                viewModel.CurrentQuestion = new Question();
                viewModel.Questions = null;
                viewModel.Answers = new List<string>();
                viewModel.Answers = null;
                viewModel.counter = 0;
            }
        }
    }
}
