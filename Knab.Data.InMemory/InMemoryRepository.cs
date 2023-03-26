using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Knab.Core.Abstraction.Data;
using Knab.Core.Abstraction.Data.Entity;
using Microsoft.Extensions.Caching.Memory;

namespace Knab.Data.InMemory
{
    public class InMemoryRepository<TEntity>: IRepository<TEntity>
        where TEntity : class, IEntityId
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task SaveChanges(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task<TEntity> FindById(object id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Add(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Upsert(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Upsert(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Update(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Delete(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Delete(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(object id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(IEnumerable<object> id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        
        public void Dispose()
        {
            
        }
    }
}