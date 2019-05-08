using BlackJack.ViewModels.AccountViews;
using FirebaseAdmin.Auth;
using Google.Apis.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Providers.Interfaces
{
    public interface IGoogleAuthProvider
    {
        Task<UserGoogleAccountView> GetUserDataAsPayloadByToken(string token);

        Task<UserGoogleAccountView> GetUserDataFirebaseByToken(string token);
    }
}
