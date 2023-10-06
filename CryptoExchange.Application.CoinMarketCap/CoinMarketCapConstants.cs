using System;
using System.Collections.Generic;

namespace CryptoExchange.CoinMarketCap
{
    public static class CoinMarketCapConstants
    {
        public const string BaseUrl = "https://pro-api.coinmarketcap.com";
        public const string UrlListingsLatest = "/v1/cryptocurrency/listings/latest";
        private const string QsStart = "start";
        private const string QsLimit = "limit";
        private const string QsConvert = "convert";
        private const string HeaderApiKey = "X-CMC_PRO_API_KEY";
        public const string BtcSymbol = "BTC";
        public const string UsdSymbol = "USD";
        

        public static List<Tuple<string, string>> GetQueryParams(int offset, int limit) =>
            new List<Tuple<string, string>>
            {
                new Tuple<string, string>(QsStart, offset.ToString()),
                new Tuple<string, string>(QsLimit, limit.ToString())
            };

        public static Dictionary<string, string> GetDefaultHeaders(string apiKey) =>
            new Dictionary<string, string>(new[]
            {
                GetApiKeyHeader(apiKey),
                new KeyValuePair<string, string>("Accept", "*/*")
            });
        
        public static KeyValuePair<string, string> GetApiKeyHeader(string apiKey) => new KeyValuePair<string, string>(HeaderApiKey, apiKey);
    }
}