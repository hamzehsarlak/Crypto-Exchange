using System.Collections.Generic;
using Knab.Core.IMediatR;
using Knab.Integration.Dtos.Listing;

namespace Knab.Integration.Queries
{
    public class FetchTopListingsQuery : MediatRQueryBase<IEnumerable<ListingDto>>
    {
        public int Count { get; set; }
    }
}
