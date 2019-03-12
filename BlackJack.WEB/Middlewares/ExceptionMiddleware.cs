using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Common.Exceptions;
using BlackJack.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Routing;

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
                await httpContext.Response.WriteAsync(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);;
                await httpContext.Response.WriteAsync("Server internal error");
            }
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
