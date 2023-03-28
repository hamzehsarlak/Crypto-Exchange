using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Knab.Core.Abstraction.CQRS;
using Knab.Core.IMediatR.Abstraction;
using Knab.Integration.Dtos;
using Knab.Integration.Dtos.Listing;
using Knab.Integration.Dtos.Rate;
using Knab.Integration.Queries;

namespace Knab.Application.QueryHandlers
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