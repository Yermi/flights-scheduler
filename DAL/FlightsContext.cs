using BE;
using MySql.Data.EntityFramework;
using System.Data.Entity;

namespace DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class FlightsContext : DbContext
    {
        public FlightsContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer<FlightsContext>(null);
        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Airline> Airlines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasKey(x => x.Id);
            var config = modelBuilder.Entity<Flight>();
            config.ToTable("Flights");
        }
    }
}
