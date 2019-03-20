using BlackJack.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IBotStepRepository : IBaseRepository<BotStep>
    {
        Task AddRange(List<BotStep> botSteps);
        Task<List<Bot>> GetAllBotsByGameId(Guid gameId);
        Task<List<BotStep>> GetAllByBotId(Guid botId);
        Task<List<BotStep>> GetAllByGameId(Guid gameId);
    }
}
