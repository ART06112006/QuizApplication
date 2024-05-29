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
        private int counter = 0;
        public override async void Execute(object? parameter)
        {
            var viewModel = parameter as QuizViewModel;
            var service = (QuizService)AppServiceProvider.ServiceProvider.GetService<QuizService>();

            if(viewModel.SelectedAnswers == null)
            {
                return;
            }

            viewModel.Questions[counter].UserAnswer = viewModel.SelectedAnswers;
            if (viewModel.Questions[counter].CorrectAnswer == viewModel.SelectedAnswers)
            {
                viewModel.MyQuiz.TotalScore += 1;
            }

            counter++;
            if (counter < viewModel.Questions.Count)
            {
                
                viewModel.SwitchQuestion(viewModel.Questions[counter]);
            }
            else
            {
                //MessageBox.Show($"End of test. Your score : {viewModel.MyQuiz.TotalScore}");
                viewModel.MyQuiz.IsFinished = true;

                var result = AppServiceProvider.ServiceProvider.GetService<ResultViewModel>();
                result.Quiz = viewModel.MyQuiz;
                result.Questions = new ObservableCollection<Question>(viewModel.Questions);
                result.CheckAnswers(viewModel.Questions);

                var windowRes = AppServiceProvider.ServiceProvider.GetService<ResultWindow>();
                windowRes.DataContext = result;
                windowRes.ShowDialog();

                viewModel.MyQuiz.Questions = null;
                await service.UpdateQuizAsync(viewModel.MyQuiz);
                counter = 0;
            }
        }
    }
}
