using QuizApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace QuizApplication.Views
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    /// 
    public partial class QuizWindow : Window
    {
        public QuizViewModel QuizViewModel { get; set; }
        public QuizWindow(QuizViewModel quizViewModel)
        {
            InitializeComponent();
            DataContext = quizViewModel;
            QuizViewModel= quizViewModel;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;

            if (radioButton.Content != null)
            {
                QuizViewModel.SelectedAnswers = radioButton.Content.ToString();
                radioButton.IsChecked = false;
            }
            else
            {
                MessageBox.Show("Please press \"Start new Quiz\" to start");
                radioButton.IsChecked = false;
            }
        }

    }
}
