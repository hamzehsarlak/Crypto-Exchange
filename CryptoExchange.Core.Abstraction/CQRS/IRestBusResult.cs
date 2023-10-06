using System;
using System.Net;

namespace CryptoExchange.Core.Abstraction.CQRS
{
    public interface IRestBusResult<T>
    {
        T Result { get; set; }
        /// <summary>MIME content type of response</summary>
        string ContentType { get; set; }

        /// <summary>Length in bytes of the response content</summary>
        long ContentLength { get; set; }

        /// <summary>Encoding of the response content</summary>
        string ContentEncoding { get; set; }

        /// <summary>String representation of response content</summary>
        string Content { get; set; }

        /// <summary>HTTP response status code</summary>
        HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Whether or not the response status code indicates success
        /// </summary>
        bool IsSuccessful { get; }

        /// <summary>Description of HTTP status returned</summary>
        string StatusDescription { get; set; }

        /// <summary>Response content</summary>
        byte[] RawBytes { get; set; }

        /// <summary>
        /// The URL that actually responded to the content (different from request if redirected)
        /// </summary>
        Uri ResponseUri { get; set; }

        /// <summary>HttpWebResponse.Server</summary>
        string Server { get; set; }

        /// <summary>
        /// Transport or other non-HTTP error generated while attempting request
        /// </summary>
        string ErrorMessage { get; set; }

        /// <summary>Exceptions thrown during the request, if any.</summary>
        /// <remarks>
        /// Will contain only network transport or framework exceptions thrown during the request.
        /// HTTP protocol errors are handled by RestSharp and will not appear here.
        /// </remarks>
        Exception ErrorException { get; set; }

        /// <summary>The HTTP protocol version (1.0, 1.1, etc)</summary>
        /// <remarks>Only set when underlying framework supports it.</remarks>
        Version ProtocolVersion { get; set; }
    }
}
