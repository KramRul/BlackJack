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
using Facebook;
using Newtonsoft.Json;

namespace BlackJack.BusinessLogic.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly UserManager<Player> _userManager;
        private readonly IJwtProvider _jwtProvider;
        private readonly IGoogleAuthProvider _googleAuthProvider;
        private readonly IFacebookAuthProvider _facebookAuthProvider;
        private readonly IGitHubAuthProvider _gitHubAuthProvider;

        public AccountService(
            UserManager<Player> userManager,
            IJwtProvider jwtProvider,
            IGoogleAuthProvider googleAuthProvider,
            IFacebookAuthProvider facebookAuthProvider,
            IGitHubAuthProvider gitHubAuthProvider,
            IBaseUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _userManager = userManager;
            _jwtProvider = jwtProvider;
            _googleAuthProvider = googleAuthProvider;
            _facebookAuthProvider = facebookAuthProvider;
            _gitHubAuthProvider = gitHubAuthProvider;
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

        public async Task<LoginWithFacebookAccountResponseView> LoginWithFacebook(LoginExtendedAccountView model)
        {
            var userData = await _facebookAuthProvider.GetUserDataFirebaseByToken(model.Token);

            var createdPlayer = await CreatePlayer(userData.Name, userData.Email);

            var playerView = await GetPlayerView(createdPlayer);

            var result = new LoginWithFacebookAccountResponseView()
            {
                AccessToken = playerView.AccessToken,
                PlayerId = playerView.PlayerId,
                UserName = playerView.UserName
            };
            return result;
        }

        public async Task<LoginWithGoogleAccountResponseView> LoginWithGoogle(LoginExtendedAccountView model)
        {
            var userData = await _googleAuthProvider.GetUserDataFirebaseByToken(model.Token);

            var createdPlayer = await CreatePlayer(userData.Name, userData.Email);

            var playerView = await GetPlayerView(createdPlayer);

            var result = new LoginWithGoogleAccountResponseView()
            {
                AccessToken = playerView.AccessToken,
                PlayerId = playerView.PlayerId,
                UserName = playerView.UserName
            };
            return result;
        }

        public async Task<LoginWithFacebookAccountResponseView> LoginWithGitHub(LoginExtendedAccountView model)
        {
            var userData = await _gitHubAuthProvider.GetUserData(model);

            var email = (!string.IsNullOrEmpty(userData.Email)) ? userData.Email : "";
            var createdPlayer = await CreatePlayer(userData.Name, email);

            var playerView = await GetPlayerView(createdPlayer);

            var result = new LoginWithFacebookAccountResponseView()
            {
                AccessToken = playerView.AccessToken,
                PlayerId = playerView.PlayerId,
                UserName = playerView.UserName
            };
            return result;
        }

        private async Task<Player> CreatePlayer(string userName, string email)
        {
            var latinName = Transliteration.CyrillicToLatin(userName, Language.Russian);
            var newName = latinName.Replace(" ", string.Empty);
            var user = await _userManager.FindByNameAsync(newName);          
            if (user == null)
            {
                var player = new Player
                {
                    UserName = newName,
                    Balance = 1000,
                    Email = email
                };
                var createdUser = await _userManager.CreateAsync(player);

                if (!createdUser.Succeeded)
                {
                    throw new CustomServiceException("The user was not registered");
                }

                return player;
            }
            else
            {
                if (string.IsNullOrEmpty(user.Email))
                {
                    user.Email = email;
                    await _userManager.UpdateAsync(user);
                }
                return user;
            }
        }

        private async Task<GetPlayerAccountView> GetPlayerView(Player player)
        {
            var token = await _jwtProvider.GenerateJwtToken(player.Email, player);

            var result = new GetPlayerAccountView()
            {
                AccessToken = token,
                UserName = player.UserName,
                PlayerId = player.Id
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
