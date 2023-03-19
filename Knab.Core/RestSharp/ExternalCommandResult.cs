using Knab.Core.Abstraction.CQRS;
using RestSharp;

namespace Knab.Core.RestSharp
{
    public class ExternalCommandResult<T> : RestResponse, IRestBusResult<T>
    {
        public T Result { get; set; }
    }
}
