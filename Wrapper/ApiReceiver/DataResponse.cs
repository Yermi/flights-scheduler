using System.Collections.Generic;

namespace Wrapper
{
    public class DataResponse<T> where T : class 
    {
        public IEnumerable<T> d;
    }
}