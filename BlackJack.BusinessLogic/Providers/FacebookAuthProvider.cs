using BlackJack.BusinessLogic.Options;
using BlackJack.BusinessLogic.Providers.Interfaces;
using BlackJack.ViewModels.AccountViews;
using Facebook;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Providers
{
    public class FacebookAuthProvider : IFacebookAuthProvider
    {
        private readonly IConfiguration _configuration;

        public FacebookAuthProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<UserFacebookAccountView> GetUserDataByToken(string token)
        {
            var options = _configuration.GetSection("FacebookAuthOptions").Get<FacebookAuthOptions>();
            var fb = new FacebookClient
            {
                AppId = options.AppId,
                AppSecret = options.AppSecret,
                AccessToken = token
            };
            string parametrsUser = fb.Get("me?fields=name,first_name,last_name,id,email").ToString();
            var user = JsonConvert.DeserializeObject<UserFacebookAccountView>(parametrsUser);
            return user;
        }
    }
}
