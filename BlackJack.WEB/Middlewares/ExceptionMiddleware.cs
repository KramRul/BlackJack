using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Common.Exceptions;
using BlackJack.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace BlackJack.WEB.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke<T>(HttpContext httpContext)
        {
            GenericResponseView<T> response = new GenericResponseView<T>();
            try
            {
                await _next(httpContext);
            }
            catch (CustomServiceException ex)
            {
                /*response.Error = ex.Message;
                return BadRequest(response);*/
            }
            catch (Exception ex)
            {
                /*Console.WriteLine(ex.Message);
                response.Error = "Server internal error";
                return BadRequest(response);*/
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
