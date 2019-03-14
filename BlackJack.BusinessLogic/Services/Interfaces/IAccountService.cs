using BlackJack.ViewModels.AccountViews;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterAccountResponseView> Register(RegisterAccountView playerModel);

        Task<LoginAccountResponseView> Login(LoginAccountView playerModel);

        Task<string> GetLoggedPlayerName(string playerName);
    }
}
