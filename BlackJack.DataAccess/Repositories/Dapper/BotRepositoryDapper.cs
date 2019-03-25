using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class BotRepositoryDapper : BaseRepositoryDapper<Bot>, IBotRepository
    {
        public BotRepositoryDapper(IDbConnection connection) : base(connection)
        {            
        }

        public async Task<List<Bot>> GetAllBotsByGameId(Guid gameId)
        {
            string sQuery = @"SELECT DISTINCT bots.* 
                FROM BotSteps b 
                INNER JOIN Bots bots ON b.BotId = bots.Id 
                WHERE b.GameId = @gameId";
            var result = await _connection.QueryMultipleAsync(sQuery, new { gameId });
            var bots = result.Read<Bot>().ToList();
            return bots;
        }
    }
}
