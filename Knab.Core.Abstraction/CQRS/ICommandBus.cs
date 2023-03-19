using System.Threading;
using System.Threading.Tasks;

namespace Knab.Core.Abstraction.CQRS
{
    /// <summary>
    /// Command bus must handle this methods
    /// </summary>
    public interface ICommandBus
    {
        Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand;

        Task Send<TCommand>(TCommand command) where TCommand : ICommand;

        Task<TResult> SendAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand<TResult>;

        Task<TResult> Send<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>;

    }
}
