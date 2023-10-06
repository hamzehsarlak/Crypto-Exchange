using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CryptoExchange.CoinMarketCap.Models.Response
{
    public class ListingsResponse : GenericResponse<ListingsResponseData>
    {
        
    }
    
    public class ListingsResponseData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("quote")]
        public Dictionary<string, ListingsResponseQuote> Quote { get; set; }
    }

    public class ListingsResponseQuote
    {
        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }
    }
}