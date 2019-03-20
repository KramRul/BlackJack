using BlackJack.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        Task<List<Game>> GetAllByPlayerId(string playerId);
        Task<Game> GetActiveByPlayerId(string playerId);
        Task<Game> GetLastActiveByPlayerId(string playerId);
    }
}
