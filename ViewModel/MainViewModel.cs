
//using CommunityToolkit.Mvvm.ComponentModel;
//using CommunityToolkit.Mvvm.Input;
//using System.Collections.ObjectModel;
//using CsvHelper;
//using System.ComponentModel;
//using System.Globalization;
//using System.IO;

//namespace firsttestapp.ViewModel
//{
//    public partial class MainPageViewModel : ObservableObject
//    {


//        public MainPageViewModel()
//        {
//            Employees = new ObservableCollection<Person>();
//        }

//        [ObservableProperty]
//        ObservableCollection<Person> items = new ObservableCollection<Person>();

//        [ObservableProperty]
//        string text;
//        [RelayCommand]

//        public async void ImportSomeRecords()
//        {
//            using (var reader = new StreamReader(fileStream))
//            {
//                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
//                {
//                    csv.Context.RegisterClassMap<CsvMap>();

//                    string name;

//                    while (csv.Read())
//                    {
//                        {
//                            name = csv.GetField<string>(0);
//                        }
//                    }

//                }
//            }
//            public static Person CreateRecord(string name)
//            {
//                Person record = new Person();



//                record.Name = name;

//                return record;


//            }
//        }
//    }
//}
    


