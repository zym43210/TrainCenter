using System;
using System.ComponentModel;
using TrainCenter.Model;
using TrainCenter.Repositories;
namespace TrainCenter.ViewModel
{
    public class AddMyTrainWindowViewModel : INotifyPropertyChanged
    {

        EFVisitingRepository visitingRepository = new EFVisitingRepository();
        EFAbonementRepository abonementRepository = new EFAbonementRepository();


        string commentary;
        TimeSpan startTime;
        TimeSpan endTime;

        string info;


        string statusCommentary = "Не заполнен комментарий ";
        string statusStartTime = "Не заполнено время начала ";
        string statusEndTime = "Не заполнено время конца ";





        public string Commentary
        {
            get => commentary;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    commentary = value;
                    statusCommentary = "";
                }
                else
                {
                    statusCommentary = "Проверьте комментарий";
                }

                OnPropertyChanged("Commentary");
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


        public string Info
        {
            get => info;
            set
            {
                info = value;
                OnPropertyChanged("Info");
            }
        }



        public AddMyTrainWindowViewModel()
        {

        }

        bool IsCorrected()
        {

            if (!string.IsNullOrEmpty(statusCommentary))
            {
                Info = statusCommentary;
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

        public bool AddMyTrain()
        {
            if (IsCorrected())
            {
                visitingRepository.add(new Visiting(abonementRepository.getByPersonId(CurrentUser.User.id).id, Commentary, StartTime, EndTime));
                return true;
            }
            return false;
        }

        public void Clear()
        {
             commentary="";
             startTime = new TimeSpan(0, 0, 0);
            endTime = new TimeSpan(0, 0, 0);
            Commentary = "";
            StartTime = new TimeSpan(0, 0, 0);
            EndTime = new TimeSpan(0, 0, 0);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}