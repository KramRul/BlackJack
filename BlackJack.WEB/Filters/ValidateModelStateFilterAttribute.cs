﻿using BlackJack.ViewModels;
using BlackJack.WEB.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.WEB.Filters
{
    public class ValidateModelStateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errorResponse = new GenericResponseView<string>();
                errorResponse.Error = context.ModelState.GetFirstErrorFromModelState();
                context.Result = new BadRequestObjectResult(errorResponse);
            }
        }
    }
}
