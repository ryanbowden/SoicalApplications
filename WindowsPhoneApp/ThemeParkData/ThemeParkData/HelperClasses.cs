using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeParkData
{
    class HelperClasses
    {
    }

    public class ThemeParksClass
    {
        public int ID { get; set; }
        public string ThemeParkName { get; set; }
    }

    public class Users
    {
        public int ID { get; set; }
        public string ServiceID { get; set; }
        public string Name { get; set; }
    }

    public class Photos
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ThemeParkID { get; set; }
        public string PhotoURL { get; set; }
    }
}
