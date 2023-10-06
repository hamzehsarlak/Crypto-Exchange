using CryptoExchange.Core.IMediatR.Abstraction;
using CryptoExchange.Core.Abstraction.CQRS;
using CryptoExchange.Core.Infrastructure;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoExchange.Core.IMediatR
{
    public static class MediatRServiceCollectionExtensions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Mediator"/> class.
        /// And register it to ServiceCollection
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="withLifetime">ServiceLifetime</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddMediatR(this IServiceCollection services,
            ServiceLifetime withLifetime = ServiceLifetime.Transient)
        {
            services.Add<IMediator, Mediator>(withLifetime)
                .AddTransient<ServiceFactory>(sp => sp.GetRequiredService!)
                .Add<ServiceFactory>(sp => sp.GetService, withLifetime)
                .Add(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>), withLifetime)
                .Add<ICommandBus, MediatRCommandBus>(withLifetime)
                .Add<IQueryBus, MediatRQueryBus>(withLifetime);
            return services;
        }
        /// <summary>
        /// Auto register all command and query handlers
        /// </summary>
        /// <param name="services"></param>
        /// <param name="withLifetime"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static IServiceCollection AddAllMediatRHandlers(
            this IServiceCollection services,
            ServiceLifetime withLifetime = ServiceLifetime.Transient,
            AssemblySelector from = AssemblySelector.ApplicationDependencies)
        {
            return services
                .AddAllMediatRCommandHandlers(withLifetime, from)
                .AddAllMediatRQueryHandlers(withLifetime, from);
        }


        /// <summary>
        /// Add a pair of command and its command handler
        /// </summary>
        /// <typeparam name="TCommand">TCommand</typeparam>
        /// <typeparam name="TCommandHandler">TCommandHandler</typeparam>
        /// <param name="services">IServiceCollection</param>
        /// <param name="withLifetime">ServiceLifetime</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddMediatRCommandHandler<TCommand, TCommandHandler>(
            this IServiceCollection services, ServiceLifetime withLifetime = ServiceLifetime.Transient)
            where TCommand : IMediatRCommand
            where TCommandHandler : class, IMediatRCommandHandler<TCommand>
        {
            return services.Add<TCommandHandler>(withLifetime)
                .Add<IRequestHandler<TCommand, Unit>>(sp => sp.GetService<TCommandHandler>(), withLifetime)
                .Add<IMediatRCommandHandler<TCommand>>(sp => sp.GetService<TCommandHandler>(), withLifetime);
        }

        /// <summary>
        /// Add a pair of query and its query handler
        /// </summary>
        /// <typeparam name="TQuery">TQuery</typeparam>
        /// <typeparam name="TResponse">TResponse</typeparam>
        /// <typeparam name="TQueryHandler">TQueryHandler</typeparam>
        /// <param name="services">IServiceCollection</param>
        /// <param name="withLifetime">ServiceLifetime</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddMediatRQueryHandler<TQuery, TResponse, TQueryHandler>(
            this IServiceCollection services, ServiceLifetime withLifetime = ServiceLifetime.Transient)
            where TQuery : IMediatRQuery<TResponse>
            where TQueryHandler : class, IMediatRQueryHandler<TQuery, TResponse>
        {
            return services.Add<TQueryHandler>(withLifetime)
                .Add<IRequestHandler<TQuery, TResponse>>(sp => sp.GetService<TQueryHandler>(), withLifetime)
                .Add<IMediatRQueryHandler<TQuery, TResponse>>(sp => sp.GetService<TQueryHandler>(), withLifetime);
        }

        /// <summary> 
        /// Register ValidationPipeline 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="withLifetime"></param>
        /// <returns></returns>
        public static IServiceCollection AddValidationPipeline(this IServiceCollection services,
            ServiceLifetime withLifetime = ServiceLifetime.Transient)
        {
            return services.Add(typeof(IRequestPreProcessor<>), typeof(ValidationPipeline<>), withLifetime);
        }

        /// <summary>
        /// AssemblySelector for all type of IMediatRCommandHandler
        /// </summary>
        /// <param name="services"></param>
        /// <param name="withLifetime"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        private static IServiceCollection AddAllMediatRCommandHandlers(
            this IServiceCollection services,
            ServiceLifetime withLifetime = ServiceLifetime.Transient,
            AssemblySelector from = AssemblySelector.ApplicationDependencies)
        {
            return services.Scan(scan => scan
                .FromAssemblies(from)
                .AddClasses(classes =>
                    classes.AssignableTo(typeof(IMediatRCommandHandler<,>))
                        .Where(c => !c.IsAbstract && !c.IsGenericTypeDefinition))
                .AsSelfWithInterfaces()
                .WithLifetime(withLifetime)
            );
        }

        /// <summary>
        /// AssemblySelector for all type of IMediatRQueryHandler
        /// </summary>
        /// <param name="services"></param>
        /// <param name="withLifetime"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        private static IServiceCollection AddAllMediatRQueryHandlers(
            this IServiceCollection services,
            ServiceLifetime withLifetime = ServiceLifetime.Transient,
            AssemblySelector from = AssemblySelector.ApplicationDependencies)
        {
            return services.Scan(scan => scan
                .FromAssemblies(from)
                .AddClasses(classes =>
                    classes.AssignableTo(typeof(IMediatRQueryHandler<,>))
                        .Where(c => !c.IsAbstract && !c.IsGenericTypeDefinition))
                .AsSelfWithInterfaces()
                .WithLifetime(withLifetime)
            );
        }

        

    }
}
