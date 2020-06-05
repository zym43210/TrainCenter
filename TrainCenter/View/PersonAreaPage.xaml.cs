using System.Windows;
using System.Windows.Controls;
using TrainCenter.ViewModel;

namespace TrainCenter.View
{
    public partial class PersonAreaPage : Page
    {
        PersonAreaViewModel personAreaViewModel = new PersonAreaViewModel();

        public PersonAreaPage()
        {
            InitializeComponent();
            DataContext = personAreaViewModel;
        }

        private void saveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            personAreaViewModel.ChangeDataOfUser();
        }

        private void deleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            personAreaViewModel.DeleteUser();
        }

        private void imageButton_Click(object sender, RoutedEventArgs e)
        {
            personAreaViewModel.LoadImageFromFS();
        }
    }
}
