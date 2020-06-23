using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiConsole
{
    public class FlightsController : ApiController
    {
        private readonly IFlightsService _flightsService;

        public FlightsController()
        {
            _flightsService = new FlightsService();
        }

        public IEnumerable<Flight> Get()
        {
            return _flightsService.GetAll();
        }
    }
}
