using System;
using CryptoExchange.Core.IMediatR.Abstraction;

namespace CryptoExchange.Core.IMediatR
{
    public abstract class MediatRCommandBase<TResult> : IMediatRCommand<TResult>
    {
        protected MediatRCommandBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
    }
    public abstract class MediatRCommandBase : IMediatRCommand
    {
        protected MediatRCommandBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
    }
}
