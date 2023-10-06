using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CryptoExchange.Core.Abstraction.Data;
using CryptoExchange.Core.IMediatR.Abstraction;
using CryptoExchange.Domain.Entities;
using CryptoExchange.Integration.Dtos.Rate;
using CryptoExchange.Integration.Queries;

namespace CryptoExchange.Application.QueryHandlers
{
    public class GetCachedRatesQueryHandler : IMediatRQueryHandler<GetCachedRatesQuery, IEnumerable<RateDto>>
    {
        private readonly IRepository<RateEntity> _rateRepository;

        public GetCachedRatesQueryHandler(IRepository<RateEntity> rateRepository)
        {
            _rateRepository = rateRepository;
        }

        public async Task<IEnumerable<RateDto>> Handle(GetCachedRatesQuery request, CancellationToken cancellationToken)
        {
            var rates = await _rateRepository.GetAllAsync(cancellationToken);
            
            return rates.Select(r => new RateDto
            {
                Symbol = r.Id,
                Rate = r.Rate
            });
        }
    }
}