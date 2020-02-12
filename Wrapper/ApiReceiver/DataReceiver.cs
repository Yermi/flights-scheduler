using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Wrapper
{
    public class DataReceiver
    {
        const string API_BASE_URL = "https://www.iaa.gov.il/he-IL/airports/BenGurion/_layouts/15/IAAWebSite/WS/FlightsUtils.asmx/";
        const string CONTENT_TYPE_HEADER = "application/json";

        private Cookie _cookie;

        public DataReceiver(Cookie p_cookie)
        {
            _cookie = p_cookie;
        }

        public IEnumerable<T> GetData<T>(Request p_request) where T : class
        {
            var client = new WebClient() { Encoding = Encoding.UTF8 };
            client.Headers[HttpRequestHeader.ContentType] = CONTENT_TYPE_HEADER;
            var asStr = _cookie.Name + "=" + _cookie.Value;
            //client.Headers.Add(HttpRequestHeader.Cookie, asStr);
            var result = client.UploadString(API_BASE_URL + p_request.RequestUrl, p_request.ToJson());
            return JsonConvert.DeserializeObject<DataResponse<T>>(result).d;
        }
    }
}