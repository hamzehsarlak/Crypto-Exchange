using System;
using CryptoExchange.Application.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CryptoExchange.Application.ExchangeRatesApi
{
    public static class ExchangeRatesApiServiceCollectionExtensions
    {
        public static IServiceCollection AddExchangeRatesApi(this IServiceCollection services, Action<ExchangeRatesApiOptions> setupAction)
        {
            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }
            services.TryAddScoped<IRateService, ExchangeRatesApiService>();
            var options = new ExchangeRatesApiOptions();
            setupAction(options);
            services.Configure(setupAction);
            return services;
        }
    }
}