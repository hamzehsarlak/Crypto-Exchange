using System;

namespace Knab.Core.Abstraction.Data.Entity
{
    /// <summary>
    /// Entity must have a id
    /// </summary>
    public interface IEntity<out TKey> : IEntityId<TKey>
    {
    }

    /// <summary>
    /// Simple entity must have a guid 
    /// </summary>
    public interface IEntity : IEntity<Guid>
    {
    }
}