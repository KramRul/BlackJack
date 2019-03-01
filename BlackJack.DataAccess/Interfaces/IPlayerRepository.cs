using BlackJack.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IPlayerRepository: IBaseRepository<Player>
    {
        Task<Player> GetByName(string name);
    }
}
