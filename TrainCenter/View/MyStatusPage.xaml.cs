using System.Windows;
using System.Windows.Controls;
using TrainCenter.ViewModel;
namespace TrainCenter.View
{
    /// <summary>
    /// Логика взаимодействия для MyStatusPage.xaml
    /// </summary>
    public partial class MyStatusPage : Page
    {
        public MyStatusPage()
        {
            InitializeComponent();
            DataContext = myStatusPageViewModel;

        }

        MyStatusPageViewModel myStatusPageViewModel = new MyStatusPageViewModel();



        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (myStatusPageViewModel.CountTrain() >= myStatusPageViewModel.TotalNumber() || !myStatusPageViewModel.IsAvaible())
            {
                myStatusPageViewModel.AddAlert("Занятия по абонементу кончились");
            }
            else
            {
                myStatusPageViewModel.AddTrain();
            }
        }


        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            myStatusPageViewModel.Update();
        }


    }
}

