using QuizApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.ViewModels
{
    public class QuizSettingsViewModel : BaseViewModel
    {
        private APIQuestionService _apIQuestionService;

        private List<string> _categories;
        public List<string> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        private List<string> _difficulty;
        public List<string> Difficulty
        {
            get { return _difficulty; }
            set
            {
                _difficulty = value;
                OnPropertyChanged();
            }
        }

        private string _qestionLimit;
        public string QuestionLimit
        {
            get { return _qestionLimit; }
            set
            {
                _qestionLimit = value;
                OnPropertyChanged();
            }
        }

        private string _quizName;
        public string QuizName
        {
            get { return _quizName; }
            set
            {
                _quizName = value;
                OnPropertyChanged();
            }
        }

        public QuizSettingsViewModel(APIQuestionService apIQuestionService)
        {
            _apIQuestionService = apIQuestionService;
            Categories = new List<string>();
            Difficulty = new List<string>() { "easy", "medium", "hard"};
            LoadInfo();
        }

        private async void LoadInfo()
        {
            Categories = await _apIQuestionService.GetCategoriesAsync();
        }
    }
}
