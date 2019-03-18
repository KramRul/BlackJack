using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.EntityFramework
{
    public class BotStepRepository : BaseRepository<BotStep>, IBotStepRepository
    {
        public BotStepRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<Bot>> GetAllBotsByGameId(Guid gameId)
        {
            var result = await dataBase.BotSteps.Include(b => b.Bot)
                .Where(b => b.GameId == gameId)
                .Select(b => b.Bot)
                .Distinct()
                .ToListAsync();
            return result;
        }

        public async Task<List<BotStep>> GetAllStepsByGameId(Guid gameId)
        {
            var result = await dataBase.BotSteps
                .Include(b => b.Bot)
                .Where(b => b.GameId == gameId)
                .ToListAsync();
            return result;
        }

        public async Task<List<BotStep>> GetAllStepsByBotId(Guid botId)
        {
            var result = await dataBase.BotSteps
                .Include(b => b.Bot)
                .Where(b => b.BotId == botId)
                .ToListAsync();
            return result;
        }

        public async Task AddRange(List<BotStep> botSteps)
        {
            await dataBase.BotSteps.AddRangeAsync(botSteps);
            await Save();
        }
    }
}
