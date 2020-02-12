using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Wrapper;

namespace Tester
{
    public class Tester
    {
        public void testFlightsWrapper()
        {
            var flightWrapper = new FlightWrapper(AirportPages.BenGurion);
            var flights = new List<Flight>();
            for (int i = 0; i < 10; i++)
            {
                var date = DateTime.Now.AddDays(i);
                var flight = flightWrapper.GetFlightsByDate(date);
                Console.WriteLine("{0}: {1} flights",date, flight.Count);
                flights = flights.Count == 0 ? flight : flights.Concat(flight).ToList();
            }
            Console.WriteLine(flights.Count);
            var cookie = new Cookie("incap_ses_264_1276841", "zqTLGFJTOmAn/CN5P+2pA8RTRF4AAAAA55D7hroVG4lj6zw6nY4UMQ==");
            var dataReceiver = new DataReceiver(cookie);
            var airportsRequest = new AirportRequest("", "", "LLBG");
            var airlinesRrequest = new AirlineRequest("", "LLBG");
            var countriesRequest = new CountryRequest("", "LLBG");
            var citiesRequest = new CityRequest("", "", "LLBG");

            var airlines = dataReceiver.GetData<Airline>(airlinesRrequest);
            var airports = dataReceiver.GetData<Airport>(airportsRequest);
            var countries = dataReceiver.GetData<Country>(countriesRequest);
            var cities = dataReceiver.GetData<City>(citiesRequest);
        }

        public void testGetData()
        {
            var cookie = new Cookie("incap_ses_264_1276841", "zqTLGFJTOmAn/CN5P+2pA8RTRF4AAAAA55D7hroVG4lj6zw6nY4UMQ==");
            var dataReceiver = new DataReceiver(cookie);
            var airportsRequest = new AirportRequest("", "", "LLBG");
            var airlinesRrequest = new AirlineRequest("", "LLBG");
            var countriesRequest = new CountryRequest("", "LLBG");
            var citiesRequest = new CityRequest("", "", "LLBG");

            var airlines = dataReceiver.GetData<Airline>(airlinesRrequest);
            var airports = dataReceiver.GetData<Airport>(airportsRequest);
            var countries = dataReceiver.GetData<Country>(countriesRequest);
            var cities = dataReceiver.GetData<City>(citiesRequest);
        }
    }
}
