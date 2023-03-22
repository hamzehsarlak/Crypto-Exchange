using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Knab.Application.Abstraction;
using Knab.Core.IMediatR.Abstraction;
using Knab.Integration.Dtos.Listing;
using Knab.Integration.Queries;

namespace Knab.Application.QueryHandlers
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
