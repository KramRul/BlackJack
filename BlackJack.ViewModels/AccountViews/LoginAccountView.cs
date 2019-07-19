using System.ComponentModel.DataAnnotations;

namespace BlackJack.ViewModels.AccountViews
{
    public class LoginAccountView
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Token")]
        public string Token { get; set; }
    }
}
