using System.Net;
using TodoApp.DataTransfer.Genericos.Responses;
using TodoApp.Dominio.Genericos.Exceptions;

namespace TodoApp.API.Middlewares
{
    public class TratamentoErrosGlobalMiddleware
    {
        private readonly RequestDelegate _next;

        public TratamentoErrosGlobalMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await TratarExceptionAsync(context, e);
            }
        }

        private static Task TratarExceptionAsync(HttpContext context, Exception e)
        {
            HttpStatusCode status;
            ExceptionResponse response;
            var exceptionType = e.GetType();

            if (exceptionType == typeof(BadRequestException))
            {
                response = TratarBadRequestException(e);
            } 
            if (exceptionType == typeof(NotFoundException))
            {
                response = TratarNotFoundException(e);
            }
            else
            {
                response = InternalServerError(e);
            }

            context.Response.ContentType= "application/json";
            context.Response.StatusCode = (int) response.Status;
            return context.Response.WriteAsJsonAsync(response);
        }

        private static ExceptionResponse TratarBadRequestException(Exception e)
        {
            ExceptionResponse response = new ExceptionResponse();

            response.Mensagem = e.Message;
            response.StackTrace = e.StackTrace;
            response.Status = HttpStatusCode.BadRequest;

            return response;
        }

        private static ExceptionResponse TratarNotFoundException(Exception e)
        {
            ExceptionResponse response = new ExceptionResponse();

            response.Mensagem = e.Message;
            response.StackTrace = e.StackTrace;
            response.Status = HttpStatusCode.NotFound;

            return response;
        }

        private static ExceptionResponse InternalServerError(Exception e)
        {
            ExceptionResponse response = new ExceptionResponse();

            response.Mensagem = e.Message;
            response.StackTrace = e.StackTrace;
            response.Status = HttpStatusCode.InternalServerError;

            return response;
        }
    }
}
