using System.Runtime.CompilerServices;
using Knab.Application.ExchangeRatesApi.Models.Responses;
using Knab.CoinMarketCap.Models.Response;
using Knab.Integration.Dtos.CryptoCurrency;
using Knab.Integration.Dtos.Listing;
using Knab.Integration.Dtos.Rate;

namespace Knab.Tests;

public static class TestData
{
    public static readonly List<ListingDto> ListingDtos = new()
    {
        new ListingDto
        {
            Id = 1,
            BtcPrice = 1,
            UsdPrice = 20000,
            CryptoCurrencyDto = new CryptoCurrencyDto
            {
                Id = 1,
                Name = "Bitcoin",
                Slug = "btc",
                Symbol = "BTC"
            }
        },
        new ListingDto
        {
            Id = 2,
            BtcPrice = 0.01,
            UsdPrice = 2000,
            CryptoCurrencyDto = new CryptoCurrencyDto
            {
                Id = 2,
                Name = "Ethereum",
                Slug = "eth",
                Symbol = "ETH"
            }
        }
    };

    public static readonly List<RateDto> RateDtos = new()
    {
        new RateDto
        {
            Symbol = "EUR",
            Rate = 0.92931
        },
        new RateDto
        {
            Symbol = "BRL",
            Rate = 5.246801
        },
        new RateDto
        {
            Symbol = "GBP",
            Rate = 0.81692
        },
        new RateDto
        {
            Symbol = "AUD",
            Rate = 1.50479
        },
    };

    public static readonly ListingsResponse ListingsResponse = new()
    {
        Data = new List<ListingsResponseData>
        {
            new()
            {
                Id = 1,
                Name = "Bitcoin",
                Slug = "btc",
                Symbol = "BTC",
                Quote = new Dictionary<string, ListingsResponseQuote>
                {
                    {
                        "USD", new ListingsResponseQuote
                        {
                            Price = 20000
                        }
                    }
                }
            },
            new()
            {
                Id = 2,
                Name = "Ethereum",
                Slug = "eth",
                Symbol = "ETH",
                Quote = new Dictionary<string, ListingsResponseQuote>
                {
                    {
                        "USD", new ListingsResponseQuote
                        {
                            Price = 2000
                        }
                    }
                },
            }
        }
    };

    public static readonly RatesResponse RatesResponse = new()
    {
        Success = true,
        Rates = RateDtos.ToDictionary(r => r.Symbol, dto => dto.Rate)
    };
}