using System;
using System.Security.Claims;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Common.Exceptions;
using BlackJack.ViewModels;
using BlackJack.WEB.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.WEB.Controllers
{
    public class BaseController : Controller
    {   
        protected string PlayerId
        {
            get
            {
                return User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
        }

        public async Task<IActionResult> Execute<T>(Func<Task<T>> func)
        {
            GenericResponseView<T> response = new GenericResponseView<T>();
            //try
            //{
                var result = await func();
                response.Model = result;
                return Ok(response.Model);
            //}
            //catch (CustomServiceException ex)
            //{
            //    response.Error = ex.Message;
            //    return BadRequest(response);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    response.Error = "Server internal error";
            //    return BadRequest(response);
            //}
        }

        protected async Task<IActionResult> Execute(Func<Task> func)
        {
            var response = new GenericResponseView<string>();
            //try
            //{
                await func();
                return Ok(response);
            //}
            //catch (CustomServiceException ex)
            //{
            //    response.Error = ex.Message;
            //    return BadRequest(response);
            //}
            //catch (Exception ex)
            //{
            //    response.Error = "Server internal error";
            //    return BadRequest(response);
            //}
        }
    }

    
}