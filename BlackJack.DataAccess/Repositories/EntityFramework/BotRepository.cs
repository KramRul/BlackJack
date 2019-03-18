using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.EntityFramework
{
    public class BotRepository: BaseRepository<Bot>, IBotRepository
    {
        public BotRepository(ApplicationContext context): base(context)
        {
        }

        public async Task<int> Count()
        {
            var result = await dataBase.Bots.CountAsync();
            return result;
        }
    }
}
