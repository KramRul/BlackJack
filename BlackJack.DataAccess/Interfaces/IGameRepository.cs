using BlackJack.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        Task<List<Game>> GetGamesForPlayer(string playerId);
        Task<Game> GetActiveGameForPlayer(string playerId);
        Task<Game> GetLastActiveGameForPlayer(string playerId);
    }
}
