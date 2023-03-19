using System;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Knab.Core.Infrastructure
{
    public static class RegistrationExtensions
    {
        /// <summary>
        /// Adds a transient service of the type specified in TService with an implementation
        /// type specified in TImplementation using the factory specified in implementationFactory
        /// to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service</param>
        /// <param name="implementationFactory">The factory that creates the service.</param>
        /// <param name="serviceLifetime">Service Lifetime</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection Add<TService, TImplementation>(this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory,
            ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
            where TService : class
            where TImplementation : class, TService
        {
            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    return services.AddSingleton<TService, TImplementation>(implementationFactory);

                case ServiceLifetime.Scoped:
                    return services.AddScoped<TService, TImplementation>(implementationFactory);

                case ServiceLifetime.Transient:
                    return services.AddTransient<TService, TImplementation>(implementationFactory);

                default:
                    throw new ArgumentNullException(nameof(serviceLifetime));
            }
        }

        /// <summary>
        /// Adds a transient service of the type specified in TService with a factory specified
        /// in implementationFactory to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service</param>
        /// <param name="implementationFactory">The factory that creates the service.</param>
        /// <param name="serviceLifetime">Service Lifetime</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection Add<TService>(this IServiceCollection services,
            Func<IServiceProvider, TService> implementationFactory,
            ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
            where TService : class
        {
            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    return services.AddSingleton(implementationFactory);

                case ServiceLifetime.Scoped:
                    return services.AddScoped(implementationFactory);

                case ServiceLifetime.Transient:
                    return services.AddTransient(implementationFactory);

                default:
                    throw new ArgumentNullException(nameof(serviceLifetime));
            }
        }

        /// <summary>
        /// Adds a transient service of the type specified in TService to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service</param>
        /// <param name="serviceLifetime"></param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection Add<TService>(this IServiceCollection services,
            ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
            where TService : class
        {
            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    return services.AddSingleton<TService>();

                case ServiceLifetime.Scoped:
                    return services.AddScoped<TService>();

                case ServiceLifetime.Transient:
                    return services.AddTransient<TService>();

                default:
                    throw new ArgumentNullException(nameof(serviceLifetime));
            }
        }

        /// <summary>
        /// Adds a transient service of the type specified in serviceType to the specified
        /// Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service</param>
        /// <param name="serviceType">The type of the service to register and the implementation to use.</param>
        /// <param name="serviceLifetime"></param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection Add(this IServiceCollection services, Type serviceType,
            ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    return services.AddSingleton(serviceType);

                case ServiceLifetime.Scoped:
                    return services.AddScoped(serviceType);

                case ServiceLifetime.Transient:
                    return services.AddTransient(serviceType);

                default:
                    throw new ArgumentNullException(nameof(serviceLifetime));
            }
        }

        /// <summary>
        /// Adds a transient service of the type specified in TService with an implementation
        /// type specified in TImplementation to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service</param>
        /// <param name="serviceLifetime"></param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection Add<TService, TImplementation>(this IServiceCollection services,
            ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
            where TService : class
            where TImplementation : class, TService
        {
            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    return services.AddSingleton<TService, TImplementation>();

                case ServiceLifetime.Scoped:
                    return services.AddScoped<TService, TImplementation>();

                case ServiceLifetime.Transient:
                    return services.AddTransient<TService, TImplementation>();

                default:
                    throw new ArgumentNullException(nameof(serviceLifetime));
            }
        }

        /// <summary>
        /// Adds a transient service of the type specified in serviceType with a factory
        /// specified in implementationFactory to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service</param>
        /// <param name="serviceType">The type of the service to register.</param>
        /// <param name="implementationFactory">The factory that creates the service.</param>
        /// <param name="serviceLifetime"></param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection Add(this IServiceCollection services, Type serviceType,
            Func<IServiceProvider, object> implementationFactory,
            ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    return services.AddSingleton(serviceType, implementationFactory);

                case ServiceLifetime.Scoped:
                    return services.AddScoped(serviceType, implementationFactory);

                case ServiceLifetime.Transient:
                    return services.AddTransient(serviceType, implementationFactory);

                default:
                    throw new ArgumentNullException(nameof(serviceLifetime));
            }
        }

        /// <summary>
        /// Adds a transient service of the type specified in serviceType with an implementation
        /// of the type specified in implementationType to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service</param>
        /// <param name="serviceType">The type of the service to register.</param>
        /// <param name="implementationType">The implementation type of the service.</param>
        /// <param name="serviceLifetime"></param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection Add(this IServiceCollection services, Type serviceType,
            Type implementationType, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    return services.AddSingleton(serviceType, implementationType);

                case ServiceLifetime.Scoped:
                    return services.AddScoped(serviceType, implementationType);

                case ServiceLifetime.Transient:
                    return services.AddTransient(serviceType, implementationType);

                default:
                    throw new ArgumentNullException(nameof(serviceLifetime));
            }
        }
        /// <summary>
        /// Scrutor query builder helper
        /// </summary>
        /// <param name="assemblySelector"></param>
        /// <param name="assemblySelection"></param>
        /// <returns></returns>
        public static IImplementationTypeSelector FromAssemblies(this IAssemblySelector assemblySelector,
            AssemblySelector assemblySelection = AssemblySelector.ApplicationDependencies)
        {
            switch (assemblySelection)
            {
                case AssemblySelector.ApplicationDependencies:
                    return assemblySelector.FromApplicationDependencies();

                case AssemblySelector.CallingAssembly:
                    return assemblySelector.FromCallingAssembly();

                default:
                    throw new ArgumentOutOfRangeException(nameof(assemblySelection), assemblySelection,
                        $"Value {assemblySelection} is not supported");
            }
        }

    }
}
