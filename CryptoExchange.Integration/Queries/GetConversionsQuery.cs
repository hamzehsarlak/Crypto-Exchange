using System.Collections.Generic;
using CryptoExchange.Core.IMediatR;
using CryptoExchange.Integration.Dtos;

namespace CryptoExchange.Integration.Queries
{
    public class GetConversionsQuery : MediatRQueryBase<IEnumerable<ConversionDto>>
    {
        
    }
}