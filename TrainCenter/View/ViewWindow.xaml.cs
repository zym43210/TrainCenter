using System.Windows;
using System.Windows.Input;
using TrainCenter.ViewModel;

namespace TrainCenter.View
{
    public partial class ViewWindow : Window
    {
        AllTrainProgramViewModel mainViewModel;

        public ViewWindow(AllTrainProgramViewModel viewModel)
        {
            InitializeComponent();
            mainViewModel = viewModel;
            DataContext = mainViewModel.SelectedItem;
            counter.DataContext = mainViewModel;

            Title = "Окно просмотра";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.Accept();
            Hide();
            
        }
        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.PreviousItem();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.NextItem();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
