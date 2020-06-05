using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using TrainCenter.Model;
using TrainCenter.Repositories;

namespace TrainCenter.ViewModel
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        EFUserRepository userRepository = new EFUserRepository();

        string firstName;
        string secondName;
        string mail;
        string password1;
        string password2;
        string info;

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string SecondName
        {
            get => secondName;
            set
            {
                secondName = value;
                OnPropertyChanged("SecondName");
            }
        }
        public string Mail
        {
            get => mail;
            set
            {
                mail = value;
                OnPropertyChanged("Mail");
            }
        }
        public string Password1
        {
            get => password1;
            set
            {
                password1 = value;
                OnPropertyChanged("Password1");
            }
        }
        public string Password2
        {
            get => password2;
            set
            {
                password2 = value;
                OnPropertyChanged("Password2");
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

        

    
        public bool Registration(string password1, string password2)
        {
            Password1 = User.getHash(password1);
            Password2 = User.getHash(password2);

            if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(SecondName) && !string.IsNullOrEmpty(Mail) && !string.IsNullOrEmpty(Password1) && !string.IsNullOrEmpty(Password2) && User.IsValidEmail(Mail))
            {
               if(password1.Length>=8 && password2.Length>=8 && password1.Length<=16 && password2.Length <=16)
                {
                    if (Password1.Equals(Password2))
                    {

                        User tmp = userRepository.getByMail(Mail);
                        if (tmp == null)
                        {
                            userRepository.add(new User(FirstName, SecondName, Mail, Password1));
                            Info = "Зареган!";
                            return true;
                        }
                        else
                        {
                            Info = "Пользователь с таким Mail уже есть";
                            return false;
                        }

                    }
                    else
                    {
                        Info = "Пароли должны совпадать";
                        return false;
                    }
                }
                else
                {
                    Info = "Пароль должен быть от 8 до 16 знаков";

                    return false;
                }
                

            }
            else
            {
                Info = "Проверьте данные!";
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

