using System;
using Knab.Core.IMediatR.Abstraction;

namespace Knab.Core.IMediatR
{
    public abstract class MediatRQueryBase<TResult> : IMediatRQuery<TResult>
    {
        protected MediatRQueryBase()
        {
            Id = Guid.NewGuid();
        }

        protected MediatRQueryBase(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
