using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Airport
    {
        public string AirPortID { get; set; }
        public string AirPortEngName { get; set; }
        public string CityID { get; set; }
        public City City { get; set; }
        public string AirPortName { get; set; }
        public bool IsEnabled { get; set; }
        public string NameByLanguage { get; set; }
    }
}