using System;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Common.Exceptions;
using BlackJack.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.WEB.Controllers
{
    public class BaseController : Controller
    {
        public async Task<IActionResult> Execute<T>(Func<T> func)
        {            
            try
            {
                if (!ModelState.IsValid)
                {
                    var errorResponse = new GenericResponseView<string>();
                    errorResponse.Error = "Get First Error from model state";
                    return BadRequest(errorResponse);
                }
                var result = func();
                return Ok(result);
                
            }
            catch (CustomServiceException ex)
            {
                var response = new GenericResponseView<string>();
                response.Error = ex.Message;
                return BadRequest(response);
            }
            catch(Exception ex)
            {
                //lloging
                var response = new GenericResponseView<string>();
                response.Error = "Server internal error";
                return BadRequest(response);
            }
        }
    }
}