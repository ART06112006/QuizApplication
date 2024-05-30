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
                    if (!_quizSettingsViewModel.SelectedCategories.Contains(category))
                    {
                        _quizSettingsViewModel.SelectedCategories.Add(category.ToString());
                        selectedListBox.Items.Add(category);
                        break;
                    }
                    else
                    {
                        MessageBox.Show("This category is added");
                    }
                }
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var category in DifficultyListBox.Items)
            {
                if (category == DifficultyListBox.SelectedItem.ToString())
                {
                    if (!_quizSettingsViewModel.SelectedDifficulty.Contains(category))
                    {
                        _quizSettingsViewModel.SelectedDifficulty.Add(category.ToString());
                        selectedDiffListBox.Items.Add(category);
                    }
                    else
                    {
                        MessageBox.Show("This item is added");
                    }
                    break;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            selectedListBox.Items.Clear();
            _quizSettingsViewModel.SelectedCategories.Clear();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            selectedDiffListBox.Items.Clear();
            _quizSettingsViewModel.SelectedDifficulty.Clear();
        }

        private void selectedDiffListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selectedDiffListBox.SelectedItem != null)
            {
                _quizSettingsViewModel.SelectedDifficulty.Remove(selectedDiffListBox.SelectedItem.ToString());
                selectedDiffListBox.Items.Remove(selectedDiffListBox.SelectedItem);
            }
        }

        private void selectedListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(selectedListBox.SelectedItem != null)
            {
                _quizSettingsViewModel.SelectedCategories.Remove(selectedListBox.SelectedItem.ToString());
                selectedListBox.Items.Remove(selectedListBox.SelectedItem);
            }
        }
    }
}
