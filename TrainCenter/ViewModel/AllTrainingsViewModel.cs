using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Media.Imaging;
using TrainCenter.Model;
using TrainCenter.Repositories;
using TrainCenter.View;

namespace TrainCenter.ViewModel
{
    public class AllTrainProgramViewModel : INotifyPropertyChanged
    {
        EFUserRepository userRepository = new EFUserRepository();
        EFTrainProgramRepository TrainProgramRepository = new EFTrainProgramRepository();
        TrainProgram selectedItem;


        string category = "";
        string info = "";
        string searchText = "";

        string count;
        string sellerInfo;
        string regionInfo;
        string region;
        int selectedIndex;



        public ObservableCollection<TrainProgram> TrainPrograms { get; set; } = new ObservableCollection<TrainProgram>();
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged("SearchText");
            }
        }
        public TrainProgram SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                if (value != null)
                {
                    Count = (TrainPrograms.IndexOf(SelectedItem) + 1).ToString();
                }

                OnPropertyChanged("SelectedItem");
            }
        }

        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                if (value >= 0)
                {
                    selectedIndex = value;
                }

                OnPropertyChanged("SelectedIndex");
            }
        }

        public List<string> Categories { get; } = new List<string>();





        public string Category
        {
            get => category;
            set
            {
                category = value;
                OnPropertyChanged("Category");
            }
        }
        public string Region
        {
            get => region;
            set
            {
                region = value;
                OnPropertyChanged("Region");
            }
        }
        public string Info
        {
            get => info;
            set
            {
                info = $"Найдено {TrainPrograms.Count} Тренировок";
                OnPropertyChanged("Info");
            }
        }


        public string Count
        {
            get => $"{count} -е  из {TrainPrograms.Count} Тренировок";
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }

        public string SellerInfo
        {
            get => sellerInfo;
            set
            {
                sellerInfo = value;
                OnPropertyChanged("SellerInfo");
            }
        }
        public string RegionInfo
        {
            get => regionInfo;
            set
            {
                regionInfo = value;
                OnPropertyChanged("RegionInfo");
            }
        }

        ViewWindow viewWindow;
        public AllTrainProgramViewModel()
        {

            var trainPrograms = GetTrainPrograms().ToList();
            TrainPrograms.Clear();
            foreach (TrainProgram a in trainPrograms)
            {
                if (a.IsDone == false && a.PersonId == CurrentUser.getId())
                {
                    TrainPrograms.Add(a);
                }

            }
            SelectedIndex = 0;
            Info = $"Найдено {TrainPrograms.Count}";

            Categories.Add("Активные");
            Categories.Add("Неактивные");
            Categories.Add("Все");


            viewWindow = new ViewWindow(this)
            {
                Visibility = System.Windows.Visibility.Hidden
            };

        }

        public BitmapImage LoadPhoto(int seller)
        {
            BitmapImage bitmapImage = new BitmapImage();

            if (userRepository.getById(seller).image != null)
            {
                using (var ms = new MemoryStream(userRepository.getById(seller).image))
                {
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = ms;
                    bitmapImage.EndInit();
                }
            }
            return bitmapImage;
        }

        public void Accept()
        {
            TrainProgramRepository.update(SelectedItem,true);
        }
        public void ShowInfo()
        {
            if (SelectedItem != null)
            {

                viewWindow.DataContext = SelectedItem;
                if (viewWindow.Visibility == System.Windows.Visibility.Hidden && SelectedItem != null)
                {
                    viewWindow.Show();
                }
            }

        }

        public void Search()
        {
            selectedItem = null;
            TrainPrograms.Clear();
            Regex regex = new Regex(@"(\w*)(?i)" + SearchText + @"(\w*)");
            int regionId = SelectedIndex;
            HashSet<TrainProgram> tmp1 = new HashSet<TrainProgram>();
            HashSet<TrainProgram> tmp2 = new HashSet<TrainProgram>();



            foreach (TrainProgram trainprogram in TrainProgramRepository.getAll())
            {
                tmp1.Add(trainprogram);
            }

            if (!string.IsNullOrEmpty(Category) && Category != "Все")
            {
                if (Category == "Активные")
                {
                    foreach (TrainProgram tp in tmp1)
                    {
                        if (tp.IsDone == false && tp.PersonId == CurrentUser.getId())
                        {
                            tmp2.Add(tp);
                        }
                    }
                }
                else
                {
                    foreach (TrainProgram tp in tmp1)
                    {
                        if (tp.IsDone == true && tp.PersonId == CurrentUser.getId())
                        {
                            tmp2.Add(tp);
                        }
                    }
                }

                tmp1.Clear();
            }
            else if (!string.IsNullOrEmpty(Category) && Category == "Все")
            {
                foreach (TrainProgram tp in tmp1)
                {
                    if (tp.PersonId == CurrentUser.getId())
                    {
                        tmp2.Add(tp);
                    }
                }
                tmp1.Clear();
            }
            else
            {
                foreach (TrainProgram tp in tmp1)
                {
                    if (tp.PersonId == CurrentUser.getId() && tp.IsDone == false)
                    {
                        tmp2.Add(tp);
                    }
                }


                tmp1.Clear();
            }


            if (!string.IsNullOrEmpty(SearchText))
            {
                foreach (TrainProgram trainprogram in tmp2)
                {
                    if (regex.IsMatch(trainprogram.Text))
                    {


                        tmp1.Add(trainprogram);

                    }
                }
            }
            else
            {
                foreach (TrainProgram trainprogram in tmp2)
                {


                    tmp1.Add(trainprogram);

                }
            }

            foreach (TrainProgram trainprogram in tmp1)
            {
                TrainPrograms.Add(trainprogram);
            }

            tmp1.Clear();
            tmp2.Clear();

            Info = $"Найдено {TrainPrograms.Count}";
        }

        public IEnumerable<TrainProgram> GetTrainPrograms()
        {
            return TrainProgramRepository.getAll();
        }

        public void DeleteTrainProgram(TrainProgram tmp)
        {
            TrainProgramRepository.delete(tmp);
        }



        public void AddTrainProgram(TrainProgram TrainProgram)
        {
            TrainProgramRepository.add(TrainProgram);
        }

        public void NextItem()
        {
            if (TrainPrograms.IndexOf(SelectedItem) < TrainPrograms.Count - 1)
            {
                SelectedItem = TrainPrograms.ElementAt(TrainPrograms.IndexOf(SelectedItem) + 1);
            }
        }

        public void PreviousItem()
        {
            if (TrainPrograms.IndexOf(SelectedItem) > 0)
            {
                SelectedItem = TrainPrograms.ElementAt(TrainPrograms.IndexOf(SelectedItem) - 1);
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
