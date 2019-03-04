using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlackJack.ViewModels.AccountViews
{
    public class LogoutAccountView
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
}
