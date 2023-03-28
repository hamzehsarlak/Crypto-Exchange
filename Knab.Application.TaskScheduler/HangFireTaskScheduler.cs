using System.Collections.Generic;
using System.Threading.Tasks;
using Knab.Core.Abstraction.CQRS;
using Knab.Core.Abstraction.TaskExecutor;
using Knab.Integration.Commands;
using Knab.Integration.Dtos.Listing;
using Knab.Integration.Queries;
using Microsoft.AspNetCore.SignalR;

namespace Knab.Application.TaskScheduler
{
    public class HangFireTaskSchedulerBuilder : UpdateTaskExecutor
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        private readonly IHubContext<ClientHub> _hubContext;

        public HangFireTaskSchedulerBuilder(IQueryBus queryBus,
            ICommandBus commandBus, IHubContext<ClientHub> hubContext)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
            _hubContext = hubContext;
        }

        public override async Task UpdateRates()
        {
            // get EUR,BRL,GBP,AUD rates for USD
            var rates = await _queryBus.SendAsync<FetchRatesQuery, Dictionary<string, double>>(new FetchRatesQuery());

            await _commandBus.SendAsync<UpdateRatesCommand, bool>(new UpdateRatesCommand(rates));
            
            await Notify();
        }

        public override async Task UpdateListings()
        {
            // get top 100 listings
            var listings =
                await _queryBus.SendAsync<FetchListingsQuery, IEnumerable<ListingDto>>(new FetchListingsQuery());

            // save listings
            await _commandBus.SendAsync<UpdateListingsCommand, bool>(new UpdateListingsCommand(listings));

            await Notify();
        }

        public override async Task Notify()
        {
            await _hubContext.Clients.All.SendAsync("conversions", "updated");
        }
    }
}