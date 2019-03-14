using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Identity;

namespace BlackJack.DataAccess.Entities
{
    [Table("AspNetUsers")]
    public class Player : IdentityUser
    {
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
