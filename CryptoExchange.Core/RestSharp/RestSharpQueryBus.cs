using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Core.Abstraction.CQRS;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Serialization;

namespace CryptoExchange.Core.RestSharp
{
    public class RestSharpQueryBus : RestSharpBase, IRestQueryBus
    {
        public RestSharpQueryBus(ILogger<RestSharpCommandBus> logger, IRestSerializer restSerializer,
            IOptions<RestSharpOptions> options) : base(logger, restSerializer, options)
        {
        }

        public async Task<IRestBusResult<TResponse>> Get<TResponse>(string url, string path, 
            Dictionary<string, string> headers = null,
            IEnumerable<Tuple<string, string>> queryParameters = null,
            CancellationToken cancellationToken = default) 
        {
            return await HttpAsync<TResponse>(GetRestClient(url), GetRestRequest(path, Method.GET, headers, queryParameters));
        }
    }

    
}
