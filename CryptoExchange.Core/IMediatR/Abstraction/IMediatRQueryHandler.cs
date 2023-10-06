using MediatR;

namespace CryptoExchange.Core.IMediatR.Abstraction
{
    public interface IMediatRQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult>
        where TQuery : IMediatRQuery<TResult>
    {
    }
}
