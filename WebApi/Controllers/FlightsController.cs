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
        public object Get()
        {
           return new { Fruit = "Strawberry", Topping = "Chocolate" };
        }
    }
}
