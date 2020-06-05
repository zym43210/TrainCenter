using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TrainCenter.Model;
using TrainCenter.Repositories;
using TrainCenter.View;

namespace TrainCenter.ViewModel
{
    public class MyStatusPageViewModel : INotifyPropertyChanged
    {

        EFAbonementRepository abonementRepository = new EFAbonementRepository();
        EFVisitingRepository visitingRepository = new EFVisitingRepository();
        string info = "";
        public ObservableCollection<Abonement> Abonements { get; } = new ObservableCollection<Abonement>();
        public ObservableCollection<Visiting> Visitings { get; } = new ObservableCollection<Visiting>();





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
        public MyStatusPageViewModel()
        {
            
            if (IsAvaible())
            {
                Info = $"У вас посещено {CountTrain()} занятий из {abonementRepository.getByPersonId(CurrentUser.User.id).TrainigsNumber}";
            }
            else
            {
                Info = $"У вас нет активных абонементов";
            }

            Update();
        }
        public bool IsAvaible()
        {
            if (abonementRepository.getByPersonId(CurrentUser.User.id) != null && abonementRepository.getByPersonId(CurrentUser.User.id).EndDate > DateTime.Now)
            {
                return true;
            }
            else
                return false;
        }
        public int TotalNumber()
        {
            if (abonementRepository.getByPersonId(CurrentUser.User.id) != null)
            {
                return (int)abonementRepository.getByPersonId(CurrentUser.User.id).TrainigsNumber;
            }
            else
            {
                return 0;
            }

        }
        public int CountTrain()
        {
            int numberTr = 0;

            if (abonementRepository.getByPersonId(CurrentUser.User.id) != null)
            {
                foreach (Visiting visiting in visitingRepository.getByAbonementId((abonementRepository.getByPersonId(CurrentUser.User.id)).id))
                {
                    numberTr++;

                }

                return numberTr;

            }
            else
            {
                return 0;
            }

        }

        public void Update()
        {

            Abonements.Clear();
            Visitings.Clear();
            if (IsAvaible())
            {
                foreach (Visiting visiting in visitingRepository.getByAbonementId((abonementRepository.getByPersonId(CurrentUser.User.id)).id))
                {

                    Visitings.Add(visiting);
                }



            }


            if (IsAvaible())
            {
                Info = $"У вас посещено {CountTrain()} занятий из {abonementRepository.getByPersonId(CurrentUser.User.id).TrainigsNumber}";
            }
            else
            {
                Info = $"У вас нет активных абонементов";
            }
        }


        public void AddTrain()
        {
            AddMyTrainWindow addWindow = new AddMyTrainWindow();
            addWindow.ShowDialog();
        }

        public void AddAlert(string text)
        {
            AlertWindow alertWindow = new AlertWindow(text);
            alertWindow.ShowDialog();
        }



        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
