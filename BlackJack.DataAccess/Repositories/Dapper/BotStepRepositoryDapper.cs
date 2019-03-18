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
    public class BotStepRepositoryDapper : BaseRepositoryDapper<BotStep>, IBotStepRepository
    {
        public BotStepRepositoryDapper(IConfiguration config) : base(config)
        {
        }

        public new async Task<List<BotStep>> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM BotSteps b";
                conn.Open();
                var result = await conn.QueryAsync<BotStep>(sQuery);
                return result.ToList();
            }
        }

        public async Task<List<Bot>> GetAllBotsByGameId(Guid gameId)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT DISTINCT bots.* " +
                    "FROM BotSteps b " +
                    "INNER JOIN Bots bots ON b.BotId = bots.Id " +
                    "WHERE b.GameId = @gameId ";
                conn.Open();
                var result = await conn.QueryMultipleAsync(sQuery, new { gameId });
                return result.Read<Bot>().ToList();
            }
        }

        public async Task<List<BotStep>> GetAllStepsByGameId(Guid gameId)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT DISTINCT * " +
                    "FROM BotSteps b " +
                    "INNER JOIN Bots bots ON b.BotId = bots.Id " +
                    "WHERE b.GameId = @gameId";
                conn.Open();
                var result = await conn.QueryAsync<BotStep, Bot, BotStep>(sQuery, (step, bot) => { step.Bot = bot; return step; }, new { gameId });
                return result.ToList();
            }
        }

        public async Task<List<BotStep>> GetAllStepsByBotId(Guid botId)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT DISTINCT * " +
                    "FROM BotSteps b " +
                    "INNER JOIN Bots bots ON b.BotId = bots.Id " +
                    "WHERE b.BotId = @botId";
                conn.Open();
                var result = await conn.QueryAsync<BotStep, Bot, BotStep>(sQuery, (step, bot) => { step.Bot = bot; return step; }, new { botId });
                return result.ToList();
            }
        }

        public async Task Delete(Guid id)
        {
            await Delete(new BotStep { Id = id });
        }
    }
}
