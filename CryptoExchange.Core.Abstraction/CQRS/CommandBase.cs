using System;

namespace CryptoExchange.Core.Abstraction.CQRS
{
    public abstract class CommandBase : ICommand
    {
        protected CommandBase(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public abstract class CommandBase<T> : ICommand<T>
    {
        protected CommandBase(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
