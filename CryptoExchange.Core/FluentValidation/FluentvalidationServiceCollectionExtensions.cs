using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoExchange.Core.FluentValidation
{
    public static class FluentValidationServiceCollectionExtensions
    {
        public static IServiceCollection AddAllValidators(this IServiceCollection services,
            ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            services.Scan(scan => scan
                .FromApplicationDependencies()
                .AddClasses(classes => classes.Where(t => !t.IsGenericType).AssignableTo(typeof(IValidator<>)))
                .AsImplementedInterfaces()
                .WithLifetime(serviceLifetime));

            return services;
        }
    }
}
