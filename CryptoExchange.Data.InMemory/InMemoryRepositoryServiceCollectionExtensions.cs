using CryptoExchange.Core.Abstraction.Data;
using CryptoExchange.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CryptoExchange.Data.InMemory
{
    public static class InMemoryRepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddInMemoryRepository(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.TryAddScoped<IRepository<CryptoCurrencyEntity>, InMemoryRepository<CryptoCurrencyEntity>>();
            services.TryAddScoped<IRepository<ListingEntity>, InMemoryRepository<ListingEntity>>();
            services.TryAddScoped<IRepository<RateEntity>, InMemoryRepository<RateEntity>>();
            return services;
        }
    }
}