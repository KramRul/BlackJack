using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.EntityFramework
{
    public class BotRepository: BaseRepository, IBotRepository
    {
        public BotRepository(ApplicationContext context): base(context)
        {
        }

        public async Task<List<Bot>> GetAll()
        {
            var result = await dataBase.Bots.ToListAsync();
            return result;
        }

        public async Task<int> Count()
        {
            var result = await dataBase.Bots.CountAsync();
            return result;
        }

        public async Task<Bot> Get(Guid id)
        {
            var result = await dataBase.Bots.FindAsync(id);
            return result;
        }

        public async Task Create(Bot bot)
        {
            await dataBase.Bots.AddAsync(bot);
            await Save();
        }

        public async Task Update(Bot bot)
        {
            dataBase.Entry(bot).State = EntityState.Modified;
            await Save();
        }

        public async Task Delete(Guid id)
        {
            Bot bot = await dataBase.Bots.FindAsync(id);
            if (bot != null)
                dataBase.Bots.Remove(bot);
            await Save();
        }
    }
}
