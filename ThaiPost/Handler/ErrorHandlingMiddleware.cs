using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using ThaiPost.ExceptionBase;
using ValidationException = ThaiPost.ExceptionBase.ValidationException;

namespace ThaiPost.Handler
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other scoped dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var error = new ResponseException();
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            if (exception is NotFoundException)
            {
                code = HttpStatusCode.NotFound;
                NotFoundException notFoundException = (NotFoundException)exception;
                error = ConvertToExceptionResponse(notFoundException.code, notFoundException.message, notFoundException.messageObject);
            }
            else if (exception is ValidationException)
            {
                code = HttpStatusCode.BadRequest;
                ValidationException validationException = (ValidationException)exception;
                error = ConvertToExceptionResponse(validationException.code, validationException.message, validationException.messageObject);
            }
            else
            {
                code = HttpStatusCode.InternalServerError;
                error = ConvertToExceptionResponse("999999", exception.Message, exception.Message);
            }

            //else if (exception is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
            //else if (exception is MyException) code = HttpStatusCode.BadRequest;
            //if (exception is BaseException) code = HttpStatusCode.BadRequest;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(error));
        }

        private ResponseException ConvertToExceptionResponse(string code, string message, object messageObject)
        {
            return new ResponseException
            {
                errorCode = code,
                errorMessage = message,
                errorMessageObject = messageObject
            };
        }
    }
}
