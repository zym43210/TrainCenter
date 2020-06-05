using TrainCenter.View;
using System.Windows;

namespace TrainCenter
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
   
        public partial class App : Application
        {
            public static AuthWindow authWindow;
            public static MainWindow mainWindow;

            private void Application_Startup(object sender, StartupEventArgs e)
            {
                authWindow = new AuthWindow();
                authWindow.Show();
            }
        }
    
}
