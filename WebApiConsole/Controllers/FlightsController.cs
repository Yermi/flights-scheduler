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
        private readonly FlightsService _flightsService;

        public FlightsController()
        {
            _flightsService = new FlightsService();
        }

        [Route("api/flights")]
        public object Get(DateTime date)
        {
            //Validate();
            return _flightsService.GetByDate(date);
        }
    }
}
