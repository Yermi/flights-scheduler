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
            using (var db = new FlightsSchedulerContext())
            {
                // Create and save a new Blog
                //Console.Write("Enter a name for a new Blog: ");
                //var name = Console.ReadLine();

                //var blog = new Blog { Name = name };
                db.Flights.Add(p_flights.First());
                db.SaveChanges();

                // Display all Blogs from the database
                var query = from b in db.Flights
                            orderby b.FlightID
                            select b;

                //Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.FlightID);
                }

                //Console.WriteLine("Press any key to exit...");
                //Console.ReadKey();
            }
        }
    }
}
