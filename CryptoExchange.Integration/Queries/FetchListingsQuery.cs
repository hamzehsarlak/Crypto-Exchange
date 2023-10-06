using System.Collections.Generic;
using CryptoExchange.Core.IMediatR;
using CryptoExchange.Integration.Dtos.Listing;

namespace CryptoExchange.Integration.Queries
{
    public class FetchListingsQuery : MediatRQueryBase<IEnumerable<ListingDto>>
    {
        public FetchListingsQuery(int limit = 100, int offset = 1)
        {
            Limit = limit;
            Offset = offset;
        }

        public int Offset { get; }
        public int Limit { get; }
    }
}