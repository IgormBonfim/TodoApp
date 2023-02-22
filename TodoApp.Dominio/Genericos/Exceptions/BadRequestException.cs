using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Dominio.Genericos.Exceptions
{
    public class BadRequestException : HttpException
    {
        public BadRequestException() : base(HttpStatusCode.BadRequest)
        {

        }
        public BadRequestException(string? message) : base(message, HttpStatusCode.BadRequest)
        {
        }

        public BadRequestException(string? message, Exception? innerException) : base(message, innerException, HttpStatusCode.BadRequest)
        {
        }

        protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context, HttpStatusCode.BadRequest)
        {
        }
    }
}
