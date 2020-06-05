using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TrainCenter.ViewModel;
namespace TrainCenter.View
{
    /// <summary>
    /// Логика взаимодействия для GiveAbonementsPage.xaml
    /// </summary>
    public partial class GiveTrainProgramPage : Page
    {

        GiveTrainProgramPageViewModel GiveTrainProgramPageViewModel = new GiveTrainProgramPageViewModel();
        public GiveTrainProgramPage()
        {
            InitializeComponent();
            DataContext = GiveTrainProgramPageViewModel;

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void give_Click(object sender, RoutedEventArgs e)
        {
            if (GiveTrainProgramPageViewModel.AddAbonement())
            {

                
                addButton.Background = Brushes.Green;
                GiveTrainProgramPageViewModel.clear();
                MailText.SelectedIndex = -1;
                TitleText.Clear();
                TextText.Clear();
                

            }
            else
            {
                addButton.Background = Brushes.PaleVioletRed;
            }
        }
    }
}

