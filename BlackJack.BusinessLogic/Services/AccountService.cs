using BlackJack.BusinessLogic.Common.Exceptions;
using BlackJack.BusinessLogic.Providers.Interfaces;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.UnitOfWorks.Interfaces;
using BlackJack.ViewModels.AccountViews;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly UserManager<Player> _userManager;
        private readonly SignInManager<Player> _signInManager;
        private readonly IJwtProvider _jwtProvider;

        public AccountService(UserManager<Player> userManager, SignInManager<Player> signInManager, IJwtProvider jwtProvider, IBaseUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtProvider = jwtProvider;
        }

        public async Task<LoginAccountResponseView> Login(LoginAccountView model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                throw new CustomServiceException("Player does not exist.");
            }

            var userCheck = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!userCheck)
            {
                throw new CustomServiceException("Invalid username or password.");
            }

            string encodedJwt = await _jwtProvider.GenerateJwtToken(user.Email, user);
            var result = new LoginAccountResponseView()
            {
                AccessToken = encodedJwt,
                UserName = user.UserName,
                PlayerId = user.Id
            };
            return result;
        }

        public async Task<RegisterAccountResponseView> Register(RegisterAccountView playerModel)
        {
            var playerExist = await _userManager.FindByNameAsync(playerModel.UserName);
            if (playerExist != null)
            {
                throw new CustomServiceException("Player allready exist.");
            }

            var user = new Player
            {
                UserName = playerModel.UserName,
                Balance = 1000
            };

            var result = await _userManager.CreateAsync(user, playerModel.Password);

            if (!result.Succeeded)
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

        public async Task<string> GetLoggedPlayerName(string playerName)
        {
            if (string.IsNullOrEmpty(playerName))
            {
                throw new CustomServiceException("Player does not exist.");
            }
            return playerName;
        }
    }
}
