using Knab.Core.Abstraction.CQRS;
using Knab.Integration.Dtos;
using Knab.Integration.Dtos.Listing;
using Knab.Integration.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Knab.Web.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class ListingsController : ControllerBase
    {
        private readonly ILogger<ListingsController> _logger;
        private readonly IQueryBus _queryBus;

        public ListingsController(ILogger<ListingsController> logger, IQueryBus queryBus)
        {
            _logger = logger;
            _queryBus = queryBus;
        }
        [HttpGet]
        public async Task<IEnumerable<ListingDto>> GetAllListings()
        {
            return await _queryBus.SendAsync<GetCachedListingsQuery, IEnumerable<ListingDto>>(new GetCachedListingsQuery());
        }
        
        [HttpGet]
        public async Task<IEnumerable<ConversionDto>> GetAllConversions()
        {
            return await _queryBus.SendAsync<GetConversionsQuery, IEnumerable<ConversionDto>>(new GetConversionsQuery());
        }
    }
}
