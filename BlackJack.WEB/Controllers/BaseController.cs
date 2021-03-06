﻿using System;
using System.Security.Claims;
using System.Threading.Tasks;
using BlackJack.ViewModels;
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

        protected string PlayerName
        {
            get
            {
                return User.FindFirst(ClaimTypes.Name).Value;
            }
        }

        public async Task<IActionResult> Execute<T>(Func<Task<T>> func)
        {
            var response = new GenericResponseView<T>();
            var result = await func();
            response.Model = result;
            return Ok(response.Model);
        }

        protected async Task<IActionResult> Execute(Func<Task> func)
        {
            var response = new GenericResponseView<string>();
            await func();
            return Ok(response);
        }
    }
}