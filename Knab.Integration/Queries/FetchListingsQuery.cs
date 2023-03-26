using System.Collections.Generic;
using Knab.Core.IMediatR;
using Knab.Integration.Dtos.Listing;

namespace Knab.Integration.Queries
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