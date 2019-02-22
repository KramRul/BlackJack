using BlackJack.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IGameRepository: IBaseRepository<Game>
    {
        Task<IEnumerable<Game>> GetGamesForPlayer(string playerId);
    }
}
