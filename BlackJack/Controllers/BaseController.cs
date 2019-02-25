using System;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Common.Exceptions;
using BlackJack.ViewModels;
using BlackJack.WEB.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.WEB.Controllers
{
    public class BaseController : Controller
    {
        public async Task<IActionResult> Execute<T>(Func<Task<T>> func)
        {
            GenericResponseView<T> response = new GenericResponseView<T>();
            try
            {
                if (!ModelState.IsValid)
                {
                    var errorResponse = new GenericResponseView<string>();
                    errorResponse.Error = ModelState.GetFirstErrorFromModelState();
                    return BadRequest(errorResponse);
                }
                var result = await func();
                response.Model = result;
                return Ok(response);
                
            }
            catch (CustomServiceException ex)
            {
                response.Error = ex.Message;
                return BadRequest(response);
            }
            catch(Exception ex)
            {
                //lloging
                Console.WriteLine(ex.Message);
                response.Error = "Server internal error";
                return BadRequest(response);
            }
        }

        protected async Task<IActionResult> Execute(Func<Task> func)
        {
            var response = new GenericResponseView<string>();
            try
            {

                if (!ModelState.IsValid)
                {
                    var errorResult = new GenericResponseView<string>();
                    errorResult.Error = ModelState.GetFirstErrorFromModelState();
                    return BadRequest(errorResult);
                }

                await func();
                return Ok(response);
            }
            catch (CustomServiceException ex)
            {
                response.Error = ex.Message;
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                //await _loggerService.LogException(ex);
                response.Error = "Server internal error";
                return BadRequest(response);
            }
        }
    }

    
}