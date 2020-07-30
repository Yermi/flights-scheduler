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
        private readonly FlightsService _flightService;
        public MainPageViewModel()
        {
            _flightService = new FlightsService();
            Flights = new ObservableCollection<Flight>(_flightService.GetByDate(DateTime.Now));
        }

        public ObservableCollection<Flight> Flights { get; set; }
    }
}
