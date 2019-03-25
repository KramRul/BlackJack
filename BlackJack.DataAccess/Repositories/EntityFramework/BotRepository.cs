using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.EntityFramework
{
    public class BotRepository: BaseRepository<Bot>, IBotRepository
    {
        public BotRepository(ApplicationContext context): base(context)
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
    }
}
