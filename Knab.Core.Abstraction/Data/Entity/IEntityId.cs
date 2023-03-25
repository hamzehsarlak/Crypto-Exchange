using System;

namespace Knab.Core.Abstraction.Data.Entity
{
    /// <summary>
    /// Base entity is type can be overriden
    /// </summary>
    public interface IEntityId
    {
        object Id { get; }
    }
    /// <summary>
    /// Custom entity type id
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityId<out T> : IEntityId
    {
        new T Id { get; }
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