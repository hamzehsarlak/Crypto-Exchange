using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Knab.Integration.Queries;

namespace Knab.Application.Abstraction
{
    public interface IRateService
    {
        Task<Dictionary<string, double>> GetListingsAsync(FetchRatesQuery fetchRatesQuery,
            CancellationToken cancellationToken = default);
    }
}