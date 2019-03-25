using BlackJack.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IPlayerStepRepository : IBaseRepository<PlayerStep>
    {
        Task<List<PlayerStep>> GetAllByPlayerIdAndGameId(string playerId, Guid gameId);
        Task<List<PlayerStep>> GetAllByPlayerId(string playerId);
    }
}
