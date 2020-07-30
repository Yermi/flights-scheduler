using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    public class MainPageViewModel
    {
        private readonly IFlightsService _flightService;
        public MainPageViewModel(IFlightsService p_flightsService)
        {
            _flightService = p_flightsService;
            Flights = new ObservableCollection<Flight>(_flightService.GetByDate(DateTime.Now));
        }

        public ObservableCollection<Flight> Flights { get; set; }
    }
}
