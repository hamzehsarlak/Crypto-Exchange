using System;
using System.Threading;
using System.Threading.Tasks;
using Knab.Core.Abstraction.Data.Entity;

namespace Knab.Core.Abstraction.Data
{
    public interface IRepository:IDisposable
    {
        Task SaveChanges(CancellationToken cancellationToken = default);
    }

    public interface IRepository<TEntity> :IRepository where TEntity : class, IEntityId
    {
        Task<TEntity> FindById(object id, CancellationToken cancellationToken = default);

        Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity> Update(TEntity entity, int expectedVersion, CancellationToken cancellationToken = default);

        Task<TEntity> Delete(TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity> Delete(TEntity entity, int expectedVersion, CancellationToken cancellationToken = default);

        Task<bool> DeleteById(object id, CancellationToken cancellationToken = default);

        Task<bool> DeleteById(object id, int expectedVersion, CancellationToken cancellationToken = default);
    }
}