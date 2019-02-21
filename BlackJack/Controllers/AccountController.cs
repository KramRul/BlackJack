using System;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Interfaces.Services;
using BlackJack.ViewModels.AccountViews;
using Microsoft.AspNetCore.Mvc;
using BlackJack.ViewModels;

namespace BlackJack.WEB.Controllers
{
    public class AccountController : Controller
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
        public async Task<IActionResult> Register(RegisterAccountView model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _accountService.Register(model);
                    
                    return RedirectToAction("Index", "Game", result.Succeeded);
                }
                catch(Exception ex)
                {
                    var response = new GenericResponseView<string>();
                    response.Error = ex.Message;
                    return BadRequest(response);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginAccountView model)
        {
            try
            {
                var result = await _accountService.Login(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var response = new GenericResponseView<string>();
                response.Error = ex.Message;

                return BadRequest(response);
            }
           
        }
    }
}