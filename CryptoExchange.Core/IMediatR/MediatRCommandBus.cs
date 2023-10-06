using System;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Core.IMediatR.Abstraction;
using CryptoExchange.Core.Abstraction.CQRS;
using MediatR;

namespace CryptoExchange.Core.IMediatR
{
    public class MediatRCommandBus : ICommandBus
    {
        private readonly IMediator _mediator;

        public MediatRCommandBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand
        {
            return _mediator.Send(command, cancellationToken);
        }

        public async Task Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            await SendAsync(command);
        }

        public Task<TResult> SendAsync<TCommand, TResult>(TCommand command,
            CancellationToken cancellationToken = default) where TCommand : ICommand<TResult>
        {
            return _mediator.Send(
                (command as IMediatRCommand<TResult>) ??
                throw new InvalidOperationException("TCommand must be IMediatRCommand<TResult>"), cancellationToken);
        }

        public async Task<TResult> Send<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>
        {
            return await SendAsync<TCommand, TResult>(command);
        }
    }
}
