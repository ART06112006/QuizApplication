using QuizApplication.Infrastructure;
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
        public override void Execute(object? parameter)
        {
            var viewModel = parameter as QuizViewModel;

            if (viewModel != null)
            {

            }
        }
    }
}
