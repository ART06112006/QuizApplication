using Microsoft.EntityFrameworkCore.ChangeTracking;
using QuizApplication.Commands;
using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuizApplication.ViewModels
{
    public class QuizViewModel : BaseViewModel
    {
        private Quiz _quiz;
        public Quiz MyQuiz
        {
            get { return _quiz; }
            set
            {
                _quiz = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Question> _questions;
        public ObservableCollection<Question> Questions
        {
            get { return _questions; }
            set
            {
                _questions = value;
                OnPropertyChanged();
            }
        }

        private Question _currentQuestion;
        public Question CurrentQuestion
        {
            get { return _currentQuestion; }
            set
            {
                _currentQuestion = value; 
                OnPropertyChanged();
            }
        }

        private List<string> _answers;
        public List<string> Answers
        {
            get { return _answers; }
            set
            {
                _answers = value;
                OnPropertyChanged();
            }
        }

        private string _selectedAnswer;
        public string SelectedAnswers
        {
            get { return _selectedAnswer; }
            set
            {
                _selectedAnswer = value;
                OnPropertyChanged();
            }
        }

        public void UpdateUI(Quiz quiz)
        {
            MyQuiz = new Quiz();
            MyQuiz = quiz;
            Questions = new ObservableCollection<Question>(MyQuiz.Questions);
            CurrentQuestion = Questions[0];
            Answers = new List<string>(Questions[0].IncorrectAnswers) { Questions[0].CorrectAnswer };
        }

        public void SwitchQuestion(Question questions)
        {
            Random random= new Random();
            CurrentQuestion = questions;
            var answers = new List<string>(CurrentQuestion.IncorrectAnswers) { CurrentQuestion.CorrectAnswer };
            answers.Insert(random.Next(4), CurrentQuestion.CorrectAnswer);
            Answers = new List<string>(answers);
        }

        public QuizViewModel(ChangeQuizSettingsWindowCommand changeQuizSettingsWindow, ChooseAnswerCommand chooseAnswerCommand)
        {
            StartQuiz = changeQuizSettingsWindow;
            ChooseAnswerCommand = chooseAnswerCommand;
        }

        public ICommand StartQuiz { get; set; }

        public ICommand ChooseAnswerCommand { get; set; }
    }
}
