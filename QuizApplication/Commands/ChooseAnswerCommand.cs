using QuizApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuizApplication.Commands
{
    public class ChooseAnswerCommand : BaseCommand
    {
        private int counter = 0;
        public override void Execute(object? parameter)
        {
            var viewModel = parameter as QuizViewModel;

            if(viewModel.SelectedAnswers == null)
            {
                return;
            }
            if (viewModel.Questions[counter].CorrectAnswer == viewModel.SelectedAnswers)
            {
                viewModel.MyQuiz.TotalScore += 1;
                MessageBox.Show("Correct");
            }
            else
            {
                MessageBox.Show("Incorrect Answer");
            }

            counter++;
            if (counter < viewModel.Questions.Count)
            {
                
                viewModel.SwitchQuestion(viewModel.Questions[counter]);
            }
            else
            {
                MessageBox.Show($"End of test. Your score : {viewModel.MyQuiz.TotalScore}");
                viewModel.MyQuiz.IsFinished = true;
                counter = 0;
            }
            //counter++;
        }
    }
}
