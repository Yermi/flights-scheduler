using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface ICountryService
    {
        void SaveCities(IEnumerable<Country> p_cities);
        List<Country> GetAll();

    }
    public class CountryService : ICountryService
    {
        public List<Country> GetAll()
        {
            using (var db = new FlightsContext())
            {
                return (from c in db.Countries
                        select c).ToList();
            }
        }

        public void SaveCities(IEnumerable<Country> p_countries)
        {
            using (var db = new FlightsContext())
            {
                db.Countries.AddRange(p_countries);
                db.SaveChanges();
            }
        }
    }
}
