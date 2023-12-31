using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Application.ExchangeRatesApi.Models.Responses;
using CryptoExchange.Application.Abstraction;
using CryptoExchange.Core.Abstraction.CQRS;
using CryptoExchange.Integration.Queries;
using Microsoft.Extensions.Options;

namespace CryptoExchange.Application.ExchangeRatesApi
{
    public class ExchangeRatesApiService : IRateService
    {
        private readonly IRestQueryBus _restQueryBus;
        private readonly ExchangeRatesApiOptions _options;

        public ExchangeRatesApiService(IRestQueryBus restQueryBus, IOptions<ExchangeRatesApiOptions> options)
        {
            _restQueryBus = restQueryBus;
            _options = options.Value;
        }

        public async Task<Dictionary<string, double>> GetRatesAsync(FetchRatesQuery fetchListingsQuery,
            CancellationToken cancellationToken = default)
        {
            var request = await _restQueryBus.Get<RatesResponse>(ExchangeRatesApiConstants.BaseUrl,
                ExchangeRatesApiConstants.RatesLatest,
                ExchangeRatesApiConstants.GetDefaultHeaders(_options.ApiKey),
                ExchangeRatesApiConstants.GetRatesQueryParams(fetchListingsQuery.BaseSymbol, fetchListingsQuery.Symbols),
                cancellationToken);

            if (request.ErrorException != null) throw request.ErrorException;

            if (request.StatusCode != HttpStatusCode.OK || !request.Result.Success)
                throw new Exception(request.StatusCode.ToString());

            return request.Result.Rates;
        }
    }
}