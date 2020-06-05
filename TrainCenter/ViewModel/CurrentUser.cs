using System.ComponentModel;
using TrainCenter.Model;

namespace TrainCenter
{
    public class CurrentUser : INotifyPropertyChanged
    {
        string name;

        public static User User { get; set; }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public static bool isAdmin()
        {
            if (User.privilege.Equals("admin"))
            {
                return true;
            }

            return false;
        }
        public static bool isModerator()
        {
            if (User.privilege.Equals("moder"))
            {
                return true;
            }

            return false;
        }

        public static int getId()
        {

            return User.id;
        }
        public override string ToString()
        {
            return User.FirstName + " " + User.SecondName;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
