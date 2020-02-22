using BE;
using System.Data.Entity;

namespace DAL
{
    public class FlightsContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Airline> Airlines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var config = modelBuilder.Entity<Flight>();
            config.ToTable("Flights");
        }
    }
}
