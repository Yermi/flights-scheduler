using BE;
using DAL;
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
            for (int i = 0; i < 2; i++)
            {
                var date = DateTime.Now.AddDays(i);
                var flight = flightWrapper.GetFlightsByDate(date);
                Console.WriteLine("{0}: {1} flights", date, flight.Count);
                flights = flights.Count == 0 ? flight : flights.Concat(flight).ToList();
            }
            Console.WriteLine(flights.Count);
            //var cookie = new Cookie("incap_ses_264_1276841", "zqTLGFJTOmAn/CN5P+2pA8RTRF4AAAAA55D7hroVG4lj6zw6nY4UMQ==");
            //var dataReceiver = new DataReceiver(cookie);
            //var airportsRequest = new AirportRequest("", "", "LLBG");
            //var airlinesRrequest = new AirlineRequest("", "LLBG");
            //var countriesRequest = new CountryRequest("", "LLBG");
            //var citiesRequest = new CityRequest("", "", "LLBG");

            //var airlines = dataReceiver.GetData<Airline>(airlinesRrequest);
            //var airports = dataReceiver.GetData<Airport>(airportsRequest);
            //var countries = dataReceiver.GetData<Country>(countriesRequest);
            //var cities = dataReceiver.GetData<City>(citiesRequest);
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

        public void testEntityFramwork()
        {
            var flightWrapper = new FlightWrapper(AirportPages.BenGurion);
            var flights = new List<Flight>();
            for (int i = 0; i < 30; i++)
            {
                var date = DateTime.Now.AddDays(i);
                var flight = flightWrapper.GetFlightsByDate(date);
                Console.WriteLine("{0}: {1} flights", date, flight.Count);
                flights = flights.Count == 0 ? flight : flights.Concat(flight).ToList();
            }
            Console.WriteLine(flights.Count);
            //var date = DateTime.Now;
            //var flights = flightWrapper.GetFlightsByDate(date);
            var flightsHandler = new FlightsService();
            flightsHandler.SaveFlights(flights);
            var f = flightsHandler.GetAll();
        }

        public void testQueryData()
        {
            var flightsHandler = new FlightsService();
            var maxDate = flightsHandler.GetMaxDate();
            var f = flightsHandler.GetAll();
        }

        public void testRemoveAll()
        {
            var flightsHandler = new FlightsService();
            flightsHandler.RemoveAll();
        }

        public void collectData()
        {
            try
            {
                var flightsWrapper = new FlightWrapper(AirportPages.BenGurion);
                var flightsHandler = new FlightsService();
                var date = DateTime.Parse("24/03/2021 00:00:00");
                while (date < DateTime.Parse("29/03/2021 00:00:00"))
                {
                    var flights = flightsWrapper.GetFlightsByDate(date);
                    Console.WriteLine($"{date}: {flights.Count} flights");
                    flightsHandler.SaveFlights(flights);
                    date = date.AddDays(1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        public void saveCities()
        {
            try
            {
                var dateReceiver = new DataReceiver(new Cookie());
                //var citiesRequest = new CityRequest("", "", "LLBG");
                //var cities = dateReceiver.GetData<City>(citiesRequest);
                //var countriesRequest = new CountryRequest("", "LLBG");
                //var countries = dateReceiver.GetData<Country>(countriesRequest);
                //var countriesService = new CountryService();
                //countriesService.SaveCities(countries);
                //foreach (var c in cities)
                //{
                //    c.CountryID = c.Country.CountryID;
                //}
                //var citiesService = new CityService();
                //citiesService.SaveCities(cities);

                var airlinesRequest = new AirlineRequest("", "LLBG");
                var airlines = dateReceiver.GetData<Airline>(airlinesRequest);
                var airlinesService = new AirlineServise();
                airlinesService.SaveAirline(airlines);

            }
            catch (Exception ex)
            {
                
            }
        }

        public void CheckForNewFlights()
        {
            var flightService = new FlightsService();
            var existingFlightIds = flightService.GetFlightIds();
        }

        public void testGetFlightsByDate()
        {
            var date = DateTime.Now;
            var flightService = new FlightsService();
            var f = flightService.GetByDate(date);
        }
    }
}
