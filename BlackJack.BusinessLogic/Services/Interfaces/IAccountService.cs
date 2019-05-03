using BlackJack.ViewModels.AccountViews;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterAccountResponseView> Register(RegisterAccountView model);

        Task<LoginAccountResponseView> Login(LoginAccountView model);

        Task<LoginAccountResponseView> LoginWithGoogle(LoginAccountView model);
    }
}
