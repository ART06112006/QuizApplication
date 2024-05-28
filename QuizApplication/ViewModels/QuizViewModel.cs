using Microsoft.EntityFrameworkCore.ChangeTracking;
using QuizApplication.Commands;
using QuizApplication.Models;
using QuizApplication.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms.Design;
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

        private List<string> _quizList;
        public List<string> QuizList
        {
            get { return _quizList; }
            set
            {
                _quizList = value;
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

            var incorrectQuestions = new List<Answer>(CurrentQuestion.IncorrectAnswers);
            var questionList = new List<string>();

            foreach (var item in incorrectQuestions)
            {
                questionList.Add(item.Text);
            }

            Answers = new List<string>(questionList) { Questions[0].CorrectAnswer };
        }

        public void SwitchQuestion(Question questions)
        {
            Random random= new Random();
            CurrentQuestion = questions;
            var incorrectQuestions = new List<Answer>(CurrentQuestion.IncorrectAnswers);
            var questionList = new List<string>();

            foreach(var item in incorrectQuestions)
            {
                questionList.Add(item.Text);
            }

            var answers = new List<string>(questionList) { CurrentQuestion.CorrectAnswer };
            answers.Insert(random.Next(4), CurrentQuestion.CorrectAnswer);
            Answers = new List<string>(answers);
        }

        public QuizViewModel(ChangeQuizSettingsWindowCommand changeQuizSettingsWindow,
            ChooseAnswerCommand chooseAnswerCommand, QuizService quizService)
        {
            StartQuiz = changeQuizSettingsWindow;
            ChooseAnswerCommand = chooseAnswerCommand;
            RemoveQuizCommand = new RemoveQuizCommand(this);
            LoadQuizCommand = new LoadQuizCommand(this);
            LoadInfo(quizService);
        }

        public async void LoadInfo(QuizService quizService)
        {
            QuizList = new List<string>(await quizService.GetQuizNamesAsync());
        }

        public ICommand StartQuiz { get; set; }
        public ICommand ChooseAnswerCommand { get; set; }
        public ICommand RemoveQuizCommand { get; set; }
        public ICommand LoadQuizCommand { get; private set; }
    }
}
