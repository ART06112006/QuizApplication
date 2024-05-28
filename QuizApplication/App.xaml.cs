using Microsoft.Extensions.DependencyInjection;
using QuizApplication.Infrastructure;
using QuizApplication.Services;
using QuizApplication.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace QuizApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            AppServiceProvider.Initialize();
            var quizService = AppServiceProvider.ServiceProvider.GetService<QuizService>();
            var aPIQuestionService = AppServiceProvider.ServiceProvider.GetService<APIQuestionService>();
            quizService.ExceptionMessage = x => MessageBox.Show(x, "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            aPIQuestionService.ExceptionMessage = x => MessageBox.Show(x, "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            QuizWindow quizWindow = AppServiceProvider.ServiceProvider.GetService<QuizWindow>();
            quizWindow.Show();
        }
    }

}
