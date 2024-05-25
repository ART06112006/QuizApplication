using QuizApplication.Infrastructure;
<<<<<<< Updated upstream
using QuizApplication.ViewModels;
=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            var viewModel = parameter as QuizViewModel;

            if (viewModel != null)
            {

            }
=======
            var window = (QuizSettingsWindow)(AppServiceProvider.ServiceProvider.GetService(typeof(QuizSettingsWindow)));
            window.ShowDialog();
>>>>>>> Stashed changes
        }
    }
}
