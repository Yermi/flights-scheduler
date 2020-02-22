using BE;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public interface IAirlineServise
    {
        List<Airline> GetAll();
        void SaveAirline(IEnumerable<Airline> p_airlines);
    }
    public class AirlineServise : IAirlineServise
    {
        public List<Airline> GetAll()
        {
            using (var db = new FlightsContext())
            {
                return (from a in db.Airlines
                        select a).ToList();
            }
        }

        public void SaveAirline(IEnumerable<Airline> p_airlines)
        {
            using (var db = new FlightsContext())
            {
                db.Airlines.AddRange(p_airlines);
                db.SaveChanges();
            }
        }
    }
}