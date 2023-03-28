using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Knab.Core.Abstraction.Data;
using Knab.Core.IMediatR.Abstraction;
using Knab.Domain.Entities;
using Knab.Integration.Dtos.Rate;
using Knab.Integration.Queries;

namespace Knab.Application.QueryHandlers
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