using System.Collections.Generic;
using Knab.Core.IMediatR;
using Knab.Integration.Dtos.CryptoCurrency;

namespace Knab.Integration.Queries
{
    public class FetchAllCryptoCurrenciesQuery : MediatRQueryBase<IEnumerable<CryptoCurrencyDto>>
    {

    }
}
