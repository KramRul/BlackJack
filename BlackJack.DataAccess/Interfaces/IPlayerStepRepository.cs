using BlackJack.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IPlayerStepRepository : IBaseRepository<PlayerStep>
    {
        Task<IEnumerable<PlayerStep>> GetAllStepsByPlayerIdAndGameId(string playerId, Guid gameId);
    }
}
