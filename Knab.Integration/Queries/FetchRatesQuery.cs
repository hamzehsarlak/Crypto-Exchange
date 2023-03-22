using System.Collections.Generic;
using Knab.Core.IMediatR;
using Knab.Integration.Dtos.Listing;
using Knab.Integration.Dtos.Rate;

namespace Knab.Integration.Queries
{
    public class FetchRatesQuery : MediatRQueryBase<IEnumerable<RateDto>>
    {

    }
}
