using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Core.Abstraction.Data;
using CryptoExchange.Core.Abstraction.Data.Entity;
using Microsoft.Extensions.Caching.Memory;

namespace CryptoExchange.Data.InMemory
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

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            _memoryCache.TryGetValue(typeof(TEntity).FullName, out IEnumerable<TEntity>? entities);
            return await Task.FromResult(entities ?? new List<TEntity>());
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

        public async Task<IEnumerable<TEntity>> Upsert(IEnumerable<TEntity> entities,
            CancellationToken cancellationToken = default)
        {
            return await _memoryCache.GetOrCreateAsync(
                typeof(TEntity).FullName,
                cacheEntry =>
                {
                    cacheEntry.SlidingExpiration = TimeSpan.FromHours(24);
                    return Task.FromResult(entities);
                }) ?? new List<TEntity>();
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