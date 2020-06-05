using System.Collections.ObjectModel;
using System.ComponentModel;
using TrainCenter.Model;
using TrainCenter.Repositories;
using TrainCenter.View;

namespace TrainCenter.ViewModel
{
    public class AdminPageViewModel : INotifyPropertyChanged
    {
        EFUserRepository userRepository = new EFUserRepository();
        EFVisitingRepository visitingRepository = new EFVisitingRepository();
        EFAbonementRepository abonementRepository = new EFAbonementRepository();
        EFTrainProgramRepository trainProgramRepository = new EFTrainProgramRepository();

        ObservableCollection<User> tmpUsers = new ObservableCollection<User>();
        ObservableCollection<TrainProgram> tmpTrainPrograms = new ObservableCollection<TrainProgram>();
        ObservableCollection<Abonement> tmpAbonements = new ObservableCollection<Abonement>();
        ObservableCollection<Visiting> tmpVisitings = new ObservableCollection<Visiting>();


        object selectedItem;
        string message;

        public object SelectedItem
        {
            get => selectedItem;
            set
            {
                if (value != null)
                {
                    selectedItem = value;
                }

                OnPropertyChanged("SelectedItem");
            }
        }

        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }

        public ObservableCollection<User> Users
        {
            get
            {
                selectedItem = null;
                return tmpUsers;
            }
        }
        public ObservableCollection<Abonement> Abonements
        {
            get
            {
                selectedItem = null;
                return tmpAbonements;
            }
        }
        public ObservableCollection<Visiting> Visitings
        {
            get
            {
                selectedItem = null;
                return tmpVisitings;
            }
        }
        public ObservableCollection<TrainProgram> TrainPrograms
        {
            get
            {
                selectedItem = null;
                return tmpTrainPrograms;
            }
        }



        public AdminPageViewModel()
        {
            Update();
        }

        public void Update()
        {
            tmpUsers.Clear();


            foreach (User user in userRepository.getAll())
            {
                if (user.id != CurrentUser.User.id)
                {
                    tmpUsers.Add(user);
                }
            }


        }



        public void Accept()
        {
            if (SelectedItem is User)
            {
                if (CurrentUser.isAdmin())
                {


                    if ((SelectedItem as User).privilege.Equals("user"))
                    {
                        userRepository.changePrivelege((SelectedItem as User), "moder");
                    }
                    else if ((SelectedItem as User).privilege.Equals("moder"))
                    {
                        userRepository.changePrivelege((SelectedItem as User), "user");
                    }

                    AlertWindow alertWindow = new AlertWindow($"Пользователь {(SelectedItem as User).firstName} {(SelectedItem as User).secondName} теперь {(SelectedItem as User).privilege}");
                    alertWindow.ShowDialog();
                }
                else
                {
                    AlertWindow alertWindow = new AlertWindow("У вас недостаточно прав для совершения данного действия");
                    alertWindow.ShowDialog();
                }

            }

            else
            {
                AlertWindow alertWindow = new AlertWindow($"Выберите объект");
                alertWindow.ShowDialog();
            }

            Update();
        }

        void DeleteUser(User user)
        {
            foreach (TrainProgram trainProgram in trainProgramRepository.getByPersonId(user.id))
            {
                trainProgramRepository.delete(trainProgram);
            }

            foreach (Abonement abonement in abonementRepository.getManyByPersonId(user.id))
            {
                foreach (Visiting visiting in visitingRepository.getByAbonementId(abonement.id))
                {
                    visitingRepository.delete(visiting);
                }
            }

            foreach (Abonement abonement in abonementRepository.getManyByPersonId(user.id))
            {
                abonementRepository.delete(abonement);
            }

            userRepository.delete(user);
        }

        public void Delete()
        {
            if (SelectedItem is User)
            {
                if (CurrentUser.isAdmin())
                {
                    DialogWindow dialogWindow = new DialogWindow
                    {
                        DataContext = this
                    };
                    Message = $"Уверены, что хотите удалить пользователя {(SelectedItem as User).firstName} {(SelectedItem as User).secondName}?";
                    dialogWindow.ShowDialog();
                    if (dialogWindow.DialogResult == true)
                    {
                        DeleteUser(SelectedItem as User);
                    }
                }
                else
                {
                    AlertWindow alertWindow = new AlertWindow("У вас недостаточно прав для совершения данного действия");
                    alertWindow.ShowDialog();
                }

            }
            else
            {
                AlertWindow alertWindow = new AlertWindow($"Выберите объект");
                alertWindow.ShowDialog();
            }

            Update();

        }

        public void ShowInfo()
        {
            if (SelectedItem != null)
            {
                if (SelectedItem is User)
                {
                    UserViewWindow userViewWindow = new UserViewWindow(SelectedItem);
                    userViewWindow.ShowDialog();
                }

            }

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
