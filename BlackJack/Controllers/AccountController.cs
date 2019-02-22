using System;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Interfaces.Services;
using BlackJack.ViewModels.AccountViews;
using Microsoft.AspNetCore.Mvc;
using BlackJack.ViewModels;

namespace BlackJack.WEB.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task Register(RegisterAccountView model)
        {
            await Execute(async ()=> await _accountService.Register(model));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task Login(LoginAccountView model)
        {
            await Execute(async () => await _accountService.Login(model));           
        }
    }
}