using System;
using System.Collections.Generic;

namespace Knab.Application.ExchangeRatesApi
{
    public static class ExchangeRatesApiConstants
    {
        public const string BaseUrl = "https://api.apilayer.com";
        public const string RatesLatest = "/exchangerates_data/latest";
        private const string QsSymbols = "symbols";
        private const string QsBase = "base";
        private const string HeaderApiKey = "apikey";

        public static List<Tuple<string, string>> GetRatesQueryParams(string baseSymbol, IEnumerable<string> symbols) =>
            new List<Tuple<string, string>>
            {
                new Tuple<string, string>(QsBase, baseSymbol),
                new Tuple<string, string>(QsSymbols, string.Join(',', symbols))
            };

        public static Dictionary<string, string> GetDefaultHeaders(string apiKey) =>
            new Dictionary<string, string>(new[]
            {
                GetApiKeyHeader(apiKey),
            });

        public static KeyValuePair<string, string> GetApiKeyHeader(string apiKey) =>
            new KeyValuePair<string, string>(HeaderApiKey, apiKey);
    }
}