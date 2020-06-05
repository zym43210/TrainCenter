using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TrainCenter.Model;
using TrainCenter.Repositories;

namespace TrainCenter.ViewModel
{
    public class GiveTrainProgramPageViewModel : INotifyPropertyChanged
    {
        EFUserRepository userRepository = new EFUserRepository();
        EFTrainProgramRepository trainProgramRepository = new EFTrainProgramRepository();
        string statusMail = "Не выбран пользователь ";

        TimeSpan startTime;
        TimeSpan endTime;
        string statusText = "Не заполнено описание ";
        string statusTitle = "Не заполнено оглавление ";
        string statusStartTime = "Не заполнено время начала ";
        string statusEndTime = "Не заполнено время конца ";
        string info = "";
        string mail = "";
        string text;
        string title;
        private IEnumerable<User> users;
        public ObservableCollection<Abonement> Abonements { get; } = new ObservableCollection<Abonement>();
        public ObservableCollection<Visiting> Visitings { get; } = new ObservableCollection<Visiting>();

        public List<string> Mails { get; } = new List<string>();

        public string Mail
        {
            get => mail;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    mail = value;
                    statusMail = "";
                }
                else
                {
                    statusMail = "Выберите пользователя";
                }
                OnPropertyChanged("Mail");
            }
        }



        public string Text
        {
            get => text;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    text = value;
                    statusText = "";
                }
                else
                {
                    statusText = "Проверьте описание";
                }

                OnPropertyChanged("Text");
            }
        }
        public string Title
        {
            get => title;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    title = value;
                    statusTitle = "";
                }
                else
                {
                    statusTitle = "Проверьте описание оглавления";
                }

                OnPropertyChanged("Title");
            }
        }

        public TimeSpan StartTime
        {
            get => startTime;
            set
            {
                if (TimeSpan.Zero != value)
                {
                    startTime = value;
                    statusStartTime = "";
                }
                else
                {
                    statusStartTime = "Проверьте время начала";
                }

                OnPropertyChanged("StartTime");
            }
        }
        public TimeSpan EndTime
        {
            get => endTime;
            set
            {
                if (TimeSpan.Zero != value)
                {
                    endTime = value;
                    statusEndTime = "";
                }
                else
                {
                    statusEndTime = "Проверьте время конца";
                }

                OnPropertyChanged("EndTime");
            }
        }
        public object SelectedItem { get; set; }

        public string Info
        {
            get => info;
            set
            {
                info = value;
                OnPropertyChanged("Info");
            }
        }
        public GiveTrainProgramPageViewModel()
        {

            users = userRepository.getAllMails();
            foreach (User mail in users)
            {
                Mails.Add(mail.mail);
            }


        }


        public bool AddAbonement()
        {

            if (IsCorrected())
            {

                trainProgramRepository.add(new TrainProgram(userRepository.getByMail(Mail).id, Title, Text, StartTime, EndTime, false));
                return true;
            }
            else
            {
                return false;
            }
        }



        public void clear()
        {
            SelectedItem = null;
        
        }

        bool IsCorrected()
        {

            if (!string.IsNullOrEmpty(statusMail) || userRepository.getByMail(Mail)==null)
            {
                Info = statusMail;
                return false;
            }
            else if (!string.IsNullOrEmpty(statusTitle))
            {
                Info = statusTitle;
                return false;
            }
            else if (!string.IsNullOrEmpty(statusText))
            {
                Info = statusText;
                return false;
            }
            else if (!string.IsNullOrEmpty(statusStartTime))
            {
                Info = statusStartTime;
                return false;
            }
            else if (!string.IsNullOrEmpty(statusEndTime))
            {
                Info = statusEndTime;
                return false;
            }
            else
            {
                return true;
            }
        }






        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
