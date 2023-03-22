using System;
using Newtonsoft.Json;

namespace Knab.CoinMarketCap.Models.Response
{
    public abstract class GenericResponse<T>
    {
        [JsonProperty("data")]
        public T[] Data { get; set; }

        [JsonProperty("status")]
        public ListingsResponseStatus Status { get; set; }
    }
    public class ListingsResponseStatus
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("error_code")]
        public long ErrorCode { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("elapsed")]
        public long Elapsed { get; set; }

        [JsonProperty("credit_count")]
        public long CreditCount { get; set; }
    }
}