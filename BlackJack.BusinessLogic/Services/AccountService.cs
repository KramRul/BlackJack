using BlackJack.BusinessLogic.Common.Exceptions;
using BlackJack.BusinessLogic.Interfaces.Providers;
using BlackJack.BusinessLogic.Interfaces.Services;
using BlackJack.BusinessLogic.Models;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;
using BlackJack.ViewModels.AccountViews;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly UserManager<Player> _userManager;
        private readonly SignInManager<Player> _signInManager;
        private readonly IOptions<AuthenticationOptions> _authenticationOptions;
        private readonly IJwtProvider _jwtProvider;

        public AccountService(UserManager<Player> userManager, SignInManager<Player> signInManager, IOptions<AuthenticationOptions> authenticationOptions, IJwtProvider jwtProvider, IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationOptions = authenticationOptions;
            _jwtProvider = jwtProvider;
        }

        public async Task<LoginAccountResponseView> Login(LoginAccountView model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            var userCheck = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!userCheck)
            {
                throw new CustomServiceException("Invalid username or password.");
            }

            string encodedJwt = await _jwtProvider.GenerateJwtToken(user.Email, user);
            var result = new LoginAccountResponseView()
            {
                AccessToken = encodedJwt,
                UserName = user.UserName
            };
            return result;
        }

        public async Task<RegisterAccountResponseView> Register(RegisterAccountView playerModel)
        {
            var playerExist = await _userManager.FindByNameAsync(playerModel.UserName);

            if (playerExist!=null)
            {
                throw new CustomServiceException("Player allready exist.");
            }

            var user = new Player
            {
                UserName = playerModel.UserName,
                Balance = 1000
            };

            var result = await _userManager.CreateAsync(user, playerModel.Password);
            if(!result.Succeeded)
            {
                throw new CustomServiceException("The user was not registered");
            }

            string encodedJwt = await _jwtProvider.GenerateJwtToken(user.Email, user);
            return new RegisterAccountResponseView()
            {
                AccessToken = encodedJwt,
                UserName = user.UserName
            };
        }
    }
}
