using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories
{
    public class BotRepository: IBotRepository
    {
        private ApplicationContext db;

        public BotRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<Bot>> GetAll()
        {
            var result = await db.Bots.ToListAsync();
            return result;
        }

        public async Task<Bot> Get(Guid id)
        {
            var result = await db.Bots.FindAsync(id);
            return result;
        }

        public async Task Create(Bot bot)
        {
            await db.Bots.AddAsync(bot);
        }

        public void Update(Bot bot)
        {
            db.Entry(bot).State = EntityState.Modified;
        }

        public async Task Delete(Guid id)
        {
            Bot bot = await db.Bots.FindAsync(id);
            if (bot != null)
                db.Bots.Remove(bot);
        }
    }
}
