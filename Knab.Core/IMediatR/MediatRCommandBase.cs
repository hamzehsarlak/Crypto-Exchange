using System;
using Knab.Core.IMediatR.Abstraction;

namespace Knab.Core.IMediatR
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
