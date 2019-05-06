using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.ViewModels.AccountViews
{
    public class LoginWithFacebookAccountResponseView
    {
        public string AccessToken { get; set; }
        public string UserName { get; set; }
        public string PlayerId { get; set; }
    }
}
