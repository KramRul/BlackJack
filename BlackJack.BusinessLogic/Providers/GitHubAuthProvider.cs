using BlackJack.BusinessLogic.Providers.Interfaces;
using BlackJack.ViewModels.AccountViews;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Providers
{
    public class GitHubAuthProvider : IGitHubAuthProvider
    {
        private readonly IConfiguration _configuration;

        public GitHubAuthProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<UserGitHubAccountView> GetUserData(LoginExtendedAccountView model)
        {
            var result = new UserGitHubAccountView()
            {
                Name = model.Name
            };

            return result;
        }

        public async Task<UserGitHubAccountView> GetUserDataFirebaseByToken(string token)
        {
            GoogleCredential credential;
            using (var stream = new FileStream("TestAuth-8cb3dbdbce24.json", FileMode.Open, FileAccess.Read))
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

            var result = new UserGitHubAccountView()
            {
                Name = userData.Claims["name"].ToString(),
                Email = userData.Claims["email"].ToString()
            };

            return result;
        }
    }
}
