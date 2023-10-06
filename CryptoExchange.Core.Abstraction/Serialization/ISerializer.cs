using System.Threading.Tasks;

namespace CryptoExchange.Core.Abstraction.Serialization
{
    /// <summary>Serialization interface that supports serialize and deserialize methods.</summary>
    public interface ISerializer
    {
        /// <summary>Gets the application format this serializer supports (e.g. "json", "xml", etc.).</summary>
        string Format { get; }

        /// <summary>Serializes the specified object into a string.</summary>
        string Serialize(object obj);

        /// <summary>Deserializes the string into an object.</summary>
        T Deserialize<T>(string input);

        Task<string> SerializeAsync(object obj);

        /// <summary>Deserializes the string into an object.</summary>
        Task<T> DeserializeAsync<T>(string input);

    }
}
