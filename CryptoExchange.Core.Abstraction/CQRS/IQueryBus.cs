using System.Threading;
using System.Threading.Tasks;

namespace CryptoExchange.Core.Abstraction.CQRS
{
    /// <summary>
    /// Query bus must handle this methods
    /// </summary>
    public interface IQueryBus
    {
        Task<TResponse> SendAsync<TQuery, TResponse>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : IQuery<TResponse>;
        TResponse Send<TQuery, TResponse>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : IQuery<TResponse>;
    }
}
