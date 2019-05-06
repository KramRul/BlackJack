using BlackJack.BusinessLogic.Providers.Interfaces;
using Google.Apis.Auth;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Providers
{
    public class GoogleAuthProvider : IGoogleAuthProvider
    {
        private readonly IConfiguration _configuration;

        public GoogleAuthProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<GoogleJsonWebSignature.Payload> GetUserDataAsPayloadByToken(string token)
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(token);

            return payload;
        }
    }
}
