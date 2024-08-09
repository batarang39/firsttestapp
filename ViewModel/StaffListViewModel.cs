
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CsvHelper;
using CsvHelper.Configuration;

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace firsttestapp.ViewModel
{
    public class Person : ObservableObject
    {

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (SetProperty(ref _name, value))
                {
                    OnPropertyChanged(nameof(Name));
                }

            }
        }
        public class CsvMap : ClassMap<Person>
        {
            public CsvMap() {
                Map(m => m.Name).Index(0);
            }
        }
    
    }
}
