using System;
using System.Net;

namespace Knab.Core.Abstraction.CQRS
{
    public abstract class RestBusResultBase : IRestBusResult<object>
    {
        protected RestBusResultBase(bool isSuccessful)
        {
            IsSuccessful = isSuccessful;
        }

        public object Result { get; set; }
        public string ContentType { get; set; }
        public long ContentLength { get; set; }
        public string ContentEncoding { get; set; }
        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccessful { get; }
        public string StatusDescription { get; set; }
        public byte[] RawBytes { get; set; }
        public Uri ResponseUri { get; set; }
        public string Server { get; set; }
        public string ErrorMessage { get; set; }
        public Exception ErrorException { get; set; }
        public Version ProtocolVersion { get; set; }
    }
}
