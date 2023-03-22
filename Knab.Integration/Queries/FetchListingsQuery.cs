using System.Collections.Generic;
using Knab.Core.IMediatR;
using Knab.Integration.Dtos.Listing;

namespace Knab.Integration.Queries
{
    public class FetchListingsQuery : MediatRQueryBase<IEnumerable<ListingDto>>
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
