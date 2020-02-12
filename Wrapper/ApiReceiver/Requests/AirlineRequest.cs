namespace Wrapper
{
    public class AirlineRequest : Request
    {
        public override string RequestUrl => "GetAirtlines";

        public string letter;
        public string currentAirport;

        public AirlineRequest(string p_letter, string p_currentAirport)
        {
            letter = p_letter;
            currentAirport = p_currentAirport;
        }
    }
}