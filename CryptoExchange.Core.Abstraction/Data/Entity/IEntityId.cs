using System;

namespace CryptoExchange.Core.Abstraction.Data.Entity
{
    /// <summary>
    /// Base entity is type can be overriden
    /// </summary>
    public interface IEntityId
    {
    }
    /// <summary>
    /// Custom entity type id
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityId<out T> : IEntityId
    {
        T Id { get; }
    }
    /// <summary>
    /// Guid entity id
    /// </summary>
    public interface IEntityGuidId : IEntityId<Guid>
    {
    }
    /// <summary>
    /// String entity id
    /// </summary>
    public interface IEntityStringId : IEntityId<string>
    {
    }
    /// <summary>
    /// Int entity id
    /// </summary>
    public interface IEntityIntId : IEntityId<int>
    {
    }
}