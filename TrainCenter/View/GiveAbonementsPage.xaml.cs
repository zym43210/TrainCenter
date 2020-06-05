using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TrainCenter.ViewModel;
namespace TrainCenter.View
{
    /// <summary>
    /// Логика взаимодействия для GiveAbonementsPage.xaml
    /// </summary>
    public partial class GiveAbonementsPage : Page
    {
        public GiveAbonementsPage()
        {
            InitializeComponent();
            DataContext = GiveAbonementsPageViewModel;

        }

        GiveAbonementsPageViewModel GiveAbonementsPageViewModel = new GiveAbonementsPageViewModel();

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void give_Click(object sender, RoutedEventArgs e)
        {
            if (GiveAbonementsPageViewModel.AddAbonement())
            {

                GiveAbonementsPageViewModel.clear();
                addButton.Background = Brushes.Green;
            }
            else
            {
                addButton.Background = Brushes.PaleVioletRed;
            }
        }
    }
}

