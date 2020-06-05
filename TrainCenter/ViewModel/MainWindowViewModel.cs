using System.ComponentModel;
using TrainCenter.View;

namespace TrainCenter.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        int selectedIndex;
        object content;
        string userName;
        string firstSymbols;

        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                selectedIndex = value;
                setPage(selectedIndex);
                OnPropertyChanged("SelectedIndex");
            }
        }
        public object Content
        {
            get => content;
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }

        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string FirstSymbols
        {
            get => firstSymbols;
            set
            {
                firstSymbols = CurrentUser.User.firstName.Substring(0, 1) + CurrentUser.User.secondName.Substring(0, 1);
                OnPropertyChanged("FirstSymbols");
            }
        }

        public MainWindowViewModel()
        {
            Content = new AllTrainings();
            UserName = CurrentUser.User.firstName + " " + CurrentUser.User.secondName;
            FirstSymbols = CurrentUser.User.firstName.Substring(0, 1) + CurrentUser.User.secondName.Substring(0, 1);
            SelectedIndex = 0;
        }

        public void setPage(int index)
        {
            switch (index)
            {
                case 0:
                    if (CurrentUser.isAdmin() || CurrentUser.isModerator())
                    {
                        Content = new GiveTrainProgramPage();
                    }
                    else
                    {
                        Content = new AllTrainings();
                    }

                    break;
                case 1:
                    if (CurrentUser.isAdmin() || CurrentUser.isModerator())
                    {
                        Content = new GiveAbonementsPage();
                    }
                    else
                    {
                        Content = new MyStatusPage();
                    }

                    break;
                case 2:
                    Content = new PersonAreaPage();
                    break;
                case 3:
                    {
                        if (CurrentUser.isAdmin() || CurrentUser.isModerator())
                        {
                            Content = new AdminPage();
                        }
                        else
                        {
                            AlertWindow alertWindow = new AlertWindow("У вас нет прав зайти в это меню");
                            alertWindow.ShowDialog();
                        }

                        break;

                    }
                default:
                    Content = new AllTrainings();
                    break;
            }

        }

        public void Update()
        {
            FirstSymbols = CurrentUser.User.firstName.Substring(0, 1) + CurrentUser.User.secondName.Substring(0, 1);
            UserName = CurrentUser.User.ToString();
        }

        public void OutFromMain()
        {
            CurrentUser.User = null;
            App.authWindow = new AuthWindow();
            App.authWindow.Show();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
