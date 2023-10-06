using System;
using CryptoExchange.Application.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CryptoExchange.CoinMarketCap
{
    public static class CoinMarketCapServiceCollectionExtensions
    {
        public static IServiceCollection AddCoinMarketCap(this IServiceCollection services, Action<CoinMarketCapOptions> setupAction)
        {
            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }
            services.TryAddScoped<ICryptoCurrencyService, CoinMarketCapService>();
            var options = new CoinMarketCapOptions();
            setupAction(options);
            services.Configure(setupAction);
            return services;
        }
    }
}