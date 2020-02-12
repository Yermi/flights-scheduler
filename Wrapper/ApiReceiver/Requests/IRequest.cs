using Newtonsoft.Json;
 
namespace Wrapper
{
    public interface IRequest
    {
        string RequestUrl { get; }
    }

    public abstract class Request : IRequest
    {
        public virtual string RequestUrl { get; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}