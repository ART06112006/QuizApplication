using QuizApplication.Commands;
using QuizApplication.Models;
using QuizApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
                _qestionLimit = value.ToString();
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

        private List<string> _selectedCategories;
        public List<string> SelectedCategories
        {
            get { return _selectedCategories; }
            set
            {
                _selectedCategories = value;
                OnPropertyChanged();
            }
        }

        public List<string> _selectedDifficulty;
        public List<string> SelectedDifficulty
        {
            get { return _selectedDifficulty; }
            set
            {
                _selectedDifficulty = value;
                OnPropertyChanged();
            }
        }

        private List<string> _qestionLimits;
        public List<string> QuestionLimits
        {
            get { return _qestionLimits; }
            set
            {
                _qestionLimits = value;
                OnPropertyChanged();
            }
        }

        //public QuizViewModel _quizViewModel;

        public Quiz Quiz { get; set; }

        public QuizSettingsViewModel(APIQuestionService apIQuestionService, StartNewQuizCommand startNewQuizCommand)
        {
            _apIQuestionService = apIQuestionService;
            StartQuiz = startNewQuizCommand;
            Categories = new List<string>();
            Difficulty = new List<string>() { "easy", "medium", "hard"};
            QuestionLimits = new List<string>() { "10", "20", "30", "40", "50" };
            SelectedDifficulty = new List<string>();
            SelectedCategories = new List<string>();
            LoadInfo();
        }

        public ICommand StartQuiz { get; set; }
        public Action Close { get; set; }

        private async void LoadInfo()
        {
            Categories = await _apIQuestionService.GetCategoriesAsync();
        }
    }
}
