using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoExchange.Core.Abstraction.CQRS
{
    public interface IRestCommandBus
    {
        Task<IRestBusResult<TResponse>> Post<TRequest, TResponse>(string url, string path, TRequest command,
            Dictionary<string, string> headers,
            IEnumerable<Tuple<string, string>> queryParameters,
            CancellationToken cancellationToken = default);

        Task<IRestBusResult<TResponse>> Put<TRequest, TResponse>(string url, string path, TRequest command,
            Dictionary<string, string> headers,
            IEnumerable<Tuple<string, string>> queryParameters,
            CancellationToken cancellationToken = default);

        Task<IRestBusResult<TResponse>> Delete<TRequest, TResponse>(string url, string path, TRequest command,
            Dictionary<string, string> headers,
            IEnumerable<Tuple<string, string>> queryParameters,
            CancellationToken cancellationToken = default);
    }
}
