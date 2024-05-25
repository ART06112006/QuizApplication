using QuizApplication.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizApplication.ViewModels
{
    public class QuizViewModel : BaseViewModel
    {
        public QuizViewModel(ChangeQuizSettingsWindowCommand changeQuizSettingsWindow)
        {
            StartQuiz = changeQuizSettingsWindow;
        }

        public ICommand StartQuiz { get; set; }
    }
}
