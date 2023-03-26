using System.Collections.Generic;
using System.Threading.Tasks;
using Hangfire;
using Knab.Core.Abstraction.CQRS;
using Knab.Core.Abstraction.TaskScheduler;
using Knab.Integration.Commands;
using Knab.Integration.Dtos.Listing;
using Knab.Integration.Queries;

namespace Knab.Application.TaskScheduler
{
    public class HangFireTaskSchedulerBuilder : TaskSchedulerBuilder
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public HangFireTaskSchedulerBuilder(IQueryBus queryBus,
            ICommandBus commandBus)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
        }

        public override async Task UpdateRates()
        {
            // get EUR,BRL,GBP,AUD rates for USD
            var rates = await _queryBus.SendAsync<FetchRatesQuery, Dictionary<string, double>>(new FetchRatesQuery());

            // save rates
            await _commandBus.SendAsync<UpdateRatesCommand, bool>(new UpdateRatesCommand(rates));
        }

        public override async Task UpdateListings()
        {
            // get top 100 listings
            var listings =
                await _queryBus.SendAsync<FetchListingsQuery, IEnumerable<ListingDto>>(new FetchListingsQuery());

            // save listings
            await _commandBus.SendAsync<UpdateListingsCommand, bool>(new UpdateListingsCommand(listings));
        }

        public override void Schedule()
        {
            // rates
            RecurringJob.AddOrUpdate(() => UpdateRates(), Cron.Daily);

            // listings
            RecurringJob.AddOrUpdate(() => UpdateListings(), Cron.Daily);
        }
    }
}