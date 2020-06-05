using System.Windows;
using System.Windows.Media;
using TrainCenter.ViewModel;

namespace TrainCenter.View
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddMyTrainWindow : Window
    {
        AddMyTrainWindowViewModel addMyTrainWindowViewModel = new AddMyTrainWindowViewModel();

        public AddMyTrainWindow()
        {
            InitializeComponent();
            DataContext = addMyTrainWindowViewModel;
            Title = "Добавление занятия";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {

            if (!addMyTrainWindowViewModel.AddMyTrain())
            {
                addButton.Background = Brushes.PaleVioletRed;
            }
            else
            {
                addButton.Background = Brushes.LimeGreen;
                Close();

            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            addMyTrainWindowViewModel.Clear();
            addButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF464648"));
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
