using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICityService
    {
        void SaveCities(IEnumerable<City> p_cities);
        List<City> GetAll();
    }
    public class CityService : ICityService
    {
        public List<City> GetAll()
        {
            using (var db = new FlightsContext())
            {
                return (from c in db.Cities
                        select c).ToList();
            }
        }

        public void SaveCities(IEnumerable<City> p_cities)
        {
            using (var db = new FlightsContext())
            {
                db.Cities.AddRange(p_cities);
                db.SaveChanges();
            }
        }
    }
}
