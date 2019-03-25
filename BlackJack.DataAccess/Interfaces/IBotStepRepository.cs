using BlackJack.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IBotStepRepository : IBaseRepository<BotStep>
    {
        Task<List<BotStep>> GetAllByBotId(Guid botId);
        Task<List<BotStep>> GetAllByGameId(Guid gameId);
    }
}
