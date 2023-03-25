using System.Collections.Generic;
using Knab.Core.IMediatR;
using Knab.Integration.Dtos.Rate;

namespace Knab.Integration.Queries
{
    public class FetchRatesQuery : MediatRQueryBase<IEnumerable<RateDto>>
    {
        public string BaseSymbol { get; set; }

        // output currencies
        public List<string> Symbols { get; set; }

    }
}
