using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TrainCenter.Model;
using TrainCenter.Repositories;

namespace TrainCenter.ViewModel
{
    public class GiveAbonementsPageViewModel : INotifyPropertyChanged
    {
        EFUserRepository userRepository = new EFUserRepository();
        EFAbonementRepository abonementRepository = new EFAbonementRepository();
        string statusMail = "Не выбран пользователь ";



        string info = "";
        string mail = "";
        int trainingNumber = 1;
        DateTime endDate =  DateTime.Now;
        private IEnumerable<User> users;
        public ObservableCollection<Abonement> Abonements { get; } = new ObservableCollection<Abonement>();
        public ObservableCollection<Visiting> Visitings { get; } = new ObservableCollection<Visiting>();

        public List<string> Mails { get; } = new List<string>();

        public string Mail
        {
            get => mail;
            set
            {
                if (!string.IsNullOrEmpty(value) || userRepository.getByMail(value) != null)
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

        public DateTime EndDate
        {
            get => endDate;
            set
            {

                endDate = value;


                OnPropertyChanged("EndDate");
            }
        }
        public int TrainingsNumber
        {
            get => trainingNumber;
            set
            {
                trainingNumber = value;
                OnPropertyChanged("TrainingsNumber");
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
        public GiveAbonementsPageViewModel()
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

                abonementRepository.add(new Abonement(userRepository.getByMail(Mail).id, TrainingsNumber, EndDate));
                return true;
            }
            else
            {
                return false;
            }
        }


        public void clear()
        {
            mail = "";
            
            endDate = DateTime.Now;
            Mail = "";
            trainingNumber = 1;
            EndDate = DateTime.Now;

        }

        bool IsCorrected()
        {
            if (!string.IsNullOrEmpty(statusMail) || userRepository.getByMail(Mail) == null)
            {
                Info = statusMail;
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
