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

        protected MediatRCommandBase(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
