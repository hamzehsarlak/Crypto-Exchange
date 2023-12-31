﻿using CryptoExchange.Core.Abstraction.CQRS;
using CryptoExchange.Integration.Dtos.Rate;
using CryptoExchange.Integration.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CryptoExchange.Web.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class RatesController : ControllerBase
    {
        private readonly ILogger<RatesController> _logger;
        private readonly IQueryBus _queryBus;

        public RatesController(ILogger<RatesController> logger, IQueryBus queryBus)
        {
            _logger = logger;
            _queryBus = queryBus;
        }

        [HttpGet]
        public async Task<IEnumerable<RateDto>> GetAllRates()
        {
            return await _queryBus.SendAsync<GetCachedRatesQuery, IEnumerable<RateDto>>(new GetCachedRatesQuery());
        }
    }
}
