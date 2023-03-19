using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Knab.Core.Abstraction.CQRS;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Serialization;

namespace Knab.Core.RestSharp
{
    public class RestSharpCommandBus : RestSharpBase, IRestCommandBus
    {
        public RestSharpCommandBus(ILogger<RestSharpCommandBus> logger, IRestSerializer restSerializer,
            IOptions<RestSharpOptions> options) : base(logger, restSerializer, options)
        {
        }

        public async Task<IRestBusResult<TResponse>> Post<TRequest, TResponse>(string url, string path, TRequest command,
            Dictionary<string, string> headers = null,
            IEnumerable<Tuple<string, string>> queryParameters=null,
            CancellationToken cancellationToken = default) 
        {
            return await HttpAsync<TResponse>(GetRestClient(url), GetRestRequest(path, command, Method.POST, headers, queryParameters));
        }

        public async Task<IRestBusResult<TResponse>> Put<TRequest, TResponse>(string url, string path, TRequest command,
            Dictionary<string, string> headers = null,
            IEnumerable<Tuple<string, string>> queryParameters=null,
            CancellationToken cancellationToken = default) 
        {
            return await HttpAsync<TResponse>(GetRestClient(url), GetRestRequest(path, command, Method.PUT, headers, queryParameters));
        }

        public async Task<IRestBusResult<TResponse>> Delete<TRequest, TResponse>(string url, string path, TRequest command,
            Dictionary<string, string> headers = null,
            IEnumerable<Tuple<string, string>> queryParameters=null,
            CancellationToken cancellationToken = default) 
        {
            return await HttpAsync<TResponse>(GetRestClient(url), GetRestRequest(path, command, Method.DELETE, headers, queryParameters));
        }
    }
}
