using BlackJack.BusinessLogic.Common.Exceptions;
using BlackJack.BusinessLogic.Providers.Interfaces;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.UnitOfWorks.Interfaces;
using BlackJack.ViewModels.AccountViews;
using Microsoft.AspNetCore.Identity;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using System.Threading.Tasks;
using NickBuhro.Translit;

namespace BlackJack.BusinessLogic.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly UserManager<Player> _userManager;
        private readonly IJwtProvider _jwtProvider;

        public AccountService(UserManager<Player> userManager, IJwtProvider jwtProvider, IBaseUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _userManager = userManager;
            _jwtProvider = jwtProvider;
        }

        public async Task<LoginAccountResponseView> Login(LoginAccountView model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                throw new CustomServiceException("Player does not exist.");
            }

            var isValidPassword = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!isValidPassword)
            {
                throw new CustomServiceException("Invalid username or password.");
            }

            string token = await _jwtProvider.GenerateJwtToken(user.Email, user);
            var result = new LoginAccountResponseView()
            {
                AccessToken = token,
                UserName = user.UserName,
                PlayerId = user.Id
            };
            return result;
        }

        public async Task<LoginAccountResponseView> LoginWithGoogle(LoginAccountView model)
        {        
            GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(model.Token);

            var latinName = Transliteration.CyrillicToLatin(payload.Name, Language.Russian);
            var newName = latinName.Replace(" ", string.Empty);
            var user = await _userManager.FindByNameAsync(newName);
            var player = new Player();
            string token = "";
            if (user == null)
            {
                player.UserName = newName;
                player.Balance = 1000;
                var createdUser = await _userManager.CreateAsync(player);

                if (!createdUser.Succeeded)
                {
                    throw new CustomServiceException("The user was not registered");
                }

                token = await _jwtProvider.GenerateJwtToken(payload.Email, player);
            }
            else
            {
                token = await _jwtProvider.GenerateJwtToken(payload.Email, user);
            }
            
            var result = new LoginAccountResponseView()
            {
                AccessToken = token,
                UserName = user.UserName,
                PlayerId = user.Id
            };
            return result;
        }

        public async Task<RegisterAccountResponseView> Register(RegisterAccountView model)
        {
            var existedPlayear = await _userManager.FindByNameAsync(model.UserName);
            if (existedPlayear != null)
            {
                throw new CustomServiceException("Player allready exist.");
            }

            var user = new Player
            {
                UserName = model.UserName,
                Balance = 1000
            };

            var createdUser = await _userManager.CreateAsync(user, model.Password);

            if (!createdUser.Succeeded)
            {
                throw new CustomServiceException("The user was not registered");
            }

            string token = await _jwtProvider.GenerateJwtToken(user.Email, user);
            var result = new RegisterAccountResponseView()
            {
                AccessToken = token,
                UserName = user.UserName
            };

            return result;
        }
    }
}
