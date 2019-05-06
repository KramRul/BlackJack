using Google.Apis.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Providers.Interfaces
{
    public interface IGoogleAuthProvider
    {
        Task<GoogleJsonWebSignature.Payload> GetUserDataAsPayloadByToken(string token);
    }
}
