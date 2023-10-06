using System.Collections.Generic;
using CryptoExchange.Core.IMediatR;
using CryptoExchange.Integration.Dtos.Listing;

namespace CryptoExchange.Integration.Queries
{
    public class GetCachedListingsQuery : MediatRQueryBase<IEnumerable<ListingDto>>
    {
    }
}