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
    public class BotStepRepositoryDapper : BaseRepositoryDapper, IBotStepRepository
    {
        public BotStepRepositoryDapper(IConfiguration config) : base(config)
        {
        }

        public async Task<List<BotStep>> GetAll()
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

        public async Task<BotStep> Get(Guid id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * " +
                    "FROM BotSteps b " +
                    "WHERE b.BotId = @id";
                conn.Open();
                var result = await conn.QueryAsync<BotStep>(sQuery, new { id });
                return result.FirstOrDefault();
            }
        }

        public async Task Create(BotStep botStep)
        {
            await Create<BotStep>(new BotStep()
            {
                Id = botStep.Id,
                Rank = botStep.Rank,
                Suite = botStep.Suite,
                GameId = botStep.GameId,
                Game = botStep.Game,
                BotId = botStep.BotId,
                Bot = botStep.Bot
            });
        }

        public async Task AddRange(List<BotStep> botSteps)
        {
            await AddRange<BotStep>(botSteps);
        }

        public async Task Update(BotStep botStep)
        {
            await Update<BotStep>(botStep);
        }

        public async Task Delete(Guid id)
        {
            await Delete<BotStep>(new BotStep { Id = id });
        }
    }
}
