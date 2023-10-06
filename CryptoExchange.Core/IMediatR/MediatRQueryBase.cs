using System;
using CryptoExchange.Core.IMediatR.Abstraction;

namespace CryptoExchange.Core.IMediatR
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
