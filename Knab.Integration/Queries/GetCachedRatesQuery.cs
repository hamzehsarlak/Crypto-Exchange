using System.Collections.Generic;
using Knab.Core.IMediatR;
using Knab.Integration.Dtos.Rate;

namespace Knab.Integration.Queries
{
    public class GetCachedRatesQuery : MediatRQueryBase<IEnumerable<RateDto>>
    {
        
    }
}