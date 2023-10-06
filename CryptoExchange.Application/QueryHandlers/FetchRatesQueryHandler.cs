using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Application.Abstraction;
using CryptoExchange.Core.IMediatR.Abstraction;
using CryptoExchange.Integration.Queries;

namespace CryptoExchange.Application.QueryHandlers
{
    public class FetchRatesQueryHandler : IMediatRQueryHandler<FetchRatesQuery, Dictionary<string, double>>
    {
        private readonly IRateService _rateService;

        public FetchRatesQueryHandler(IRateService rateService)
        {
            _rateService = rateService;
        }

        public async Task<Dictionary<string, double>> Handle(FetchRatesQuery request, CancellationToken cancellationToken)
        {
            return await _rateService.GetRatesAsync(request, cancellationToken);
        }
    }
}
