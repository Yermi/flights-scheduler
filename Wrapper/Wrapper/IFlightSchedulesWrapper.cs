using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrapper
{
    interface IFlightSchedulesWrapper
    {
        List<Flight> GetFlightsByDate(DateTime date);
    }
}
