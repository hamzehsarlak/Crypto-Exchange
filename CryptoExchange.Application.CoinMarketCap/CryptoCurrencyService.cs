using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Application.Abstraction;
using CryptoExchange.CoinMarketCap.Models.Response;
using CryptoExchange.Core.Abstraction.CQRS;
using CryptoExchange.Integration.Dtos.CryptoCurrency;
using CryptoExchange.Integration.Dtos.Listing;
using CryptoExchange.Integration.Queries;
using Microsoft.Extensions.Options;

namespace CryptoExchange.CoinMarketCap
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
                CoinMarketCapConstants.GetQueryParams(fetchListingsQuery.Offset, fetchListingsQuery.Limit),
                cancellationToken);

            if (request.ErrorException != null) throw request.ErrorException;

            if (request.StatusCode != HttpStatusCode.OK) throw new Exception(request.Result.Status.ErrorMessage);

            return MapListings(request.Result.Data);
        }

        private static IEnumerable<ListingDto> MapListings(IEnumerable<ListingsResponseData> data)
        {
            var listings = data as ListingsResponseData[] ?? data.ToArray();
            
            // free api doesn't allow to convert to two symbols so this is the hack
            CalculateBtcPrice(listings);

            return listings.Select(c => new ListingDto
            {
                CryptoCurrencyDto = new CryptoCurrencyDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Slug = c.Slug,
                    Symbol = c.Symbol
                },
                Id = c.Id,
                BtcPrice = c.Quote.TryGetValue(CoinMarketCapConstants.BtcSymbol, out var btc) ? btc.Price : 1,
                UsdPrice = c.Quote.TryGetValue(CoinMarketCapConstants.UsdSymbol, out var usd) ? usd.Price : 1
            });
        }

        private static void CalculateBtcPrice(ListingsResponseData[] listings)
        {
            var btcUsdPrice = PriceValue(listings.FirstOrDefault(d => d.Symbol == CoinMarketCapConstants.BtcSymbol)!,
                CoinMarketCapConstants.UsdSymbol);
            foreach (var listing in listings)
            {
                var usdPrice = PriceValue(listing, CoinMarketCapConstants.UsdSymbol);
                listing.Quote.Add(CoinMarketCapConstants.BtcSymbol, new ListingsResponseQuote
                {
                    Price = usdPrice / btcUsdPrice
                });
            }
        }

        private static double PriceValue(ListingsResponseData listing, string symbol)
        {
            return listing.Quote.TryGetValue(symbol, out var q) ? q.Price : 1;
        }
    }
}