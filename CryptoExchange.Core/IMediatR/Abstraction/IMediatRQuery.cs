using CryptoExchange.Core.Abstraction.CQRS;
using MediatR;

namespace CryptoExchange.Core.IMediatR.Abstraction
{
    public interface IMediatRQuery<out TResult> : IQuery<TResult>, IRequest<TResult>
    {
    }
}
