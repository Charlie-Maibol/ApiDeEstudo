using System;
using System.Net;
using System.Runtime.Serialization;

namespace UserAPI.Services
{
    [Serializable]
    internal class HttpResponseException : Exception
    {
        private HttpStatusCode badRequest;

        public HttpResponseException()
        {
        }

        public HttpResponseException(HttpStatusCode badRequest)
        {
            this.badRequest = badRequest;
        }

        public HttpResponseException(string message) : base(message)
        {
        }

        public HttpResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HttpResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}