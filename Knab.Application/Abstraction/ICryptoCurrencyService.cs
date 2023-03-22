using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Knab.Integration.Dtos.Listing;
using Knab.Integration.Queries;

namespace Knab.Application.Abstraction
{
    public interface ICryptoCurrencyService
    {
        Task<IEnumerable<ListingDto>> GetListingsAsync(FetchListingsQuery fetchListingsQuery,
            CancellationToken cancellationToken = default);
    }
}