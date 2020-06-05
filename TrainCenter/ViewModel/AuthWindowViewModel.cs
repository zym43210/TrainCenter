using System.ComponentModel;
using System.Windows.Input;
using TrainCenter.Model;
using TrainCenter.Repositories;
using TrainCenter.View;
using TrainCenter;
namespace TrainCenter.ViewModel
{
    public class AuthWindowViewModel : INotifyPropertyChanged
    {
        EFUserRepository eFUserRepository = new EFUserRepository();
        string password;
        string login;
        string info;
        
        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public string Info
        {
            get => info;
            set
            {
                info = value;
                OnPropertyChanged("Info");
            }
        }

        public bool CompareDataOfUser(string password)
        {
            if (!string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(password))
            {
                User tmp = eFUserRepository.getByMail(Login);
                if (tmp != null)
                {
                    if (User.getHash(password).Equals(tmp.password))
                    {
                        CurrentUser.User = tmp;
                        App.mainWindow = new MainWindow();
                        App.mainWindow.Show();
                        return true;
                    }
                    else
                    {
                        Info = "Проверьте введённые данные";
                        return false;
                    }

                }
                else
                {
                    Info = "Проверьте введённые данные";
                    return false;
                }
            }
            else
            {
                Info = "Не всё ввели";
                return false;
            }
        }





        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
