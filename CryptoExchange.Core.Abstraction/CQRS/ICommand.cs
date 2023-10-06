using System;

namespace CryptoExchange.Core.Abstraction.CQRS
{
    /// <summary>
    /// Contract to mark all commands without result
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Command uniq id
        /// </summary>
        Guid Id { get; }
    }

    /// <summary>
    /// Contract to mark all commands with result
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface ICommand<TResult> : ICommand
    {
    }
}
