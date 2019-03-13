using System.Threading.Tasks;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.ViewModels.AccountViews;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.WEB.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody]RegisterAccountView model)
        {
            return await Execute(()=>_accountService.Register(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody]LoginAccountView model)
        {
            return await Execute(() => _accountService.Login(model));           
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetLoggedPlayerName()
        {
            return await Execute(() => _accountService.GetLoggedPlayerName(PlayerId));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Logout()
        {
            return await Execute(() => _accountService.Logout());
        }
    }
}