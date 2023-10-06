using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Integration.Dtos.Listing;
using CryptoExchange.Integration.Queries;

namespace CryptoExchange.Application.Abstraction
{
    public interface ICryptoCurrencyService
    {
        Task<IEnumerable<ListingDto>> GetListingsAsync(FetchListingsQuery fetchListingsQuery,
            CancellationToken cancellationToken = default);
    }
}