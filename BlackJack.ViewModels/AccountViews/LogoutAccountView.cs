using System.ComponentModel.DataAnnotations;

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
