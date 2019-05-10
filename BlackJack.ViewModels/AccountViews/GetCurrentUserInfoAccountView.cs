using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.ViewModels.AccountViews
{
    public class GetCurrentUserInfoAccountView
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool EmailConfirmed { get; set; }        
    }
}
