using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class BotRepositoryDapper: BaseRepositoryDapper, IBotRepository
    {
        public BotRepositoryDapper(IConfiguration config):base(config)
        {
        }

        public async Task<List<Bot>> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Bots b";
                conn.Open();
                var result = await conn.QueryAsync<Bot>(sQuery);
                return result.ToList();
            }
        }

        public async Task<int> Count()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT COUNT(*) FROM Bots b";
                conn.Open();
                var result = await conn.QueryAsync<int>(sQuery);
                return result.FirstOrDefault();
            }
        }

        public async Task<Bot> Get(Guid id)
        {
            return await Get<Bot>(id.ToString());
        }

        public async Task Create(Bot bot)
        {
            await Create<Bot>(new Bot()
            {
                Id = bot.Id,
                Name = bot.Name,
                Balance = bot.Balance,
                Bet = bot.Bet
            });
        }

        public async Task Update(Bot bot)
        {
            await Update<Bot>(bot);
        }

        public async Task Delete(Guid id)
        {
            await Delete<Bot>(new Bot { Id = id });
        }
    }
}
