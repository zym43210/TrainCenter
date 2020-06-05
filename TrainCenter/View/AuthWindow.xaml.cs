using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TrainCenter.ViewModel;


namespace TrainCenter.View
{

    public partial class AuthWindow : Window
    {
        AuthWindowViewModel authWindowViewModel;

        public AuthWindow()
        {
            InitializeComponent();
            authWindowViewModel = new AuthWindowViewModel();
            DataContext = authWindowViewModel;
            Title = "Авторизация";

        }
     
        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GridBarTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void collapseClose_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void authButton_Click(object sender, RoutedEventArgs e)
        {
            if (authWindowViewModel.CompareDataOfUser(passwordBox.Password))
            {
                Close();
            }
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();

        }

        private void mailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(mailTextBox.Text))
            {
                mailTextBox.BorderBrush = Brushes.Red;
            }
            else
            {
                mailTextBox.BorderBrush = Brushes.LimeGreen;
            }
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(passwordBox.Password))
            {
                passwordBox.BorderBrush = Brushes.Red;
            }
            else
            {
                passwordBox.BorderBrush = Brushes.LimeGreen;
            }
        }



    }
}
