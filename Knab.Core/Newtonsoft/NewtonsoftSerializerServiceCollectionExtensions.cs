using System;
using Knab.Core.Abstraction.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Knab.Core.Newtonsoft
{
    public static class NewtonsoftSerializerServiceCollectionExtensions
    {
        public static IServiceCollection AddNewtonSerializer(this IServiceCollection services, Action<NewtonsoftSerializerOptions> setupAction)
        {
            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }
            services.TryAddSingleton<ISerializer, NewtonSerializer>();
            var options = new NewtonsoftSerializerOptions();
            setupAction(options);
            services.Configure(setupAction);
            return services;
        }
    }
}
