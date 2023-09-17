using GlobalErrorHandling.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        /// <summary>
        /// Custom Error Handler
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var status = HttpStatusCode.InternalServerError;
            var message = ex.Message;
            var stackTrace = ex.StackTrace;

            switch (ex)
            {
                case NotFoundException:
                    status = HttpStatusCode.NotFound;
                    break;
                case KeyNotFoundException:
                    status = HttpStatusCode.NotFound;
                    break;
                case BadReuestException:
                    status = HttpStatusCode.BadRequest;
                    break;
                case NotImplementedException:
                    status = HttpStatusCode.NotImplemented;
                    break;
                case UnAuthorizedAccessException:
                    status = HttpStatusCode.Unauthorized;
                    break;
            }

            var exceptionResult = JsonSerializer.Serialize(new { error = message, stackTrace });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(exceptionResult);
        }

    }
}
