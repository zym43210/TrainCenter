using System.Windows;
using System.Windows.Input;
using TrainCenter.ViewModel;

namespace TrainCenter.View
{
    public partial class UserViewWindow : Window
    {
        UserViewWindowViewModel userViewWindowViewModel;
        public UserViewWindow(object item)
        {
            InitializeComponent();
            userViewWindowViewModel = new UserViewWindowViewModel(item);
            DataContext = userViewWindowViewModel;
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
