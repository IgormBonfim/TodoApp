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
            catch (HttpException e)
            {
                await TratarHttpExceptionAsync(context, e);
            }
            catch (Exception e)
            {
                await TratarExceptionAsync(context, e);
            }
        }

        private static Task TratarHttpExceptionAsync(HttpContext context, HttpException e)
        {
            ExceptionResponse response = new ExceptionResponse
            {
                Status = e.StatusCode,
                Mensagem = e.Message,
                StackTrace = e.StackTrace
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)e.StatusCode;
            return context.Response.WriteAsJsonAsync(response);
        }

        private static Task TratarExceptionAsync(HttpContext context, Exception e)
        {
            ExceptionResponse response = new ExceptionResponse 
            {
                Status = HttpStatusCode.InternalServerError,
                Mensagem = e.Message,
                StackTrace = e.StackTrace
            };

            context.Response.ContentType= "application/json";
            context.Response.StatusCode = (int) response.Status;
            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
