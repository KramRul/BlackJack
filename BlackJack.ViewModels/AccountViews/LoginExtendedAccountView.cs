using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlackJack.ViewModels.AccountViews
{
    public class LoginExtendedAccountView
    {
        [DataType(DataType.Text)]
        [Display(Name = "Token")]
        public string Token { get; set; }
    }
}
