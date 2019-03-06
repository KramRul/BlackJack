using System.Security.Claims;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Interfaces.Services;
using BlackJack.ViewModels.AccountViews;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.WEB.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterAccountView model)
        {
            return await Execute(()=>_accountService.Register(model));
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginAccountView model)
        {
            return await Execute(() => _accountService.Login(model));           
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            return await Execute(() => _accountService.Logout());
        }
    }
}