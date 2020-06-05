using System.Windows;
using System.Windows.Input;

namespace TrainCenter.View
{
    /// <summary>
    /// Логика взаимодействия для AlertWindow.xaml
    /// </summary>
    public partial class AlertWindow : Window
    {
        public string Message { get; }

        public AlertWindow()
        {
            InitializeComponent();
            Title = "Сообщение";
        }
        public AlertWindow(string message)
        {
            InitializeComponent();
            DataContext = this;
            Message = message;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
