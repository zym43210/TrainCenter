using System.Windows;
using System.Windows.Controls;
using TrainCenter.Model;

using TrainCenter.ViewModel;
namespace TrainCenter.View
{
    /// <summary>
    /// Логика взаимодействия для AllTrainings.xaml
    /// </summary>
    public partial class AllTrainings : Page
    {
        
        public AllTrainProgramViewModel viewModel;

        public AllTrainings()
        {
            InitializeComponent();
            viewModel = new AllTrainProgramViewModel();
            DataContext = viewModel;
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.ShowInfo();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Search();
        }


    }
}

