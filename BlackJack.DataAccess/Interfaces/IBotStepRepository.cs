using BlackJack.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IBotStepRepository: IBaseRepository<BotStep>
    {
        Task AddRange(List<BotStep> botSteps);
        Task<List<Bot>> GetAllBotsByGameId(Guid gameId);
        Task<IEnumerable<BotStep>> GetAllStepsByBotId(Guid botId);
        Task<IEnumerable<BotStep>> GetAllStepsByGameId(Guid gameId);
    }
}
