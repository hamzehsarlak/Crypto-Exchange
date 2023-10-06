using System;
using CryptoExchange.Core.Abstraction.CQRS;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RestSharp.Serialization;

namespace CryptoExchange.Core.RestSharp
{
    public static class RestSharpBusServiceCollectionExtensions
    {
        public static IServiceCollection AddRestSharpBus(this IServiceCollection services, Action<RestSharpOptions> setupAction)
        {
            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }
            var options = new RestSharpOptions();
            setupAction(options);
            services.Configure(setupAction);
            services.TryAddScoped<IRestCommandBus, RestSharpCommandBus>();
            services.TryAddScoped<IRestQueryBus, RestSharpQueryBus>();
            services.TryAddScoped<IRestSerializer, RestSharpSerializer>();
            return services;
        }
    }
}
