using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Dominio.Genericos.Exceptions
{
    public class NotFoundException : HttpException
    {
        public NotFoundException() : base(HttpStatusCode.NotFound)
        {
        }

        public NotFoundException(string? message) : base(message, HttpStatusCode.NotFound)
        {
        }

        public NotFoundException(string? message, Exception? innerException) : base(message, innerException, HttpStatusCode.NotFound)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context, HttpStatusCode.NotFound)
        {
        }
    }
}
