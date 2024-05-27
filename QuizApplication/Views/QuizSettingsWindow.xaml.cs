using QuizApplication.ViewModels;
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

namespace QuizApplication.Views
{
    /// <summary>
    /// Interaction logic for QuizSettingsWindow.xaml
    /// </summary>
    public partial class QuizSettingsWindow : Window
    {
        public QuizSettingsViewModel _quizSettingsViewModel;

        public QuizSettingsWindow(QuizSettingsViewModel quizSettingsViewModel)
        {
            InitializeComponent();
            DataContext = quizSettingsViewModel;
            _quizSettingsViewModel = quizSettingsViewModel;
            _quizSettingsViewModel.Close = () => { this.Close(); };
        }

        private void CategoriesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var category in CategoriesListBox.Items)
            {
                if (category == CategoriesListBox.SelectedItem.ToString())
                {
                    _quizSettingsViewModel.SelectedCategories.Add(category.ToString());
                    break;
                }
            }
            
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var category in DifficultyListBox.Items)
            {
                if (category == DifficultyListBox.SelectedItem.ToString())
                {
                    _quizSettingsViewModel.SelectedDifficulty.Add(category.ToString());
                    break;
                }
            }
        }
    }
}
