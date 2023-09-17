using GlobalErrorHandling.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using KeyNotFoundException = GlobalErrorHandling.Exceptions.KeyNotFoundException;
using NotImplementedException = GlobalErrorHandling.Exceptions.NotImplementedException;
using UnAuthorizedAccessException = GlobalErrorHandling.Exceptions.UnAuthorizedAccessException;

namespace GlobalErrorHandling.Confriguations
{
    public class GlobalExceptionsHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionsHandlingMiddleware(RequestDelegate request)
        {
            _next = request;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context,ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode status;
            var stackTrace = string.Empty;
            string message = "";
            var exceptionType = ex.GetType();

            if(exceptionType == typeof(NotFoundException)){
                message = ex.Message;
                status = HttpStatusCode.NotFound;
                stackTrace = ex.StackTrace;
            }else if(exceptionType == typeof(KeyNotFoundException)) 
            {
                message = ex.Message;
                status = HttpStatusCode.NotFound;
                stackTrace = ex.StackTrace;
            }else if(exceptionType == typeof(BadReuestException))
            {
                message = ex.Message;
                status = HttpStatusCode.BadRequest;
                stackTrace = ex.StackTrace;
            }else if(exceptionType == typeof(NotImplementedException))
            {
                message = ex.Message;
                status = HttpStatusCode.NotImplemented;
                stackTrace = ex.StackTrace;
            }else if(exceptionType == typeof(UnAuthorizedAccessException))
            {
                message = ex.Message;
                status = HttpStatusCode.Unauthorized;
                stackTrace = ex.StackTrace;
            }
            else
            {
                message = ex.Message;
                status = HttpStatusCode.InternalServerError;
                stackTrace = ex.StackTrace;
            }
            var exceptionResult = JsonSerializer.Serialize(new { error = message, stackTrace });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(exceptionResult);
        }
    }
}
