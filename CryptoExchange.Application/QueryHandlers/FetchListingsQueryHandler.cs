using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Application.Abstraction;
using CryptoExchange.Core.IMediatR.Abstraction;
using CryptoExchange.Integration.Dtos.Listing;
using CryptoExchange.Integration.Queries;

namespace CryptoExchange.Application.QueryHandlers
{
    public class FetchListingsQueryHandler : IMediatRQueryHandler<FetchListingsQuery, IEnumerable<ListingDto>>
    {
        private readonly ICryptoCurrencyService _cryptoCurrencyService;

        public FetchListingsQueryHandler(ICryptoCurrencyService cryptoCurrencyService)
        {
            _cryptoCurrencyService = cryptoCurrencyService;
        }

        public async Task<IEnumerable<ListingDto>> Handle(FetchListingsQuery request, CancellationToken cancellationToken)
        {
            return await _cryptoCurrencyService.GetListingsAsync(request, cancellationToken);
        }
    }
}
