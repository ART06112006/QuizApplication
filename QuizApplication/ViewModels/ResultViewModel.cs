using QuizApplication.Commands;
using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizApplication.ViewModels
{
    public class ResultViewModel : BaseViewModel
    {
        private Quiz _quiz;
        public Quiz Quiz
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

        public void CheckAnswers(ObservableCollection<Question> Questions)
        {
            var questions = new ObservableCollection<Question>();
            //foreach (var item in Questions)
            //{
            //    if (item.UserAnswer == item.CorrectAnswer)
            //    {
            //        item.UserAnswer += " -- correct";
            //    }
            //    else
            //    {
            //        item.UserAnswer += " -- incorrect";
            //        //questions.Add(item.UserAnswer);
            //    }
            //}

            for(int i=0; i < Questions.Count; i++)
            {
                if (Questions[i].UserAnswer == Questions[i].CorrectAnswer)
                {
                    Questions[i].UserAnswer += " -- correct";
                    questions.Add(Questions[i]);
                }
                else
                {
                    Questions[i].UserAnswer += " -- incorrect";
                    questions.Add(Questions[i]);
                }
            }

            this.Questions = new ObservableCollection<Question>(questions);
        }

        public ResultViewModel(ShowResultCommand showResult)
        {
            ShowResultCommand = showResult;
        }

        public ICommand ShowResultCommand { get; set; }
    }
}
