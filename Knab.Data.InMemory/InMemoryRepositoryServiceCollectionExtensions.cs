using Knab.Core.Abstraction.Data;
using Knab.Core.Abstraction.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Knab.Data.InMemory
{
    public static class InMemoryRepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddInMemoryRepository<TEntity>(this IServiceCollection services) where TEntity : class, IEntityId
        {
            services.TryAddScoped<IRepository<TEntity>, InMemoryRepository<TEntity>>();
            return services;
        }
    }
}