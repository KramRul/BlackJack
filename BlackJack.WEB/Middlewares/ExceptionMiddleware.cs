using System;
using System.Net;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Common.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Newtonsoft.Json;

namespace BlackJack.WEB.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private static readonly ActionDescriptor EmptyActionDescriptor = new ActionDescriptor();

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomServiceException ex)
            {
                await ResponseWriteAsync(httpContext, ex.Message, (int)HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                await ResponseWriteAsync(httpContext, "Server internal error", (int)HttpStatusCode.InternalServerError);
            }
        }

        private async Task ResponseWriteAsync(HttpContext httpContext, string message, int statusCode)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }

    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
