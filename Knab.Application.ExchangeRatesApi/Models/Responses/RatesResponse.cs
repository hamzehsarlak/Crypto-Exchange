using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Knab.Application.ExchangeRatesApi.Models.Responses
{
    public class RatesResponse
    {
        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("rates")]
        public Dictionary<string, double> Rates { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}
