using System.ComponentModel.DataAnnotations;

namespace BE
{
    public class Airline
    {
        [Key]
        public string AirLineCompanyID { get; set; }
        public string AirLineEngName { get; set; }
        public string AirLineHebName { get; set; }
        public string LocalPortID { get; set; }
        public string AirLineName { get; set; }
        public bool IsEnabled { get; set; }
        public string NameByLanguage { get; set; }
        public string IATA { get; set; }
        public string ICAO { get; set; }
    }
}