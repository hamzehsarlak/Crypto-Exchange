using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CryptoExchange.Core.Abstraction.CQRS;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using RestSharp;
using RestSharp.Serialization;

namespace CryptoExchange.Core.RestSharp
{
    public abstract class RestSharpBase
    {
        private readonly ILogger<RestSharpBase> _logger;
        private readonly IRestSerializer _restSerializer;
        private readonly RestSharpOptions _options;

        public RestSharpBase(ILogger<RestSharpBase> logger, IRestSerializer restSerializer,
            IOptions<RestSharpOptions> options)
        {
            _logger = logger;
            _restSerializer = restSerializer;
            _options = options.Value;
        }

        public IRestRequest GetRestRequest<TRequest>(string path, TRequest command, Method httpVerb,
            Dictionary<string, string> headers,
            IEnumerable<Tuple<string, string>> queryParameters)
        {
            var request = GetBaseRestRequest(path, httpVerb, headers,queryParameters);
            if (httpVerb == Method.GET) return request;
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(command);
            return request;
        }
        public IRestRequest GetRestRequest(string path, Method httpVerb, Dictionary<string, string> headers, 
            IEnumerable<Tuple<string, string>> queryParameters)
        {
            var request = GetBaseRestRequest(path, httpVerb, headers,queryParameters);
            return request;
        }

        public RestRequest GetBaseRestRequest(string path, Method httpVerb, Dictionary<string, string> headers,
            IEnumerable<Tuple<string, string>> queryParameters)
        {
            var request = new RestRequest(path, DataFormat.Json) { JsonSerializer = _restSerializer, Method = httpVerb };

            request.AddHeader("cache-control", "no-cache");
            if (headers != null && headers.Count > 0)
                foreach (var header in headers)
                    request.AddHeader(header.Key, header.Value);
            if (queryParameters != null && queryParameters.Any())
                foreach (var queryParameter in queryParameters)
                    request.AddQueryParameter(queryParameter.Item1, queryParameter.Item2);
            return request;
        }

        public IRestClient GetRestClient(string url)
        {
            return new RestClient(url);
        }

        public async Task<IRestBusResult<TResponse>> HttpAsync<TResponse>(IRestClient restClient, IRestRequest request)
        {
            try
            {
                var restResponse = await Task.Factory.StartNew(() => RestResponseWithPolicy<TResponse>(restClient, request));
                if (restResponse.ErrorException != null)
                    throw restResponse.ErrorException;
                return new ExternalCommandResult<TResponse>
                {
                    Result = restResponse.Data,
                    Content = restResponse.Content,
                    StatusCode = restResponse.StatusCode
                };
            }
            catch (Exception ex)
            {
                return new ExternalCommandResult<TResponse>
                {
                    ErrorException = ex,
                    ErrorMessage = ex.Message,
                    ResponseStatus = ResponseStatus.TimedOut,
                    StatusCode = HttpStatusCode.ServiceUnavailable
                };
            }
        }

        public IRestResponse<TResponse> RestResponseWithPolicy<TResponse>(IRestClient restClient, IRestRequest restRequest)
        {
            var retryPolicy = Policy
                .HandleResult<IRestResponse<TResponse>>(x => !x.IsSuccessful)
                .WaitAndRetry(_options.MaxRetryAttempts, x => _options.PauseBetweenFailures,
                    (iRestResponse, timeSpan, retryCount, context) =>
                    {
                        _logger.LogError(
                            $"The request failed. HttpStatusCode={iRestResponse.Result.StatusCode}. Waiting {timeSpan} seconds before retry. Number attempt {retryCount}. Uri={iRestResponse.Result.ResponseUri}; RequestResponse={iRestResponse.Result.Content}");
                    });

            var circuitBreakerPolicy = Policy
                .HandleResult<IRestResponse<TResponse>>(x => x.StatusCode == HttpStatusCode.ServiceUnavailable)
                .CircuitBreaker(1, TimeSpan.FromSeconds(60),
                    onBreak: (iRestResponse, timespan, context) =>
                    {
                        _logger.LogError($"Circuit went into a fault state. Reason: {iRestResponse.Result.Content}");
                    },
                    onReset: (context) => { _logger.LogError($"Circuit left the fault state."); });

            return retryPolicy.Wrap(circuitBreakerPolicy).Execute(() => restClient.Execute<TResponse>(restRequest));
        }
    }
}
