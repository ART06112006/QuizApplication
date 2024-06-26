﻿using QuizApplication.Infrastructure;
using QuizApplication.Services;
using QuizApplication.ViewModels;
using QuizApplication.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuizApplication.Commands
{
    public class StartNewQuizCommand : BaseCommand
    {
        public override async void Execute(object? parameter)
        {
            var viewModel = parameter as QuizSettingsViewModel;

            if (viewModel.SelectedCategories.Count != 0 && viewModel.SelectedDifficulty.Count != 0 && viewModel.QuestionLimit != null && viewModel.QuizName != null)
            {
                if (viewModel != null)
                {
                    var apiQuestionService = (APIQuestionService)(AppServiceProvider.ServiceProvider.GetService(typeof(APIQuestionService)));
                    var quiz = await apiQuestionService.GetQuizAsync(viewModel.QuizName, int.Parse(viewModel.QuestionLimit.ToString()), viewModel.SelectedDifficulty, viewModel.SelectedCategories);

                    if (quiz != null)
                    {
                        var quizService = (QuizService)(AppServiceProvider.ServiceProvider.GetService(typeof(QuizService)));
                        await quizService.AddQuizAsync(quiz);

                        viewModel.Quiz = quiz;
                        viewModel.Close.Invoke();
                    }
                }
            }
            else
            {
                MessageBox.Show("Input all fields");
            }
        }
    }
}
