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
    public class BotRepositoryDapper : BaseRepositoryDapper<Bot>, IBotRepository
    {
        public BotRepositoryDapper(IConfiguration config) : base(config)
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
            return await Get(id.ToString());
        }

        public async Task Delete(Guid id)
        {
            await Delete(new Bot { Id = id });
        }
    }
}
