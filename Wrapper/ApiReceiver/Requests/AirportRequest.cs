namespace Wrapper
{
    public class AirportRequest : Request
    {
        public override string RequestUrl => "GetAirportsByCity";
        public string cityId;
        public string prefix;
        public string currentAirport;

        public AirportRequest(string p_cityId, string p_prefix, string p_currentAirport)
        {
            cityId = p_cityId;
            prefix = p_prefix;
            currentAirport = p_currentAirport;
        }
    }
}