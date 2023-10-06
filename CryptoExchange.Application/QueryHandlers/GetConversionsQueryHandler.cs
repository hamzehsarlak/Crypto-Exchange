using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Core.Abstraction.CQRS;
using CryptoExchange.Core.IMediatR.Abstraction;
using CryptoExchange.Integration.Dtos;
using CryptoExchange.Integration.Dtos.Listing;
using CryptoExchange.Integration.Dtos.Rate;
using CryptoExchange.Integration.Queries;

namespace CryptoExchange.Application.QueryHandlers
{
    public class GetConversionsQueryHandler : IMediatRQueryHandler<GetConversionsQuery, IEnumerable<ConversionDto>>
    {
        private readonly IQueryBus _queryBus;
        
        public GetConversionsQueryHandler(IQueryBus queryBus)
        {
            _queryBus = queryBus;
        }

        public async Task<IEnumerable<ConversionDto>> Handle(GetConversionsQuery request,
            CancellationToken cancellationToken)
        {
            var rates = await _queryBus.SendAsync<GetCachedRatesQuery, IEnumerable<RateDto>>(new GetCachedRatesQuery(),
                cancellationToken);
            
            var listings =
                await _queryBus.SendAsync<GetCachedListingsQuery, IEnumerable<ListingDto>>(new GetCachedListingsQuery(),
                    cancellationToken);
            
            return listings.Select(l => new ConversionDto(l.Id, l.CryptoCurrencyDto.Name, l.CryptoCurrencyDto.Symbol,
                Math.Round(l.UsdPrice, 2,
                    MidpointRounding.AwayFromZero),
                Math.Round(l.BtcPrice, 12,
                    MidpointRounding.AwayFromZero),
                rates));
        }
    }
}