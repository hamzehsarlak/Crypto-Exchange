using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Knab.Application.Abstraction;
using Knab.CoinMarketCap.Models.Response;
using Knab.Core.Abstraction.CQRS;
using Knab.Integration.Dtos.CryptoCurrency;
using Knab.Integration.Dtos.Listing;
using Knab.Integration.Queries;
using Microsoft.Extensions.Options;

namespace Knab.CoinMarketCap
{
    public class CoinMarketCapService : ICryptoCurrencyService
    {
        private readonly IRestQueryBus _restQueryBus;
        private readonly CoinMarketCapOptions _options;

        public CoinMarketCapService(IRestQueryBus restQueryBus, IOptions<CoinMarketCapOptions> options)
        {
            _restQueryBus = restQueryBus;
            _options = options.Value;
        }

        public async Task<IEnumerable<ListingDto>> GetListingsAsync(FetchListingsQuery fetchListingsQuery,
            CancellationToken cancellationToken = default)
        {
            var request = await _restQueryBus.Get<ListingsResponse>(CoinMarketCapConstants.BaseUrl,
                CoinMarketCapConstants.UrlListingsLatest,
                CoinMarketCapConstants.GetDefaultHeaders(_options.ApiKey),
                CoinMarketCapConstants.GetPaginationQueryParams(fetchListingsQuery.Offset, fetchListingsQuery.Limit),
                cancellationToken);

            if (request.ErrorException != null) throw request.ErrorException;

            if (request.StatusCode != HttpStatusCode.OK) throw new Exception(request.Result.Status.ErrorMessage);

            return MapListings(request.Result.Data);
        }

        private static IEnumerable<ListingDto> MapListings(IEnumerable<ListingsResponseData> data) =>
            data.Select(c => new ListingDto
            {
                CryptoCurrencyDto = new CryptoCurrencyDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Slug = c.Slug,
                    Symbol = c.Symbol
                },
                BtcPrice = c.Quote[CoinMarketCapConstants.BtcSymbol].Price,
                UsdPrice = c.Quote[CoinMarketCapConstants.UsdSymbol].Price
            });
    }
}