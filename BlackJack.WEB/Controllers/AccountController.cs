using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.DataAccess.Entities;
using BlackJack.ViewModels.AccountViews;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BlackJack.WEB.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        
        [HttpPost]
        [SwaggerResponse(200, "Player was register", typeof(RegisterAccountResponseView))]
        [SwaggerResponse(500)]
        public async Task<IActionResult> Register([FromBody]RegisterAccountView model)
        {
            return await Execute(()=>_accountService.Register(model));
        }

        [HttpPost]
        [SwaggerResponse(200, "Player was logged", typeof(LoginAccountResponseView))]
        [SwaggerResponse(500)]
        public async Task<IActionResult> Login([FromBody]LoginAccountView model)
        {
            return await Execute(() => _accountService.Login(model));           
        }

        [HttpPost]
        [SwaggerResponse(200, "Player was logged", typeof(LoginAccountResponseView))]
        [SwaggerResponse(500)]
        public async Task<IActionResult> LoginWithGoogle([FromBody]LoginExtendedAccountView model)
        {
            return await Execute(() => _accountService.LoginWithGoogle(model));
        }

        [HttpPost]
        [SwaggerResponse(200, "Player was logged", typeof(LoginAccountResponseView))]
        [SwaggerResponse(500)]
        public async Task<IActionResult> LoginWithFacebook([FromBody]LoginExtendedAccountView model)
        {
            return await Execute(() => _accountService.LoginWithFacebook(model));
        }

        [HttpPost]
        [SwaggerResponse(200, "Player was logged", typeof(LoginAccountResponseView))]
        [SwaggerResponse(500)]
        public async Task<IActionResult> LoginWithGitHub([FromBody]LoginExtendedAccountView model)
        {
            return await Execute(() => _accountService.LoginWithGitHub(model));
        }

        [HttpPost]
        [SwaggerResponse(200, "User info was recived", typeof(GetCurrentUserInfoAccountView))]
        [SwaggerResponse(500)]
        public async Task<IActionResult> GetCurrentUserInfo()
        {
            return await Execute(() => _accountService.GetCurrentUserInfo(PlayerId));
        }

        [HttpPost]
        [SwaggerResponse(200, "Email confirmed")]
        [SwaggerResponse(500)]
        public async Task<IActionResult> EmailConfirmed()
        {
            return await Execute(() => _accountService.EmailConfirmed(PlayerId));
        }

        [HttpPost]
        [SwaggerResponse(200, "Email updated")]
        [SwaggerResponse(500)]
        public async Task<IActionResult> UpdateEmail([FromBody]UpdateEmailAccountView model)//[FromBody][DataType(DataType.EmailAddress)] 
        {
            return await Execute(() => _accountService.UpdateEmail(PlayerId, model.Email));
        }
    }
}