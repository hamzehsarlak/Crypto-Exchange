using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Integration.Queries;

namespace CryptoExchange.Application.Abstraction
{
    public interface IRateService
    {
        Task<Dictionary<string, double>> GetRatesAsync(FetchRatesQuery fetchRatesQuery,
            CancellationToken cancellationToken = default);
    }
}