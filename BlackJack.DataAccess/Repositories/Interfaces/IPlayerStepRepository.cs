using BlackJack.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IPlayerStepRepository : IBaseRepository<PlayerStep>
    {
        Task AddRange(List<PlayerStep> playerSteps);

        Task<List<PlayerStep>> GetAllStepsByPlayerIdAndGameId(string playerId, Guid gameId);

        Task<List<PlayerStep>> GetAllStepsByPlayerId(string playerId);
    }
}
