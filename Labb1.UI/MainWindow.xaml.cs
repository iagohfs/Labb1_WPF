using System;
using System.Windows;
using Labb1.UI.ViewModel;

namespace Labb1.UI
{
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            Loaded += MainWindow_Loaded;
            Save.IsEnabled = false;
            AddDayButton.IsEnabled = false;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.Load();
            DayComboBox.SelectedIndex += 1;
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (ActivityTextBox.Text != _viewModel.CurrentText(ActivityTextBox.Text))
            {
                Save.IsEnabled = true;
            }
            else
                Save.IsEnabled = false;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Save.IsEnabled = false;
            _viewModel.SaveChangedText(ActivityTextBox.Text, DayComboBox.SelectedIndex);
        }

        private void DayInputTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (AddDayButton != null)
                AddDayButton.IsEnabled = true;
        }

        private void AddDayButton_Click(object sender, RoutedEventArgs e)
        {
            // First
            _viewModel.AddNewDay(DayInputTextBox.Text);

            // Second
            DayComboBox.Text = "Enter day here";

            // Last
            int tempIndex = (DayComboBox.Items.Count - 1);
            DayComboBox.SelectedIndex = tempIndex;

            AddDayButton.IsEnabled = false;
        }

        private void WeekComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DayComboBox.SelectedIndex = 0;
        }

        private void RemoveDayButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.RemoveSelectedDay();
            DayComboBox.SelectedIndex = 0;
        }
    }
}
