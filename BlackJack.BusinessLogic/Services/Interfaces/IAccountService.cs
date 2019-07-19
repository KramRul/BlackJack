using BlackJack.ViewModels.AccountViews;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterAccountResponseView> Register(RegisterAccountView model);

        Task<LoginAccountResponseView> Login(LoginAccountView model);

        Task<LoginWithGoogleAccountResponseView> LoginWithGoogle(LoginExtendedAccountView model);

        Task<LoginWithFacebookAccountResponseView> LoginWithFacebook(LoginExtendedAccountView model);

        Task<LoginWithFacebookAccountResponseView> LoginWithGitHub(LoginExtendedAccountView model);

        Task<GetCurrentUserInfoAccountView> GetCurrentUserInfo(string userId);

        Task EmailConfirmed(string userId);

        Task UpdateEmail(string userId, string newEmail);
    }
}
