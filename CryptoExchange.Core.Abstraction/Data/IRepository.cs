using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Core.Abstraction.Data.Entity;

namespace CryptoExchange.Core.Abstraction.Data
{
    public interface IRepository : IDisposable
    {
        Task SaveChanges(CancellationToken cancellationToken = default);
    }

    public interface IRepository<TEntity> : IRepository where TEntity : class, IEntityId
    {
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        
        Task<TEntity> FindById(object id, CancellationToken cancellationToken = default);

        Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity> Add(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> Upsert(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        
        Task<TEntity> Upsert(TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity> Update(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task<TEntity> Delete(TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity> Delete(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task<bool> DeleteById(object id, CancellationToken cancellationToken = default);

        Task<bool> DeleteById(IEnumerable<object> id, CancellationToken cancellationToken = default);
    }
}