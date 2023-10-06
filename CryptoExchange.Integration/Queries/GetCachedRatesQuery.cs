using System.Collections.Generic;
using CryptoExchange.Core.IMediatR;
using CryptoExchange.Integration.Dtos.Rate;

namespace CryptoExchange.Integration.Queries
{
    public class GetCachedRatesQuery : MediatRQueryBase<IEnumerable<RateDto>>
    {
        
    }
}