using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FlightsDbHandler
    {
        public void SaveFlights(IEnumerable<Flight> p_flights)
        {
            using (var db = new FlightsContext())
            {
                db.Flights.AddRange(p_flights);
                db.SaveChanges();
            }
        }

        public IEnumerable<Flight> GetAll()
        {
            using (var db = new FlightsContext())
            {
                var con = db.Database.Connection.ConnectionString;
                return (from f in db.Flights
                        select f).ToList();
            }
        }

        public void RemoveAll()
        {
            using (var db = new FlightsContext())
            {
                var rows = from o in db.Flights
                           select o;
                foreach (var row in rows)
                {
                    db.Flights.Remove(row);
                }
                db.SaveChanges();
            }

        }

        public DateTime GetMaxDate()
        {
            using (var db = new FlightsContext())
            {
                return db.Flights
                    .OrderByDescending(c => c.Id)
                    .Select(c => c.DepartureTime)
                    .FirstOrDefault();
            }
        }
    }
}
