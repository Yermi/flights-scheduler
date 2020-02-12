namespace BE
{
    public class Flight
    {
        public string FlightID { get; set; }
        public string Carrier { get; set; }
        public string ImagePath { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string DepartureTime { get; set; }
        public string DayOfWeek { get; set; }
        public int Terminal { get; set; }
    }
}
