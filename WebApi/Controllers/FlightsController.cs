
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class FlightsController : ApiController
    {
        //private readonly IFlightsService _flightsService;

        public FlightsController()
        {
           // _flightsService = new FlightsService();
        }

        public IEnumerable<object> Get()
        {
            return new List<object>() { new { msg = "Hello World" } , new { msg = "Hello Yirmi" } };
            //return _flightsService.GetAll();
        }
    }
}
