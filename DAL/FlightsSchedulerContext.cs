using BE;
using System.Data.Entity;

namespace DAL
{
    public class FlightsSchedulerContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
    }
}
