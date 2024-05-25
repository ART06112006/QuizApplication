using Microsoft.Extensions.DependencyInjection;
using QuizApplication.Infrastructure;
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
            QuizWindow quizWindow = AppServiceProvider.ServiceProvider.GetService<QuizWindow>();
            quizWindow.Show();
        }
    }

}
