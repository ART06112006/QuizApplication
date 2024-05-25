using QuizApplication.Infrastructure;
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
        }
    }
}
