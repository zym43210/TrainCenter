using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Windows.Media.Imaging;
using TrainCenter.Model;
using TrainCenter.Repositories;
using TrainCenter.View;

namespace TrainCenter.ViewModel
{
    public class PersonAreaViewModel : INotifyPropertyChanged
    {
        User user = CurrentUser.User;
        EFUserRepository userRepository = new EFUserRepository();
        EFVisitingRepository visitingRepository = new EFVisitingRepository();
        EFAbonementRepository abonementRepository = new EFAbonementRepository();
        EFTrainProgramRepository trainProgramRepository = new EFTrainProgramRepository();

        string firstName;
        string secondName;
        string mail;
        string telNumber;
        string about;

        BitmapImage bitmap = new BitmapImage();
        string bitmapImage = "";
        string message;



        public BitmapImage BitmapImage
        {
            get => bitmap;
            set
            {
                bitmap = value;
                OnPropertyChanged("BitmapImage");
            }
        }

        public PersonAreaViewModel()
        {
            firstName = user.firstName;
            secondName = user.secondName;
            mail = user.mail;
            telNumber = user.telNumber;
            about = user.about;
            BitmapImage = LoadPhoto(user.id);
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    firstName = value;
                }

                OnPropertyChanged("FirstName");
            }
        }
        public string SecondName
        {
            get => secondName;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    secondName = value;
                }

                OnPropertyChanged("SecondName");
            }
        }

        public string Mail
        {
            get => mail;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    mail = value;
                }

                OnPropertyChanged("Main");
            }
        }
        public string TelNumber
        {
            get => telNumber;
            set
            {
                telNumber = value;
                OnPropertyChanged("TelNumber");
            }
        }
        public string About
        {
            get => about;
            set
            {
                about = value;
                OnPropertyChanged("About");
            }
        }
        public string BitImage
        {
            get => bitmapImage;
            set
            {
                bitmapImage = value;
                OnPropertyChanged("BitImage");
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

        public BitmapImage LoadPhoto(int person)
        {
            BitmapImage bitmapImage = new BitmapImage();

            if (userRepository.getById(person).image != null)
            {
                using (var ms = new MemoryStream(userRepository.getById(person).image))
                {
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = ms;
                    bitmapImage.EndInit();
                }
            }
            return bitmapImage;
        }

        public void LoadImageFromFS()
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Filter = "JPG (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp|Png (*.png)|*.png"
            };
            if (open.ShowDialog() == true)
            {
                string fileName = open.FileName;
                if (File.Exists(fileName))
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                    {
                        byte[] image = new byte[fs.Length];
                        fs.Read(image, 0, image.Length);
                        userRepository.update(user, new User(CurrentUser.User.FirstName, CurrentUser.User.SecondName, CurrentUser.User.Mail, CurrentUser.User.TelNumber, CurrentUser.User.About, image));
                        BitmapImage = LoadPhoto(user.id);
                    }
                }
            }
            else
            {
                return;
            }
        }



        public void ChangeDataOfUser()
        {
            if (User.IsValidEmail(Mail)){
                User tmp = new User(FirstName, SecondName, Mail, TelNumber, About, CurrentUser.User.image, user.privilege);

                userRepository.update(user, tmp);
                CurrentUser.User = userRepository.getByMail(Mail);

                AlertWindow alertWindow = new AlertWindow($"Изменения сохранены");
                alertWindow.ShowDialog();
                LoadPhoto(CurrentUser.User.id);
            }
            else
            {
                AlertWindow alertWindow = new AlertWindow($"Неправильно введена почта");
                alertWindow.ShowDialog();
                LoadPhoto(CurrentUser.User.id);
            }

          
        }

        
        public void DeleteUser()
        {
            View.DialogWindow dialogWindow = new View.DialogWindow
            {
                DataContext = this
            };
            Message = $"Уверены, что хотите удалить пользователя {CurrentUser.User.FirstName} {CurrentUser.User.FirstName}?";
            dialogWindow.ShowDialog();
            if (dialogWindow.DialogResult == true)
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

                App.mainWindow.Close();
                userRepository.delete(CurrentUser.User);
                App.authWindow = new AuthWindow();
                App.authWindow.Show();
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
