using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace firsttestapp
{
    public class UserSet
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }


        public bool lightOrDark { get; set; }
        public string SomeEntry { get; set; }

        public int SavedFontSize { get; set; }
        public float SavedBrightness { get; set; }
        public string SavedFontFamily { get; set; }
    }
}
