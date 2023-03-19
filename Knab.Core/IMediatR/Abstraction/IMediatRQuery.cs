using Knab.Core.Abstraction.CQRS;
using MediatR;

namespace Knab.Core.IMediatR.Abstraction
{
    public interface IMediatRQuery<out TResult> : IQuery<TResult>, IRequest<TResult>
    {
    }
}
