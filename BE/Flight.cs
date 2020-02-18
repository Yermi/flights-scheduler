using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE
{
    [Table("Flights")]
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string IataAirline { get; set; }
        public int FlightNumber { get; set; }
        public string FlightID => IataAirline + FlightNumber;
        public string ImagePath { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public string DayOfWeek { get; set; }
        public int Terminal { get; set; }
        public bool IsOperator { get; set; }
    }
}