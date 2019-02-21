using BlackJack.DataAccess.Entities;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Interfaces.Providers
{
    public interface IJwtProvider
    {
        Task<string> GenerateJwtToken(string email, Player player, double? expiredHours = null);
    }
}
