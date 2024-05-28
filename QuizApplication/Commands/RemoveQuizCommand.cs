using Microsoft.Extensions.DependencyInjection;
using QuizApplication.Infrastructure;
using QuizApplication.Models;
using QuizApplication.Services;
using QuizApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuizApplication.Commands
{
    public class RemoveQuizCommand : BaseCommand
    {

        private readonly QuizViewModel _viewModel;
        public RemoveQuizCommand(QuizViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override async void Execute(object? parameter)
        {
            var title = parameter as string;
            var service = (QuizService)AppServiceProvider.ServiceProvider.GetService<QuizService>();

            MessageBoxResult messageBoxResult = MessageBox.Show("Do you want to remove this Quiz ?", "", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if(messageBoxResult == MessageBoxResult.Yes)
            {
                await service.RemoveQuizAsync(title);
                _viewModel.LoadInfo(service);
            }
        }
    }
}
