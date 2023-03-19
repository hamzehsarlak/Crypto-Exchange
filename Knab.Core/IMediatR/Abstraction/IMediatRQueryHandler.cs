using MediatR;

namespace Knab.Core.IMediatR.Abstraction
{
    public interface IMediatRQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult>
        where TQuery : IMediatRQuery<TResult>
    {
    }
}
