using System;
using System.Threading.Tasks;
using Hangfire;
using CryptoExchange.Core.Abstraction.TaskExecutor;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace CryptoExchange.Application.TaskScheduler
{
    public static class HangFireTaskSchedulerServiceCollectionExtensions
    {
        public static IServiceCollection AddHangFireTaskScheduler(this IServiceCollection services)
        {
            GlobalConfiguration.Configuration.UseInMemoryStorage();
            
            // Add Hangfire services.
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings());

            // Add the processing server as IHostedService
            services.AddHangfireServer();
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 0 });
            
            // Add TaskScheduler
            services.TryAddScoped<IUpdateTaskExecutor, HangFireTaskSchedulerBuilder>();
            return services;
        }
        
        public static async Task<IApplicationBuilder> UseHangFireTaskScheduler(
            this IApplicationBuilder app,
            Action<HangFireTaskSchedulerOptions> setupAction)
        {
            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<HangFireTaskSchedulerOptions>>().Value;
                setupAction.Invoke(options);
                
                // Init the cache 
                await scope.ServiceProvider.GetService<IUpdateTaskExecutor>()?.Execute()!;
                ScheduleJobs(options);
            }
            return app;
        }

        public static IApplicationBuilder MapClientHub(
            this WebApplication app)
        {
            app.MapHub<ClientHub>("/clientHub");
            return app;
        }

        private static void ScheduleJobs(HangFireTaskSchedulerOptions options)
        {
            // rates
            RecurringJob.AddOrUpdate<IUpdateTaskExecutor>(ts => ts.UpdateRates(),
                options.RateApiMonthlyRequestLimitTimeSpan.ToRecurringCronExpression());
            
            // listings
            RecurringJob.AddOrUpdate<IUpdateTaskExecutor>(ts => ts.UpdateListings(), 
                options.ListingApiMonthlyRequestLimitTimeSpan.ToRecurringCronExpression());
        }
    }
}