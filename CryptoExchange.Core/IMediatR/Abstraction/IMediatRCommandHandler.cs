using MediatR;

namespace CryptoExchange.Core.IMediatR.Abstraction
{
    public interface IMediatRCommandHandler<in TCommand> : IRequestHandler<TCommand>
        where TCommand : IMediatRCommand
    {
    }

    public interface IMediatRCommandHandler<in TCommand, TResult> :
        IRequestHandler<TCommand, TResult>
        where TCommand : IMediatRCommand<TResult>
    {
    }
}
