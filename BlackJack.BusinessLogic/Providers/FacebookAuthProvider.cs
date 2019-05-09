using BlackJack.BusinessLogic.Options;
using BlackJack.BusinessLogic.Providers.Interfaces;
using BlackJack.ViewModels.AccountViews;
using Facebook;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task<UserFacebookAccountView> GetUserDataFirebaseByToken(string token)
        {
            GoogleCredential credential;
            using (var stream = new FileStream("TestAuth-8cb3dbdbce24.json", FileMode.Open, FileAccess.Read))//credentials TestAuth-8cb3dbdbce24.json
            {
                credential = GoogleCredential.FromStream(stream);
            }

            FirebaseApp defaultApp;
            if (FirebaseApp.DefaultInstance == null)
            {
                defaultApp = FirebaseApp.Create(new AppOptions()
                {
                    Credential = credential
                });
            }
            else
            {
                defaultApp = FirebaseApp.DefaultInstance;
            }

            var auth = FirebaseAuth.GetAuth(defaultApp);
            var userData = await auth.VerifyIdTokenAsync(token);

            var result = new UserFacebookAccountView()
            {
                Name = userData.Claims["name"].ToString(),
                Email = userData.Claims["email"].ToString()
            };

            return result;
        }
    }
}
