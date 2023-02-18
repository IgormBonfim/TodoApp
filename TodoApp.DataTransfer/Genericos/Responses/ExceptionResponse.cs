using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.DataTransfer.Genericos.Responses
{
    public class ExceptionResponse
    {
        public HttpStatusCode Status { get; set; }
        public string Mensagem { get; set; }
        public string StackTrace { get; set; }
    }
}
