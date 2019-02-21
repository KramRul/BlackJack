using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories
{
    public class BotStepRepository: IBotStepRepository
    {
        private ApplicationContext db;

        public BotStepRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<BotStep>> GetAll()
        {
            var result = await db.BotSteps.ToListAsync();
            return result;
        }

        public async Task<BotStep> Get(Guid id)
        {
            var result = await db.BotSteps.FindAsync(id);
            return result;
        }

        public async Task Create(BotStep botStep)
        {
            await db.BotSteps.AddAsync(botStep);
        }

        public void Update(BotStep botStep)
        {
            db.Entry(botStep).State = EntityState.Modified;
        }

        public async Task Delete(Guid id)
        {
            BotStep botStep = await db.BotSteps.FindAsync(id);
            if (botStep != null)
                db.BotSteps.Remove(botStep);
        }
    }
}
