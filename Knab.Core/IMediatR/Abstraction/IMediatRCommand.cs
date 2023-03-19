using Knab.Core.Abstraction.CQRS;
using MediatR;

namespace Knab.Core.IMediatR.Abstraction
{
    public interface IMediatRCommand<TResult> : ICommand<TResult>, IRequest<TResult>
    {
    }

    public interface IMediatRCommand : ICommand, IRequest<Unit>
    {
    }
}
