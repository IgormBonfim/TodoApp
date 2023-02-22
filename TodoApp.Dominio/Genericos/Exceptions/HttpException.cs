using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Dominio.Genericos.Exceptions
{
    public class HttpException : Exception
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.BadRequest;

        public HttpException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public HttpException(string? message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpException(string? message, Exception? innerException, HttpStatusCode statusCode) : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        protected HttpException(SerializationInfo info, StreamingContext context, HttpStatusCode statusCode) : base(info, context)
        {
            StatusCode = statusCode;
        }
    }
}
