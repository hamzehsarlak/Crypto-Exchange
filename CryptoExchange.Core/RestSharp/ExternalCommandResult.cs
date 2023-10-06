using CryptoExchange.Core.Abstraction.CQRS;
using RestSharp;

namespace CryptoExchange.Core.RestSharp
{
    public class ExternalCommandResult<T> : RestResponse, IRestBusResult<T>
    {
        public T Result { get; set; }
    }
}
