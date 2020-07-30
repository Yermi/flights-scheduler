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
            //var t = _flightsService.GetAll();
        }

        [Route("api/flights")]
        [HttpGet]
        public object Get()
        {
            //return new { a = 2 };
            return _flightsService.GetAll();
        }
    }
}
