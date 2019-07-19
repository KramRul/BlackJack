using BlackJack.ViewModels.AccountViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Providers.Interfaces
{
    public interface IGitHubAuthProvider
    {
        Task<UserGitHubAccountView> GetUserDataFirebaseByToken(string token);

        Task<UserGitHubAccountView> GetUserData(LoginExtendedAccountView model);
    }
}
