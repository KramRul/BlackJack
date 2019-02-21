using Microsoft.AspNetCore.Identity;

namespace BlackJack.DataAccess.Entities
{
    public class Player : IdentityUser
    {
        public decimal Balance { get; set; }

        public decimal Bet { get; set; }
    }
}
