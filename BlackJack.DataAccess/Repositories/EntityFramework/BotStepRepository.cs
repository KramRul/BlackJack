using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.EntityFramework
{
    public class BotStepRepository : IBotStepRepository
    {
        private ApplicationContext dataBase;

        public BotStepRepository(ApplicationContext context)
        {
            dataBase = context;
        }

        public async Task<List<BotStep>> GetAll()
        {
            var result = await dataBase.BotSteps.ToListAsync();
            return result;
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

        public async Task<BotStep> Get(Guid id)
        {
            var result = await dataBase.BotSteps.FindAsync(id);
            return result;
        }

        public async Task Create(BotStep botStep)
        {
            await dataBase.BotSteps.AddAsync(botStep);
        }

        public async Task AddRange(List<BotStep> botSteps)
        {
            await dataBase.BotSteps.AddRangeAsync(botSteps);
        }

        public async Task Update(BotStep botStep)
        {
            dataBase.Entry(botStep).State = EntityState.Modified;
        }

        public async Task Delete(Guid id)
        {
            BotStep botStep = await dataBase.BotSteps.FindAsync(id);
            if (botStep != null)
                dataBase.BotSteps.Remove(botStep);
        }
    }
}
