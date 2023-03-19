using Knab.Core.Abstraction.Serialization;
using RestSharp;
using RestSharp.Serialization;

namespace Knab.Core.RestSharp
{
    public class RestSharpSerializer : IRestSerializer
    {
        private readonly ISerializer _serializer;

        public RestSharpSerializer(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public string Serialize(object obj)
        {
            return _serializer.Serialize(obj);
        }

        public string ContentType { get; set; } = "application/json";

        public T Deserialize<T>(IRestResponse response)
        {
            return _serializer.Deserialize<T>(response.Content);
        }

        public string Serialize(Parameter parameter)
        {
            return _serializer.Serialize(parameter.Value);
        }

        public string[] SupportedContentTypes => new[]
        {
            "application/json", "text/json", "text/x-json", "text/javascript", "*+json"
        };

        public DataFormat DataFormat => DataFormat.Json;
    }
}
