using QuizApplication.Infrastructure;
using QuizApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuizApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppServiceProvider.Initialize();
            Do();
        }
        private async void Do()
        {
            var service = (APIQuestionService)AppServiceProvider.ServiceProvider.GetService(typeof(APIQuestionService));
            await service.GetQuizAsync("fgdg", 50, new List<string>() { "easy", "hard" }, await service.GetCategoriesAsync());
        }
    }
}
