using System.ComponentModel.DataAnnotations.Schema;

namespace BE
{
    public class City
    {
        public string CityID { get; set; }
        public string CityEngName { get; set; }
        public string CityHebName { get; set; }
        
        public string CountryID { get; set; }
        
        [NotMapped]
        public Country Country { get; set; }
        public string CityName { get; set; }
        public bool IsEnabled { get; set; }
        public string NameByLanguage { get; set; }
    }
}