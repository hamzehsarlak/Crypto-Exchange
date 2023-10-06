using System.Collections.Generic;
using CryptoExchange.Core.IMediatR;
using CryptoExchange.Integration.Dtos.CryptoCurrency;

namespace CryptoExchange.Integration.Queries
{
    public class FetchAllCryptoCurrenciesQuery : MediatRQueryBase<IEnumerable<CryptoCurrencyDto>>
    {

    }
}
