using BlackJack.ViewModels.AccountViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Providers.Interfaces
{
    public interface IFacebookAuthProvider
    {
        Task<UserFacebookAccountView> GetUserDataByToken(string token);

        Task<UserFacebookAccountView> GetUserDataFirebaseByToken(string token);
    }
}
