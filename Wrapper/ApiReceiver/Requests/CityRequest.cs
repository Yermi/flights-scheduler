namespace Wrapper
{
    public class CityRequest : Request
    {
        public override string RequestUrl => "GetCitiesByCountry";
        public string countryId;
        public string prefix;
        public string currentAirport;

        public CityRequest(string p_countryId, string p_prefix, string p_currentAirport)
        {
            countryId = p_countryId;
            prefix = p_prefix;
            currentAirport = p_currentAirport;
        }
    }
}