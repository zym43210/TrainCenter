using System.Windows;
using System.Windows.Controls;
using TrainCenter.Model;
using TrainCenter.ViewModel;

namespace TrainCenter.View
{

    public partial class AdminPage : Page
    {
        

        AdminPageViewModel adminPageViewModel = new AdminPageViewModel();

        public AdminPage()
        {
            InitializeComponent();
            DataContext = adminPageViewModel;
            radio1.IsChecked = true;
        }


        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            adminPageViewModel.Accept();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            adminPageViewModel.Delete();
        }

        private void infoButton_Click(object sender, RoutedEventArgs e)
        {
            adminPageViewModel.ShowInfo();
        }

        private void radio1_Checked(object sender, RoutedEventArgs e)
        {
            listBox.ItemsSource = adminPageViewModel.Users;



            infoButton.Visibility = Visibility.Visible;
            OkButton.IsEnabled = true;
        }


    }
}
