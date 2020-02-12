namespace Wrapper
{
    public class CountryRequest : Request
    {
        public override string RequestUrl => "GetCountries";
        public string countryPrefix;
        public string currentAirport;

        public CountryRequest(string p_countryPrefix, string p_currentAirport)
        {
            countryPrefix = p_countryPrefix;
            currentAirport = p_currentAirport;
        }
    }
}